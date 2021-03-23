using FluentAssertions;
using Moq;
using Notifier.Contracts;
using Notifier.Services;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Notifier.Tests
{
    public class SmsNotificationShould
    {
        private readonly Mock<ISmsConfiguration> smsConfiguration;

        private readonly Mock<IMessageWriter> messageWriter;

        private readonly Mock<SmsNotification> sut;

        public SmsNotificationShould()
        {
            smsConfiguration = new Mock<ISmsConfiguration>();
            messageWriter = new Mock<IMessageWriter>();

            sut = new Mock<SmsNotification>(
                smsConfiguration.Object,
                messageWriter.Object
            );
        }

        [Theory]
        [InlineData("")]
        [InlineData(default(string))]
        [InlineData("     ")]
        public void Throw_ArgumentNullException_When_Message_Is_Invalid(string message)
        {
            const string ExpectedMessage = "Cannot be null or empty. (Parameter 'message')";
            Func<Task> send = async () => await sut.Object.Send(message).ConfigureAwait(false);

            send.Should().Throw<ArgumentNullException>().WithMessage(ExpectedMessage);
        }

        [Fact]
        public async void Call_Write_Once()
        {
            const string ConfigurationMessage = "SMS Configuration!";
            const string Message = "Test";
            var messageSent = $"Test via SMS with: {ConfigurationMessage}";

            smsConfiguration.Setup(it => it.ToString()).Returns(ConfigurationMessage);
            messageWriter.Setup(it => it.Write(messageSent)).Returns(Task.CompletedTask);

            await sut.Object.Send(Message).ConfigureAwait(false);

            messageWriter.Verify(it => it.Write(messageSent), Times.Once);
        }
    }
}
