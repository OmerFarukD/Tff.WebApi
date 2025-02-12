namespace Tff.WebApi.Models;

public sealed class Team
{
    public int Id { get; set; }
    public string Name { get; set; }

    public List<Player> Players { get; set; }

}


