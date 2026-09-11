namespace ConsultarCep.Domain.Entities;

public class FreteResult
{
    public Decimal ValorFrete { get; private set; }
    public string? Transportadora { get; private set; }
    public int PrazoEntregaDias { get; private set; }
    public string? Regiao { get; private set; }

    private FreteResult()
    {

    }

    public static FreteResult Calcular(string Uf, decimal peso)
    {
        var regiao = ObterRegiao(Uf);

        var precoPorKg = regiao switch
        {
            "Sudeste" => 5.00m,
            "Sul" => 6.50m,
            "Centro-Oeste" => 8.00m,
            "Nordeste" => 9.50m,
            "Norte" => 12.00m,
            _ => 10.00m
        };

        var prazo = regiao switch
        {
            "Sudeste" => 3,
            "Sul" => 4,
            "Centro-Oeste" => 5,
            "Nordeste" => 7,
            "Norte" => 10,
            _ => 8
        };

        return new FreteResult
        {
            ValorFrete = Math.Round(precoPorKg * peso, 2),
            PrazoEntregaDias = prazo,
            Regiao = regiao,
            Transportadora = "Transportadora Padrão"
        };

    }

    private static string ObterRegiao(string uf)
    {
        var regioes = new Dictionary<string, string[]>
        {
            { "Sudeste", new[] { "SP", "RJ", "MG", "ES" } },
            { "Sul", new[] { "RS", "SC", "PR" } },
            { "Centro-Oeste", new[] { "GO", "MT", "MS", "DF" } },
            { "Nordeste", new[] { "BA", "SE", "AL", "PE", "PB", "RN", "CE", "PI", "MA" } },
            { "Norte", new[] { "AM", "PA", "RO", "RR", "AP", "AC", "TO" } }
        };

        foreach (var regiao in regioes)
            if (regiao.Value.Contains(uf.ToUpper()))
                return regiao.Key;

        return "Desconhecida";
    }
}

