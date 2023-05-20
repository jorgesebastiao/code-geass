namespace CodeGeass.Api.Extensions
{
    /// <summary>
    /// Classe de extensão resposnavel pela manipulação de exceções
    /// </summary>
    public static class ExceptionExtension
    {
        /// <summary>
        /// Método de extensão responsável por obter a primeira Exceção
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static Exception GetFirstException(this Exception ex)
        {
            if (ex.InnerException is null)
                return ex;
            else
                return GetFirstException(ex.InnerException);
        }

        /// <summary>
        /// Método de extensão responsável por preparar o log
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static object PrepareForLog(this Exception ex)
        {
            var baseException = ex.GetFirstException();

            return new { baseException.Message, baseException.StackTrace };
        }
    }
}
