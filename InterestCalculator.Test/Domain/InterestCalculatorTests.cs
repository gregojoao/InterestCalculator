using InterestCalculator.Domain.Notifications.Entities;
using NUnit.Framework;

namespace InterestCalculator.Test.Domain;

[TestFixture]
public class InterestCalculatorTests
{
    [Test]
    [Category("Domain")]
    public void Calculate_ComTaxaZero_DeveRetornarValorInicial()
    {
        // Arrange
        var calculator = new InterestCalculator.Domain.InterestCalculator(0m);

        // Act
        var result = calculator.Calculate(100m, 5);

        // Assert - Com taxa 0, (1+0)^5 = 1, então 100 * 1 = 100
        Assert.That(result, Is.EqualTo(100m));
    }

    [Test]
    [Category("Domain")]
    public void Calculate_ComMesesZero_DeveRetornarValorInicial()
    {
        // Arrange
        var calculator = new InterestCalculator.Domain.InterestCalculator(0.01m);

        // Act
        var result = calculator.Calculate(100m, 0);

        // Assert
        Assert.That(result, Is.EqualTo(100m));
    }

    [Test]
    [Category("Domain")]
    public void Calculate_ComValoresPositivos_DeveCalcularCorretamente()
    {
        // Arrange
        var calculator = new InterestCalculator.Domain.InterestCalculator(0.01m);

        // Act
        var result = calculator.Calculate(100m, 5);

        // Assert
        Assert.That(result, Is.EqualTo(105.10m));
    }

    [Test]
    [Category("Domain")]
    public void Calculate_DeveTruncarParaDuasCasasDecimais()
    {
        // Arrange
        var calculator = new InterestCalculator.Domain.InterestCalculator(0.01m);

        // Act
        var result = calculator.Calculate(100.0123m, 5);

        // Assert
        Assert.That(result, Is.EqualTo(105.11m));
    }

    [Test]
    [Category("Domain")]
    public void Calculate_ComValorGrande_DeveCalcularCorretamente()
    {
        // Arrange
        var calculator = new InterestCalculator.Domain.InterestCalculator(0.01m);

        // Act
        var result = calculator.Calculate(10000m, 12);

        // Assert
        Assert.That(result, Is.GreaterThan(10000m));
        Assert.That(result, Is.LessThan(11300m));
    }

    [Test]
    [Category("Domain")]
    public void InterestRate_DeveArmazenarTaxaCorretamente()
    {
        // Arrange & Act
        var calculator = new InterestCalculator.Domain.InterestCalculator(0.05m);

        // Assert
        Assert.That(calculator.InterestRate, Is.EqualTo(0.05m));
    }

    [Test]
    [Category("Domain")]
    public void Calculate_ComMuitosMeses_DeveCalcularCorretamente()
    {
        // Arrange
        var calculator = new InterestCalculator.Domain.InterestCalculator(0.01m);

        // Act
        var result = calculator.Calculate(1000m, 24);

        // Assert
        Assert.That(result, Is.GreaterThan(1000m));
        Assert.That(result, Is.LessThan(1300m));
    }
}
