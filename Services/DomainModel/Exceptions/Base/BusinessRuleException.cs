namespace Services.Exceptions.Base
{
    public abstract class BusinessRuleException : ApplicationException
    {
        protected BusinessRuleException(string message, string code = "BUSINESS_RULE_ERROR")
            : base(message, code)
        {
        }
    }
}
