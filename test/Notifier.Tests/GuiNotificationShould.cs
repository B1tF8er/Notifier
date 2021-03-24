using FluentAssertions;
using Moq;
using Notifier.Contracts;
using Notifier.Services;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Notifier.Tests
{
    public class GuiNotificationShould
    {
        private readonly Mock<IMessageWriter> messageWriter;

        private readonly Mock<GuiNotification> sut;

        public GuiNotificationShould()
        {
            messageWriter = new Mock<IMessageWriter>();

            sut = new Mock<GuiNotification>(messageWriter.Object);
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
            const string Message = "Test";
            const string MessageSent = "Test via GUI";

            messageWriter.Setup(it => it.Write(MessageSent)).Returns(Task.CompletedTask);

            await sut.Object.Send(Message).ConfigureAwait(false);

            messageWriter.Verify(it => it.Write(MessageSent), Times.Once);
        }
    }
}
