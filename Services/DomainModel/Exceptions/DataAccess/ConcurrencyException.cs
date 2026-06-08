namespace Services.Exceptions.DataAccess
{
    public class ConcurrencyException : DataAccessException
    {
        public ConcurrencyException(string message = "El registro fue modificado por otro usuario. Recargue los datos e intente nuevamente.")
            : base(message, code: "CONCURRENCY_ERROR")
        {
        }
    }
}
