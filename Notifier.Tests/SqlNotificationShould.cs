using FluentAssertions;
using Moq;
using Notifier.Contracts;
using Notifier.Services;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Notifier.Tests
{
    public class SqlNotificationShould
    {
        private readonly Mock<ISqlConfiguration> sqlConfiguration;

        private readonly Mock<IMessageWriter> messageWriter;

        private readonly Mock<SqlNotification> sut;

        public SqlNotificationShould()
        {
            sqlConfiguration = new Mock<ISqlConfiguration>();
            messageWriter = new Mock<IMessageWriter>();

            sut = new Mock<SqlNotification>(
                sqlConfiguration.Object,
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
            const string ConfigurationMessage = "SQL Configuration!";
            const string Message = "Test";
            var messageSent = $"Test via SQL with: {ConfigurationMessage}";

            sqlConfiguration.Setup(it => it.ToString()).Returns(ConfigurationMessage);
            messageWriter.Setup(it => it.Write(messageSent)).Returns(Task.CompletedTask);

            await sut.Object.Send(Message).ConfigureAwait(false);

            messageWriter.Verify(it => it.Write(messageSent), Times.Once);
        }
    }
}
