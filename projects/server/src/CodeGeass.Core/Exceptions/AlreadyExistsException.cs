namespace CodeGeass.Core.Exceptions
{
    /// <summary>
    /// Representa uma exceção de negócio: durante o cadastro,
    /// a entidade já foi cadastrada com os dados informados
    ///
    /// </summary>
    public class AlreadyExistsException : BusinessException
    {
        public AlreadyExistsException() : base(ErrorStatusCodes.AlreadyExists, "Já exite esta entidade cadastrada.")
        {
        }

        public AlreadyExistsException(string message) : base(ErrorStatusCodes.AlreadyExists, message)
        {
        }
    }
}
