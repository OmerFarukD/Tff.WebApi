namespace Tff.WebApi.Models.Dtos.Players;

public class PlayerResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; }

    public string Surname { get; set; }

    public int TeamId { get; set; }

    public int Number { get; set; }

    public string Position { get; set; }

    public string TeamName { get; set; }


    public static implicit operator PlayerResponseDto(Player player)
    {
        return new PlayerResponseDto
        {
            Id = player.Id,
            Number = player.Number,
            Name = player.Name,
            Position = player.Position,
            Surname = player.Surname,
            TeamId = player.TeamId,
            TeamName = player.Team.Name
        };
    }
}
