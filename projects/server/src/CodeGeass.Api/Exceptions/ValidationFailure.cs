namespace CodeGeass.Api.Exceptions
{
    /// <summary>
    /// Classe responsavel por representar as falhas de validações
    /// </summary>
    public class ValidationFailure
    {
        /// <summary>
        /// Nome da propriedade
        /// </summary>
        public string PropertyName { get; set; }
        /// <summary>
        /// Mensagem de erro
        /// </summary>

        public string ErrorMessage { get; set; }

        public object AttemptedValue { get; set; }

        public object CustomState { get; set; }
        /// <summary>
        /// Codigo de erro
        /// </summary>
        public string ErrorCode { get; set; }

        public object[] FormattedMessageArguments { get; set; }

        public Dictionary<string, object> FormattedMessagePlaceholderValues { get; set; }

        public string ResourceName { get; set; }

    }
}
