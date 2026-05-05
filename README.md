# API - Calculadora de Juros
[![NPM](https://img.shields.io/npm/l/react)](https://github.com/grecojoao/InterestCalculator/blob/master/LICENSE) 

## ⚡ Sobre o projeto

API Calculadora de juros é uma aplicação back-end desenvolvida para o cálculo de juros compostos em memória.

A aplicação possui os seguintes endpoints:

### Endpoints

#### POST `/calculajuros`
Calcula o valor final com juros compostos.

**Parâmetros:**
- `valorInicial` (decimal): Valor inicial para o cálculo
- `meses` (int): Quantidade de meses para aplicar os juros

**Fórmula:**
```
valorFinal = valorInicial * ((1 + taxaJuros) ^ quantidadeMeses)
```

**Exemplo de requisição:**
```bash
POST /calculajuros?valorInicial=100&meses=5
```

**Resposta de sucesso (200):**
```json
{
  "sucesso": true,
  "mensagem": "Calculo realizado",
  "resultado": 105.10
}
```

#### GET `/showmethecode`
Retorna o link do repositório do código-fonte.

**Resposta:**
```
https://github.com/grecojoao/InterestCalculator
```

## 🏗️ Arquitetura

O projeto segue os princípios de Clean Architecture e Domain-Driven Design (DDD), organizado em camadas:

- **InterestCalculator.API**: Camada de apresentação (Controllers, Startup)
- **InterestCalculator.Domain**: Camada de domínio (Entidades, Handlers, Commands, Services)
- **InterestCalculator.Domain.Notifications**: Sistema de notificações para validações
- **InterestCalculator.IoC**: Injeção de dependências
- **InterestCalculator.Test**: Testes unitários com NUnit

## :rocket: Tecnologias

- C# / .NET 10.0
- ASP.NET Core
- Swagger/OpenAPI
- NUnit (testes unitários)
- Docker
- Azure (deployment)

## 📋 Pré-requisitos

- [.NET 10.0 SDK](https://dotnet.microsoft.com/download/dotnet/10.0) ou superior
- Docker (opcional, para execução em container)

## 📝 Como executar o projeto

### Executando localmente

```bash
# Clonar o repositório
git clone https://github.com/grecojoao/InterestCalculator.git

# Entrar na pasta do projeto
cd InterestCalculator

# Restaurar as dependências
dotnet restore

# Executar o projeto
cd InterestCalculator.API
dotnet run

# Ou executar com hot reload
dotnet watch run
```

A API estará disponível em:
- HTTP: `http://localhost:5000`
- HTTPS: `https://localhost:5001`
- Swagger UI: `https://localhost:5001/swagger`

### Executando com Docker

```bash
# Clonar a imagem docker
docker pull grecojoao/interestcalculatorapi

# Executar a imagem docker
docker run -p 8080:80 grecojoao/interestcalculatorapi
```

Ou construir localmente:

```bash
# Construir a imagem
docker build -t interestcalculator-api .

# Executar o container
docker run -p 8080:80 interestcalculator-api
```

## 🧪 Executando os testes

```bash
# Executar todos os testes
dotnet test

# Executar testes com cobertura
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=opencover

# Executar testes de uma categoria específica
dotnet test --filter "Category=Commands"
dotnet test --filter "Category=Handlers"
```

## 📊 Cobertura de Testes

O projeto possui testes unitários cobrindo:
- ✅ Validação de comandos
- ✅ Handlers de cálculo de juros
- ✅ Cenários de sucesso e falha
- ✅ Tratamento de valores edge cases (zero, decimais)
- ✅ Comportamento com serviços offline

## 🚀 Implantação em produção

- [Microsoft Azure](https://interestcalculator.azurewebsites.net/swagger)

## 📄 Licença

Este projeto está sob a licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.

## 👤 Autor

**João Greco**

- GitHub: [@grecojoao](https://github.com/grecojoao)
- LinkedIn: [João Greco](https://www.linkedin.com/in/grecojoao/)

---

⭐ Se este projeto foi útil para você, considere dar uma estrela no repositório!
