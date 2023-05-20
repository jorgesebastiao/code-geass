using AutoMapper;

namespace CodeGeass.Api.Exceptions
{
    /// <summary>
    /// Classe de mapeamento de Autommater para ValidationFailure
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Construtor padrão
        /// </summary>
        public MappingProfile()
        {
            CreateMap<FluentValidation.Results.ValidationFailure, ValidationFailure>();
        }
    }
}
