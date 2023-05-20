using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace CodeGeass.Api.Exceptions
{
    /// <summary>
    /// Classe presonsavel pelo mapemaneto 
    /// </summary>
    public static class ValidationFailureMapper
    {
        /// <summary>
        /// Método responsavel pelo mapeamento das informações da classe  FluentValidation.Results.ValidationFailure para a classe ValidationFailure 
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="failures"></param>
        /// <returns></returns>
        public static List<ValidationFailure> Map(this IEnumerable<FluentValidation.Results.ValidationFailure> failures, IMapper mapper)
        {
            return failures.AsQueryable().ProjectTo<ValidationFailure>(mapper.ConfigurationProvider).ToList();
        }
    }
}
