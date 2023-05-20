namespace CodeGeass.Core.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException(ErrorStatusCodes statusCode, string message) : base(message)
        {
            ErrorStatusCodes = statusCode;
        }

        public ErrorStatusCodes ErrorStatusCodes { get; }
    }
}
