using Services.Exceptions.Base;

namespace Services.Exceptions.DataAccess
{
    public class DataAccessException : ApplicationException
    {
        public DataAccessException(string message, string code = "DATA_ACCESS_ERROR")
            : base(message, code)
        {
        }

        public DataAccessException(string message, System.Exception innerException, string code = "DATA_ACCESS_ERROR")
            : base(message, innerException, code)
        {
        }
    }
}
