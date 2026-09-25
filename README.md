API REST para consulta de CEP brasileiro com dados de endereço completo e estimativa de frete, desenvolvida em .NET 10 com Clean Architecture.

## ✅ Funcionalidades

- Consulta de CEP via ViaCEP
- Retorno de endereço completo (logradouro, bairro, cidade, UF)
- DDD e código IBGE do município
- Estimativa de frete por região
- Prazo de entrega estimado

## 🚀 Como Usar

### Base URL
https://consultarcep.onrender.com/scalar/v1

### Endpoint

#### GET /api/ConsultarCep/{cep}
Consulta um CEP e retorna endereço completo com estimativa de frete.

**Exemplo:**

GET /api/ConsultarCep/39803650

**Response:**
```json
{
    "cep": "39803-650",
    "logradouro": "Rua Celso Daniel",
    "complemento": "",
    "bairro": "Conjunto Paulo Freire",
    "localidade": "Teófilo Otoni",
    "uf": "MG",
    "ddd": "33",
    "ibge": "3168606",
    "valorFrete": 5.00,
    "prazoEntregaDias": 3,
    "regiao": "Sudeste"
}
```

## 💰 Estimativa de Frete por Região

| Região | Preço/kg | Prazo |
|--------|----------|-------|
| Sudeste | R$ 5,00 | 3 dias |
| Sul | R$ 6,50 | 4 dias |
| Centro-Oeste | R$ 8,00 | 5 dias |
| Nordeste | R$ 9,50 | 7 dias |
| Norte | R$ 12,00 | 10 dias |

## 🏗️ Tecnologias

- .NET 10
- Clean Architecture
- ViaCEP (API externa)
- Scalar (documentação)
- Docker
- Render

## 📁 Estrutura do Projeto

ConsultarCep/
├── ConsultarCep/ # API (Controllers, Program.cs)
├── ConsultarCep.Application/ # UseCases, DTOs, Interfaces
└── ConsultarCep.Domain/ # Entities, Interfaces, Exceptions

## 📜 Licença

MIT License

---

Desenvolvido por [Welinton Batista](https://github.com/welinton19) 🇧🇷
