using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tff.WebApi.Models;
using Tff.WebApi.Models.Dtos.Players;
using Tff.WebApi.Repositories;
using Tff.WebApi.Services.Mappers;

namespace Tff.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlayersController (BaseDbContext context,PlayerMapper playerMapper) : ControllerBase
{

    [HttpPost("add")]
    public IActionResult Add(PlayerAddRequestDto playerAddRequestDto)
    {
        Player player = playerMapper.ConvertToEntity(playerAddRequestDto);

        context.Add(player);
        context.SaveChanges();

        return Ok(player);
    }

    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        List<Player> players = context.Players.Include(x=>x.Team).ToList();
        List<PlayerResponseDto> responses = playerMapper.ConvertToResponseList(players);
        return Ok(responses);
    }




    [HttpGet]
    public IActionResult Deneme()
    {
        Player player1 = new Player
        {
            Id = 1,
            Name = "dENEME",
            Number = 5,
            Position = "Forver",
            Surname = "Icardi",

            Team = new Team { Id = 1, Name = "Galatasaray" },
            TeamId = 1
        };

        PlayerResponseDto dto = player1;

        return Ok(dto);
    }

}
