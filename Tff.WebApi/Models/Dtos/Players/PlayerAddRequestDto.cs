namespace Tff.WebApi.Models.Dtos.Players;

public sealed class PlayerAddRequestDto
{
    public string Name { get; set; }

    public string Surname { get; set; }

    public int TeamId { get; set; }

    public int Number { get; set; }

    public string Position { get; set; }

}
