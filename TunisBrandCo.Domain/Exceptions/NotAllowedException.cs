namespace TunisBrandCo.Domain.Exceptions
{
    public class NotAllowedException : BusinessException
    {
        public NotAllowedException(string message) : base(ErrorCodes.NotAllowed, message)
        {
        }
    }
}
