using Microsoft.AspNetCore.Mvc;
using Tff.WebApi.Models;
using Tff.WebApi.Repositories;

namespace Tff.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public sealed class TeamsController(BaseDbContext context) : ControllerBase
{

    [HttpPost("add")]

    // http://localhost:134520/teams/add
    public IActionResult Add(Team team)
    {
        context.Add(team);
        context.SaveChanges();

        return Ok("Takım başarıyla eklendi.");
    }



    [HttpGet]
    public IActionResult GetAll()
    {
        var teams = context.Teams.ToList();
        return Ok(teams);
    }
}
