using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tff.WebApi.Models;
using Tff.WebApi.Models.Dtos.Teams;
using Tff.WebApi.Repositories;
using Tff.WebApi.Services.Abstract;

namespace Tff.WebApi.Services.Concrete;

public class TeamService(BaseDbContext context,IMapper mapper) : ITeamService
{
    public string Add(TeamAddRequestDto dto)
    {
        Team team = mapper.Map<Team>(dto);
        context.Entry(team).State = EntityState.Added;
        context.SaveChanges();

        return "Takım eklendi.";
    }

    public string Delete(int id)
    {
        Team team = context.Teams.Find(id);
        if (team is null)
        {
            return "Takım bulunamadı.";
        }

        context.Entry(team).State = EntityState.Deleted;
        context.SaveChanges();

        return "Takım Silindi.";
    }

    public List<TeamResponseDto> GetAll()
    {
        List<Team> teams = context.Teams.ToList();
        List<TeamResponseDto> responses = mapper.Map<List<TeamResponseDto>>(teams);

        return responses;
    }

    public TeamResponseDto? GetById(int id)
    {
        Team team = context.Teams.Find(id);
        TeamResponseDto response = mapper.Map<TeamResponseDto>(team);
        return response;
    }

    public TeamDetailsResponseDto GetDetailsById(int id)
    {
        Team team = context.Teams.Include(x => x.Players)
            .SingleOrDefault(x=> x.Id==id);
        var response = mapper.Map<TeamDetailsResponseDto>(team);
        return response;
    }

    public string Update(TeamUpdateRequestDto dto)
    {
        bool isPresent = context.Teams.Any(x=>x.Id == dto.Id);

        if(isPresent == false)
        {
            return "Aradığınız takım bulunamadı.";
        }


        Team team = mapper.Map<Team>(dto);
        context.Entry(team).State = EntityState.Modified;
        context.SaveChanges();

        return "Takım Güncellendi.";
    }
}
