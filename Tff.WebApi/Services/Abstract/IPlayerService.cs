using Tff.WebApi.Models.Dtos.Players;
using Tff.WebApi.Models.Dtos.Teams;

namespace Tff.WebApi.Services.Abstract;

public interface IPlayerService
{
    string Add(PlayerAddRequestDto dto);
    string Update(PlayerUpdateRequestDto dto);

    string Delete(int id);

    List<PlayerResponseDto> GetAll();

    PlayerResponseDto? GetById(int id);

    List<PlayerResponseDto> GetAllByTeamId(int teamId);

    List<PlayerResponseDto> GetAllByTeamAndPosition(int teamId, string position);
}
