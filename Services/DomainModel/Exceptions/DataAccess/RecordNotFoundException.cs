namespace Services.Exceptions.DataAccess
{
    public class RecordNotFoundException : DataAccessException
    {
        public RecordNotFoundException(string entityName, object id)
            : base(
                $"El registro de {entityName} con ID '{id}' no fue encontrado.",
                code: "RECORD_NOT_FOUND"
            )
        {
        }

        public RecordNotFoundException(string message)
            : base(message, code: "RECORD_NOT_FOUND")
        {
        }
    }
}
