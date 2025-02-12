namespace Tff.WebApi.Models.Dtos.Players;

public sealed class PlayerUpdateRequestDto
{
    public int Id { get; set; }
    public string Name { get; set; }

    public string Surname { get; set; }

    public int TeamId { get; set; }

    public int Number { get; set; }

    public string Position { get; set; }

}