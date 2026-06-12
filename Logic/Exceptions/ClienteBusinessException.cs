using Services.Exceptions.Base;

namespace Logic.Exceptions
{
    public abstract class ClienteBusinessException : BusinessRuleException
    {
        protected ClienteBusinessException(string message, string code)
            : base(message, code: code)
        {
        }
    }
}
