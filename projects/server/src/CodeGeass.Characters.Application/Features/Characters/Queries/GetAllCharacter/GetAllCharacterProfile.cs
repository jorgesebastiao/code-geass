using AutoMapper;
using CodeGeass.Characters.Domain.Features.Characters;

namespace CodeGeass.Characters.Application.Features.Characters.Queries.GetAllCustomer
{
    public class GetAllCharacterProfile : Profile
    {
        public GetAllCharacterProfile()
        {
            CreateMap<Character, GetAllCharacterOutPut>();
        }
    }
}
