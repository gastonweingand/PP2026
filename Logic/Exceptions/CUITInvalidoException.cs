namespace Logic.Exceptions
{
    public class CUITInvalidoException : ClienteBusinessException
    {
        public string CUIT { get; }

        public CUITInvalidoException(string cuit)
            : base(
                $"El CUIT '{cuit}' no es válido. Debe comenzar con 20 o 27.",
                code: "CLIENTE_CUIT_INVALIDO"
            )
        {
            CUIT = cuit;
        }
    }
}
