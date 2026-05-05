using InterestCalculator.Domain.Commands;
using NUnit.Framework;

namespace InterestCalculator.Test.Domain.Commands
{
    [TestFixture]
    public class CommandResultTests
    {
        [Test]
        [Category("Commands")]
        public void CommandResult_ComSucesso_DeveArmazenarDadosCorretamente()
        {
            // Arrange & Act
            var result = new CommandResult(true, "Operação realizada com sucesso", 100m);

            // Assert
            Assert.That(result.Sucess, Is.True);
            Assert.That(result.Message, Is.EqualTo("Operação realizada com sucesso"));
            Assert.That(result.Data, Is.EqualTo(100m));
        }

        [Test]
        [Category("Commands")]
        public void CommandResult_ComFalha_DeveArmazenarDadosCorretamente()
        {
            // Arrange & Act
            var result = new CommandResult(false, "Operação falhou", null);

            // Assert
            Assert.That(result.Sucess, Is.False);
            Assert.That(result.Message, Is.EqualTo("Operação falhou"));
            Assert.That(result.Data, Is.Null);
        }

        [Test]
        [Category("Commands")]
        public void CommandResult_ComDadosComplexos_DeveArmazenarCorretamente()
        {
            // Arrange
            var complexData = new { Id = 1, Name = "Test" };

            // Act
            var result = new CommandResult(true, "Dados complexos", complexData);

            // Assert
            Assert.That(result.Sucess, Is.True);
            Assert.That(result.Data, Is.Not.Null);
        }
    }
}
