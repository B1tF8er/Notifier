using System;
using Xunit;
using Notifier.Contracts;
using Notifier.Services;
using Moq;
using System.Threading.Tasks;

namespace Notifier.Tests
{
    public class EmailNotificationShould
    {
        private readonly Mock<IEmailConfiguration> emailConfiguration;

        private readonly Mock<IMessageWriter> messageWriter;

        private readonly Mock<EmailNotification> sut;

        public EmailNotificationShould()
        {
            emailConfiguration = new Mock<IEmailConfiguration>();
            messageWriter = new Mock<IMessageWriter>();

            sut = new Mock<EmailNotification>(
                emailConfiguration.Object,
                messageWriter.Object
            );
        }

        [Fact]
        public async void Throw_ArgumentNullException_When_Message_Is_Empty()
        {
            var message = string.Empty;

            await Assert.ThrowsAsync<ArgumentNullException>(() =>
                sut.Object.Send(message)
            );
        }

        [Fact]
        public async void Throw_ArgumentNullException_When_Message_Is_Null()
        {
            string message = default;

            await Assert.ThrowsAsync<ArgumentNullException>(() =>
                sut.Object.Send(message)
            );
        }

        [Fact]
        public async void Throw_ArgumentNullException_When_Message_Is_White_Spaces()
        {
            var message = "     ";

            await Assert.ThrowsAsync<ArgumentNullException>(() =>
                sut.Object.Send(message)
            );
        }

        [Fact]
        public async void Call_Write_Once()
        {
            const string ConfigurationMessage = "EMAIL Configuration!";
            const string Message = "Test";
            var messageSent = $"Test via Email with: {ConfigurationMessage}";

            emailConfiguration.Setup(it => it.ToString()).Returns(ConfigurationMessage);
            messageWriter.Setup(it => it.Write(messageSent)).Returns(Task.CompletedTask);

            await sut.Object.Send(Message).ConfigureAwait(false);

            messageWriter.Verify(it => it.Write(messageSent), Times.Once);
        }
    }
}
