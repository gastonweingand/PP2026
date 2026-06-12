namespace Logic.Exceptions
{
    public class ClienteConDeudaException : ClienteBusinessException
    {
        public System.Guid IdCliente { get; }
        public decimal MontoPendiente { get; }

        public ClienteConDeudaException(System.Guid idCliente, decimal monto)
            : base(
                $"No se puede procesar la operación. El cliente tiene una deuda pendiente de ${monto:F2}.",
                code: "CLIENTE_CON_DEUDA"
            )
        {
            IdCliente = idCliente;
            MontoPendiente = monto;
        }
    }
}
