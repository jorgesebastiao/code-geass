
using AutoMapper;
using CodeGeass.Characters.Domain.Features.Characters;

namespace CodeGeass.Characters.Application.Features.Characters.Commands.UpdateCharacter
{
    public class UpdateCharacterProfile : Profile
    {
        public UpdateCharacterProfile()
        {
            CreateMap<UpdateCharacterInput, Character>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());
        }
    }
}
