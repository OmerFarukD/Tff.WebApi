using Tff.WebApi.Models.Dtos.Teams;

namespace Tff.WebApi.Services.Abstract;

public interface ITeamService
{
    string Add(TeamAddRequestDto dto);
    string Update(TeamUpdateRequestDto dto);

    string Delete(int id);

    List<TeamResponseDto> GetAll();

    TeamResponseDto? GetById(int id);

    TeamDetailsResponseDto? GetDetailsById(int id);


}
