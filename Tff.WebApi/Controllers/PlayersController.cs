using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tff.WebApi.Exceptions.Types;
using Tff.WebApi.Models;
using Tff.WebApi.Models.Dtos.Players;
using Tff.WebApi.Services.Abstract;


namespace Tff.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlayersController (IPlayerService playerService) : ControllerBase
{

    [HttpPost("add")]
    public IActionResult Add(PlayerAddRequestDto playerAddRequestDto)
    {

            var result = playerService.Add(playerAddRequestDto);
            return Ok(result);

    }

    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var result = playerService.GetAll();
        return Ok(result);
    }

    [HttpPut("update")]
    public IActionResult Update(PlayerUpdateRequestDto dto)
    {
        var result = playerService.Update(dto);
        return Ok(result);
    }


    [HttpDelete("delete")]
    public IActionResult Delete(int id)
    {
        var result = playerService.Delete(id);

        return Ok(result);
    }

    [HttpGet("getbyid")]
    public IActionResult GetById(int id)
    {
        var result = playerService.GetById(id);
        return Ok(result);
    }

}
