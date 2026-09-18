using ConsultarCep.Application.DTOs;
using ConsultarCep.Application.Interfaces;
using ConsultarCep.Domain.Entities;
using ConsultarCep.Domain.Interfaces;
using System.Text.Json;

namespace ConsultarCep.Application.UseCases;

public class ConsultarCepUseCase : IConsultarCepUserCase
{
    private readonly HttpClient _httpClient;

    public ConsultarCepUseCase(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ConsultarCepResponse> ConsultarAsync(string cep)
    {
        
        var cepLimpo = cep.Replace("-", "").Replace(".", "").Trim();

        if (cepLimpo.Length != 8 || !cepLimpo.All(char.IsDigit))
            throw new ArgumentException("CEP inválido.");

        
        var url = $"https://viacep.com.br/ws/{cepLimpo}/json/";
        var response = await _httpClient.GetAsync(url);

        if (!response.IsSuccessStatusCode)
            throw new Exception("Erro ao consultar o CEP.");

        var json = await response.Content.ReadAsStringAsync();

       
        if (json.Contains("\"erro\""))
            throw new Exception("CEP não encontrado.");

        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var endereco = JsonSerializer.Deserialize<EnderecoResults>(json, options)!;

        
        var frete = FreteResult.Calcular(endereco.Uf!, 1);

        return new ConsultarCepResponse
        {
            Cep = endereco.Cep,
            Logradouro = endereco.Logradouro,
            Complemento = endereco.Complemento,
            Bairro = endereco.Bairro,
            Localidade = endereco.Localidade,
            Uf = endereco.Uf,
            Ddd = endereco.Ddd,
            Ibge = endereco.Ibge,
            ValorFrete = frete.ValorFrete,
            PrazoEntregaDias = frete.PrazoEntregaDias,
            Regiao = frete.Regiao
        };
    }
}
