using FluentAssertions;
using Moq;
using Notifier.Contracts;
using Notifier.Services;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Notifier.Tests.Services
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

        [Theory]
        [MemberData(nameof(NotificationData.Messages), MemberType = typeof(NotificationData))]
        public void Throw_ArgumentNullException_When_Message_Is_Invalid(string message, string expected)
        {
            Func<Task> send = async () => await sut.Object.Send(message).ConfigureAwait(false);

            send.Should().Throw<ArgumentNullException>().WithMessage(expected);
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
