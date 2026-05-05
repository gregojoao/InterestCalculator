using InterestCalculator.API.Controllers;
using InterestCalculator.API.Responses;
using InterestCalculator.Domain.Handlers;
using InterestCalculator.Test.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace InterestCalculator.Test.API.Controllers;

[TestFixture]
public class CalculaJurosControllerTests
{
    private CalculaJurosController _controller = null!;
    private InterestCalculatorHandler _handler = null!;

    [SetUp]
    public void Setup()
    {
        _handler = new InterestCalculatorHandler(new FakeInterestRateService());
        _controller = new CalculaJurosController();
    }

    [Test]
    [Category("Controllers")]
    public async Task Post_ComValoresValidos_DeveRetornarOkComResultado()
    {
        // Arrange
        decimal valorInicial = 100m;
        int meses = 5;

        // Act
        var result = await _controller.Post(valorInicial, meses, _handler, CancellationToken.None);

        // Assert
        Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
        var okResult = result.Result as OkObjectResult;
        Assert.That(okResult, Is.Not.Null);
        var response = okResult!.Value as RespostaRequisicao;
        Assert.That(response, Is.Not.Null);
        Assert.That(response!.Sucesso, Is.True);
        Assert.That(response.Resultado, Is.EqualTo(105.10m));
    }

    [Test]
    [Category("Controllers")]
    public async Task Post_ComValorInicialNulo_DeveRetornarBadRequest()
    {
        // Arrange
        decimal? valorInicial = null;
        int? meses = 5;

        // Act
        var result = await _controller.Post(valorInicial, meses, _handler, CancellationToken.None);

        // Assert
        Assert.That(result.Result, Is.InstanceOf<BadRequestObjectResult>());
        var badRequestResult = result.Result as BadRequestObjectResult;
        Assert.That(badRequestResult, Is.Not.Null);
        var response = badRequestResult!.Value as RespostaRequisicao;
        Assert.That(response, Is.Not.Null);
        Assert.That(response!.Sucesso, Is.False);
    }

    [Test]
    [Category("Controllers")]
    public async Task Post_ComMesesNulo_DeveRetornarBadRequest()
    {
        // Arrange
        decimal? valorInicial = 100m;
        int? meses = null;

        // Act
        var result = await _controller.Post(valorInicial, meses, _handler, CancellationToken.None);

        // Assert
        Assert.That(result.Result, Is.InstanceOf<BadRequestObjectResult>());
        var badRequestResult = result.Result as BadRequestObjectResult;
        Assert.That(badRequestResult, Is.Not.Null);
        var response = badRequestResult!.Value as RespostaRequisicao;
        Assert.That(response, Is.Not.Null);
        Assert.That(response!.Sucesso, Is.False);
    }

    [Test]
    [Category("Controllers")]
    public async Task Post_ComValoresZero_DeveRetornarOkComResultadoZero()
    {
        // Arrange
        decimal valorInicial = 0m;
        int meses = 5;

        // Act
        var result = await _controller.Post(valorInicial, meses, _handler, CancellationToken.None);

        // Assert
        Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
        var okResult = result.Result as OkObjectResult;
        Assert.That(okResult, Is.Not.Null);
        var response = okResult!.Value as RespostaRequisicao;
        Assert.That(response, Is.Not.Null);
        Assert.That(response!.Sucesso, Is.True);
        Assert.That(response.Resultado, Is.EqualTo(0.00m));
    }

    [Test]
    [Category("Controllers")]
    public async Task Post_ComValoresGrandes_DeveCalcularCorretamente()
    {
        // Arrange
        decimal valorInicial = 10000m;
        int meses = 12;

        // Act
        var result = await _controller.Post(valorInicial, meses, _handler, CancellationToken.None);

        // Assert
        Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
        var okResult = result.Result as OkObjectResult;
        Assert.That(okResult, Is.Not.Null);
        var response = okResult!.Value as RespostaRequisicao;
        Assert.That(response, Is.Not.Null);
        Assert.That(response!.Sucesso, Is.True);
        Assert.That(response.Resultado, Is.GreaterThan(10000m));
    }
}
