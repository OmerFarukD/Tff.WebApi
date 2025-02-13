using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tff.WebApi.Exceptions.Types;
using Tff.WebApi.Models;
using Tff.WebApi.Models.Dtos.Players;
using Tff.WebApi.Repositories;
using Tff.WebApi.Services.Abstract;

namespace Tff.WebApi.Services.Concrete;

public sealed class PlayerService(BaseDbContext context, IMapper mapper) : IPlayerService
{
    
    
    // TODO: oyuncu eklenirken forma numarası benzersiz olmalıdır.
    // todo: bir takıma oyuncu eklendiği zaman max oyuncu sayısı 34 olmalıdır.
    // todo: oyuncu adı ve soyadı benzersiz olmalıdır.
    
    public string Add(PlayerAddRequestDto dto)
    {
        NumberMustBeUnique(dto.Number,dto.TeamId);
        PlayerNameAndSurnameMustBeUnique(dto.Name, dto.Surname);
        MaxPlayerCheck(dto.TeamId);
        
        Player player = mapper.Map<Player>(dto);
        context.Entry(player).State = EntityState.Added;
        context.SaveChanges();

        return "Oyunncu Eklendi.";
    }

    public string Delete(int id)
    {
        Player player = context.Players.Find(id);
        if(player is null)
        {
            throw new NotFoundException("Oyuncu Bulunamadı");
        }

        context.Entry(player).State = EntityState.Deleted;
        context.SaveChanges();

        return "Oyuncu silindi.";
    }

    public List<PlayerResponseDto> GetAll()
    {
        List<Player> players = context.Players.Include(x=>x.Team).ToList();
        List<PlayerResponseDto> responses = mapper.Map<List<PlayerResponseDto>>(players);

        return responses;
    }

    public List<PlayerResponseDto> GetAllByTeamAndPosition(int teamId, string position)
    {
        List<Player> players = context.Players
            .Where(x => x.TeamId == teamId &&
        x.Position.Contains(position, StringComparison.CurrentCultureIgnoreCase))
            .Include(x => x.Team)
            .ToList();

        List<PlayerResponseDto> responses = mapper.Map<List<PlayerResponseDto>>(players);

        return responses;
    }

    public List<PlayerResponseDto> GetAllByTeamId(int teamId)
    {
        List<Player> players = context.Players.Where(x=>x.TeamId==teamId).Include(x => x.Team).ToList();
        List<PlayerResponseDto> responses = mapper.Map<List<PlayerResponseDto>>(players);

        return responses;

    }

    public PlayerResponseDto? GetById(int id)
    {
        Player player = context.Players.Find(id);
        if(player is null)
        {
            throw new NotFoundException("Oyuncu Bulunamadı");
        }
        PlayerResponseDto dto = mapper.Map<PlayerResponseDto>(player);

        return dto;
    }

    public string Update(PlayerUpdateRequestDto dto)
    {
        bool isPresent = context.Players.Any(x=>x.Id == dto.Id);
        if(isPresent == false)
        {
            return "Oyuncu Bulunamadı.";
        }
        var player = mapper.Map<Player>(dto);

        context.Entry(player).State = EntityState.Modified;
        context.SaveChanges();

        return "Oyuncu Güncellendi.";
    }
    
    
    // private methods 

    private void NumberMustBeUnique(int number,int teamId)
    {

        var isPresent = context.Players.Any(x => x.TeamId == teamId && x.Number == number);
        if (isPresent)
        {
            throw new BusinessException("Aynı takımda aynı numaradan oyuncu eklenemez.");
        }
        
    }

    private void MaxPlayerCheck(int teamId)
    {
        var countPlayer = context.Players.Count(x=>x.TeamId == teamId);
        if (countPlayer>10)
        {
            throw new BusinessException("Bir takımda maksimıum 10 oyuncu olabilir.");
        }
    }


    private void PlayerNameAndSurnameMustBeUnique(string name, string surname)
    {
        var isPresent = context.Players.Any(x => x.Name == name && x.Surname == surname);
        if (isPresent)
        {
            throw new BusinessException("Eklemek istediğiniz oyuncu sisteme kayıtlı.");
        }
    }
    
}
