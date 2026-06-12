namespace Logic.Exceptions
{
    public class ClienteDuplicadoException : ClienteBusinessException
    {
        public string CUIT { get; }

        public ClienteDuplicadoException(string cuit)
            : base(
                $"Ya existe un cliente registrado con el CUIT '{cuit}'.",
                code: "CLIENTE_DUPLICADO"
            )
        {
            CUIT = cuit;
        }
    }
}
