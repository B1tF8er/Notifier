using Moq;
using Notifier.Services;
using System;
using Xunit;

namespace Notifier.Tests
{
    public class GuiNotificationShould
    {
        private readonly Mock<GuiNotification> sut;

        public GuiNotificationShould()
        {
            sut = new Mock<GuiNotification>();
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
    }
}
