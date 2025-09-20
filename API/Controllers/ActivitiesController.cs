using System;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers;

public class ActivitiesController : BaseApiController
{
    private readonly AppDbContext context;

    public ActivitiesController(AppDbContext context)
    {
        this.context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Activity>>> GetActivities()
    {
        return await context.Activities.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Activity>> GetActivityDetail(string id)
    {
        var acttivity = await context.Activities.FindAsync(id);

        if (acttivity == null) return NotFound();

        return acttivity;
    }
}
