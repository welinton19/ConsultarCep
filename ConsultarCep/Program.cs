using ConsultarCep.Application.Interfaces;
using ConsultarCep.Application.UseCases;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();


builder.Services.AddHttpClient<IConsultarCepUserCase, ConsultarCepUseCase>();
var app = builder.Build();


app.MapOpenApi();
app.MapScalarApiReference();

app.UseHttpsRedirection();


app.MapControllers();


app.Run();


