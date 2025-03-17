using AutoMapper;
using Tff.WebApi.Models;
using Tff.WebApi.Models.Dtos.Players;
using Tff.WebApi.Models.Dtos.Teams;

namespace Tff.WebApi.Services.Mappers;

public sealed class MappingProfile : Profile
{

    public MappingProfile()
    {
        CreateMap<TeamAddRequestDto,Team>();
        CreateMap<Team,TeamResponseDto>();
        CreateMap<TeamUpdateRequestDto,Team>();

        CreateMap<Player, TeamPlayersDetailDto>()
            .ForMember(x => x.FullName, opt =>
                opt.MapFrom(p => $"{p.Name} {p.Surname}")
            );

        CreateMap<Team, TeamDetailsResponseDto>();



        CreateMap<Player,PlayerResponseDto>();
        CreateMap<PlayerAddRequestDto,Player>();
        CreateMap<PlayerUpdateRequestDto, Player>();
    }
}
