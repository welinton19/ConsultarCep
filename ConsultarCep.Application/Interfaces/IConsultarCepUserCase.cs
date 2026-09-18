using ConsultarCep.Application.DTOs;

namespace ConsultarCep.Application.Interfaces;

public interface IConsultarCepUserCase
{
    Task<ConsultarCepResponse> ConsultarAsync(string cep);
}
