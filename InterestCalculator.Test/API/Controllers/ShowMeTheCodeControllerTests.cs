using InterestCalculator.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace InterestCalculator.Test.API.Controllers;

[TestFixture]
public class ShowMeTheCodeControllerTests
{
    private ShowMeTheCodeController _controller = null!;

    [SetUp]
    public void Setup()
    {
        _controller = new ShowMeTheCodeController();
    }

    [Test]
    [Category("Controllers")]
    public void Get_DeveRetornarUrlDoRepositorio()
    {
        // Act
        var result = _controller.Get();

        // Assert
        Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
        var okResult = result.Result as OkObjectResult;
        Assert.That(okResult, Is.Not.Null);
        Assert.That(okResult!.Value, Is.EqualTo("https://github.com/grecojoao/InterestCalculator"));
    }

    [Test]
    [Category("Controllers")]
    public void Get_DeveRetornarString()
    {
        // Act
        var result = _controller.Get();

        // Assert
        Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
        var okResult = result.Result as OkObjectResult;
        Assert.That(okResult, Is.Not.Null);
        Assert.That(okResult!.Value, Is.TypeOf<string>());
    }

    [Test]
    [Category("Controllers")]
    public void Get_DeveRetornarUrlValida()
    {
        // Act
        var result = _controller.Get();

        // Assert
        var okResult = result.Result as OkObjectResult;
        var url = okResult!.Value as string;
        Assert.That(url, Does.StartWith("https://"));
        Assert.That(url, Does.Contain("github.com"));
    }
}
