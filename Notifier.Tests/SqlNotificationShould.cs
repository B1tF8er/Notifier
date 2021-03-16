using System;
using Xunit;
using Notifier.Contracts;
using Notifier.Services;
using Moq;
using System.Threading.Tasks;

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
        [InlineData("")]
        [InlineData(default(string))]
        [InlineData("     ")]
        public async void Throw_ArgumentNullException_When_Message_Is_Invalid(string message)
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() =>
                sut.Object.Send(message)
            );
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
