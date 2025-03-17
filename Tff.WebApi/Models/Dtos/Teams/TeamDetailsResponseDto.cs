using Tff.WebApi.Models.Dtos.Players;

namespace Tff.WebApi.Models.Dtos.Teams;

public class TeamDetailsResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; }

    public List<TeamPlayersDetailDto> Players { get; set; }
    
    
}