using ConsultarCep.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsultarCep.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ConsultarCepController : ControllerBase
{
    private readonly IConsultarCepUserCase _consultarCepUseCase;
    public ConsultarCepController(IConsultarCepUserCase consultarCepUseCase)
    {
        _consultarCepUseCase = consultarCepUseCase;
    }
    [HttpGet("{cep}")]
    public async Task<IActionResult> ConsultarCep(string cep)
    {
        try
        {
            var resultado = await _consultarCepUseCase.ConsultarAsync(cep);
            return Ok(resultado);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
        }
    }
}
