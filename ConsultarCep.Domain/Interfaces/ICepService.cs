using ConsultarCep.Domain.Entities;

namespace ConsultarCep.Domain.Interfaces;

public interface ICepService
{
    Task<FreteResult> CalcularFreteAsync(string cep, decimal peso);
    Task<EnderecoResults> ObterEnderecoPorCepAsync(string cep);
}
