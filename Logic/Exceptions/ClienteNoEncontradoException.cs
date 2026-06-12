namespace Logic.Exceptions
{
    public class ClienteNoEncontradoException : ClienteBusinessException
    {
        public System.Guid IdCliente { get; }

        public ClienteNoEncontradoException(System.Guid idCliente)
            : base(
                $"No existe un cliente con el ID {idCliente}.",
                code: "CLIENTE_NO_ENCONTRADO"
            )
        {
            IdCliente = idCliente;
        }

        public ClienteNoEncontradoException(string message)
            : base(message, code: "CLIENTE_NO_ENCONTRADO")
        {
        }
    }
}
