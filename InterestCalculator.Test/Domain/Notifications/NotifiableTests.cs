using InterestCalculator.Domain.Notifications;
using InterestCalculator.Domain.Notifications.Entities;
using NUnit.Framework;

namespace InterestCalculator.Test.Domain.Notifications
{
    [TestFixture]
    public class NotifiableTests
    {
        private class TestNotifiable : Notifiable
        {
        }

        [Test]
        [Category("Notifications")]
        public void AddNotification_DeveAdicionarNotificacao()
        {
            // Arrange
            var notifiable = new TestNotifiable();
            var notification = new Notification("Campo", "Mensagem de erro");

            // Act
            notifiable.AddNotification(notification);

            // Assert
            Assert.That(notifiable.Notifications.Count, Is.EqualTo(1));
            Assert.That(notifiable.IsInvalid, Is.True);
            Assert.That(notifiable.IsValid, Is.False);
        }

        [Test]
        [Category("Notifications")]
        public void AddNotification_ComMultiplasNotificacoes_DeveAdicionarTodas()
        {
            // Arrange
            var notifiable = new TestNotifiable();

            // Act
            notifiable.AddNotification(new Notification("Campo1", "Erro 1"));
            notifiable.AddNotification(new Notification("Campo2", "Erro 2"));
            notifiable.AddNotification(new Notification("Campo3", "Erro 3"));

            // Assert
            Assert.That(notifiable.Notifications.Count, Is.EqualTo(3));
            Assert.That(notifiable.IsInvalid, Is.True);
        }

        [Test]
        [Category("Notifications")]
        public void NotificationsMessage_DeveRetornarMensagensConcatenadas()
        {
            // Arrange
            var notifiable = new TestNotifiable();
            notifiable.AddNotification(new Notification("Campo1", "Erro 1"));
            notifiable.AddNotification(new Notification("Campo2", "Erro 2"));

            // Act
            var message = notifiable.NotificationsMessage();

            // Assert
            Assert.That(message, Does.Contain("Erro 1"));
            Assert.That(message, Does.Contain("Erro 2"));
        }

        [Test]
        [Category("Notifications")]
        public void IsValid_SemNotificacoes_DeveRetornarTrue()
        {
            // Arrange
            var notifiable = new TestNotifiable();

            // Assert
            Assert.That(notifiable.IsValid, Is.True);
            Assert.That(notifiable.IsInvalid, Is.False);
            Assert.That(notifiable.Notifications.Count, Is.EqualTo(0));
        }

        [Test]
        [Category("Notifications")]
        public void Notification_DeveTerPropriedadesCorretas()
        {
            // Arrange & Act
            var notification = new Notification("TestField", "Test message");

            // Assert
            Assert.That(notification.Property, Is.EqualTo("TestField"));
            Assert.That(notification.Message, Is.EqualTo("Test message"));
        }
    }
}
