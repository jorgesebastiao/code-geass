

using CodeGeass.Core.Exceptions;

namespace CodeGeass.Api.Exceptions
{
    /// <summary>
    /// Classe que representa o Payload de retorno de exceções para o cliente da aplicação
    /// </summary>
    public class ExceptionPayload
    {
        /// <summary>
        /// Construtor padrão do Payload de erro
        /// </summary>
        /// <param name="status"></param>
        /// <param name="error"></param>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public ExceptionPayload(int status, string error, string message, Exception exception)
        {
            Status = status;
            Error = error;
            Message = message;
            _exception = exception;
        }

        /// <summary>
        /// Construtor padrão do Payload de erro
        /// </summary>
        /// <param name="status"></param>
        /// <param name="error"></param>
        /// <param name="message"></param>
        /// <param name="failures">Lista de problemas de validação</param>
        /// <param name="exception"></param>
        public ExceptionPayload(int status, string error, string message, List<ValidationFailure> failures, Exception exception)
        {
            Status = status;
            Error = error;
            Message = message;
            _exception = exception;
            Errors = failures;
        }

        private Exception _exception;
        /// <summary>
        /// Status de erro HTTP
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// Erro da aplicação
        /// </summary>

        public string Error { get; set; }
        /// <summary>
        /// Mensagem de erro da aplicação
        /// </summary>

        public string Message { get; set; }
        /// <summary>
        /// Lista com erros de validações
        /// </summary>
        /// <returns></returns>
        public List<ValidationFailure> Errors { get; set; }

        /// <summary>
        /// Cria um novo Payload
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static ExceptionPayload New<T>(T exception) where T : Exception
        {
            int statusCode;
            string error;

            if (exception is BusinessException)
            {
                statusCode = (exception as BusinessException).ErrorStatusCodes.GetHashCode();
                error = (exception as BusinessException).ErrorStatusCodes.ToString();
            }
            else
            {
                statusCode = ErrorStatusCodes.Unhandled.GetHashCode();
                error = ErrorStatusCodes.Unhandled.ToString();
            }

            return new ExceptionPayload(statusCode, error, exception.Message, exception);
        }


        /// <summary>
        /// Cria um novo Payload
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="exception"></param>
        /// <param name="failures">Lista de problemas de validação</param>
        /// <returns></returns>
        public static ExceptionPayload New<T>(T exception, List<ValidationFailure> failures) where T : Exception
        {
            return new ExceptionPayload(ErrorStatusCodes.BadRequest.GetHashCode(), ErrorStatusCodes.BadRequest.ToString(), "Erro de validações", failures, exception);
        }
    }
}
