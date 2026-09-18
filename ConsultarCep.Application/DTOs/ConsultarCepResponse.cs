namespace ConsultarCep.Application.DTOs;

public class ConsultarCepResponse
{
    public string Cep
    {
        get; set;
    }
    public string Logradouro
    {
        get; set;
    }
    public string Complemento
    {
        get; set;
    }
    public string Bairro
    {
        get; set;
    }
    public string Localidade
    {
        get; set;
    }
    public string Uf
    {
        get; set;
    }

    public string Ddd
    {
        get; set;
    }

    public string Ibge
    {
        get; set;
    }

    public decimal ValorFrete
    {
        get; set;
    }

    public int PrazoEntregaDias
    {
        get; set;
    }

    public string Regiao
    {
        get; set;
    }
}
