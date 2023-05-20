
using AutoMapper;
using CodeGeass.Characters.Application.Features.Customers.Commands.CreateCustomer;
using CodeGeass.Characters.Domain.Features.Characters;

namespace CodeGeass.Characters.Application.Features.Characters.Commands.CreateCustomer
{
    public class CreateCharacterProfile : Profile
    {
        public CreateCharacterProfile()
        {
            CreateMap<CreateCharacterInput, Character>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());
        }
    }
}
