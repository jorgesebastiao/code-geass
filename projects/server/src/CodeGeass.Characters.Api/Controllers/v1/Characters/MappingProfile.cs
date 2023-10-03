using AutoMapper;
using CodeGeass.Characters.Api.Controllers.v1.Characters.Requests;
using CodeGeass.Characters.Application.Features.Characters.Commands.UpdateCharacter;
using CodeGeass.Characters.Application.Features.Customers.Commands.CreateCustomer;

namespace CodeGeass.Characters.Api.Controllers.v1.Characters
{
    /// <summary>
    /// Perfil de mapeamento do Aggreagate Clientes 
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Cosntrutor padrão
        /// </summary>
        public MappingProfile()
        {
            CreateMap<CreateCharacterRequest, CreateCharacterInput>();
            CreateMap<UpdateCharacterRequest, UpdateCharacterInput>();
        }
    }
}
