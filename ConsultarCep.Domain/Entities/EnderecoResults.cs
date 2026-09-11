namespace ConsultarCep.Domain.Entities;

public class EnderecoResults
{
    public string? Cep { get; private  set; }
    public string? Logradouro { get; private  set; }
    public string? Complemento { get; private  set; }
    public string? Bairro { get; private  set; }
    public string? Localidade { get; private  set; }
    public string? Uf { get; private  set; }
    public string? Ibge { get; private  set; }
    public string? Ddd { get; private  set; }


    private EnderecoResults()
    {
        
    }

    public static EnderecoResults Criar(string? cep, string? logradouro, string? complemento, string? bairro, 
        string? localidade, string? uf, string? ibge, string? ddd)
    {
        return new EnderecoResults
        {
            Cep = cep,
            Logradouro = logradouro,
            Complemento = complemento,
            Bairro = bairro,
            Localidade = localidade,
            Uf = uf,
            Ibge = ibge,
            Ddd = ddd
        };
    }
}
