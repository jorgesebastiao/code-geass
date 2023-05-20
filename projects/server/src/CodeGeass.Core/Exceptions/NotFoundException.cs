namespace CodeGeass.Core.Exceptions
{
    public class NotFoundException : BusinessException
    {
        public NotFoundException() : base(ErrorStatusCodes.NotFound, "Register Not Found!")
        {

        }
    }
}
