using AutoMapper;
using CodeGeass.Characters.Domain.Features.Characters;

namespace CodeGeass.Characters.Application.Features.Characters.Queries.GetByIdCharacter
{
    public class GetByIdCharacterProfile : Profile
    {
        public GetByIdCharacterProfile()
        {
            CreateMap<Character, GetByIdCharacterOutPut>();
        }
    }
}
