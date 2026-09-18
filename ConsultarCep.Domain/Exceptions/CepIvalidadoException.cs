namespace ConsultarCep.Domain.Exceptions;

public class CepIvalidadoException : Exception
{
    public CepIvalidadoException(string cep)
        : base($"O CEP '{cep}' é inválido.")
    {
    }
}
