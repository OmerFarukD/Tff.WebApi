using Microsoft.AspNetCore.Mvc;
using Tff.WebApi.Models;
using Tff.WebApi.Models.Dtos.Teams;
using Tff.WebApi.Repositories;
using Tff.WebApi.Services.Abstract;

namespace Tff.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public sealed class TeamsController(ITeamService teamService) : ControllerBase
{

    [HttpPost("add")]
    // http://localhost:134520/teams/add
    public IActionResult Add(TeamAddRequestDto dto)
    {
        var result = teamService.Add(dto);

        return Ok(result);
    }



    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var result = teamService.GetAll();

        return Ok(result);
    }


    [HttpGet("getbyid")]
    public IActionResult GetById(int id)
    {
        var result = teamService.GetById(id);

        return Ok(result);
    }

    [HttpDelete("delete")]
    public IActionResult Delete(int id)
    {
        var result = teamService.Delete(id);
        return Ok(result);
    }

    [HttpPut("update")]
    public IActionResult Update(TeamUpdateRequestDto dto)
    {
        var result = teamService.Update(dto);
        return Ok(result);
    }

}
