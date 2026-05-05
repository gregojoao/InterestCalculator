using InterestCalculator.Domain.Commands;
using NUnit.Framework;

namespace InterestCalculator.Test.Domain.Commands;

class CalculateInterestCommandTests
{
    [Test]
    [Category("Commands")]
    public void DadoUmComandoInvalidoSemValorParaCalculoESemQuantidadeEmDeMesesORetornoDeveSerInvalidoComNotificacoes()
    {
        var commandInvalid = new CalculateInterestCommand();
        commandInvalid.Validate();
        Assert.That(commandInvalid.IsInvalid && commandInvalid.Notifications.Count == 2, Is.True);
    }

    [Test]
    [Category("Commands")]
    public void DadoUmComandoValidoComValorParaCalculoEComQuantidadeDeMesesORetornoDeveSerValidoSemNotificacoes()
    {
        var commandValid = new CalculateInterestCommand(100m, 5);
        commandValid.Validate();
        Assert.That(commandValid.IsValid && commandValid.Notifications.Count == 0, Is.True);
    }
}