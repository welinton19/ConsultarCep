namespace ConsultarCep.Domain.Entities;

public class EnderecoResults
{
    public string? Cep { get;   set; }
    public string? Logradouro { get;   set; }
    public string? Complemento { get;   set; }
    public string? Bairro { get;   set; }
    public string? Localidade { get;  set; }
    public string? Uf { get;   set; }
    public string? Ibge { get;   set; }
    public string? Ddd { get;   set; }


    public EnderecoResults()
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
