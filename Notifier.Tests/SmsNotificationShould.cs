using System;
using Xunit;
using Notifier.Contracts;
using Notifier.Services;
using Moq;

namespace Notifier.Tests
{
    public class SmsNotificationShould
    {
        private readonly Mock<ISmsConfiguration> smsConfiguration;

        private readonly Mock<SmsNotification> sut;

        public SmsNotificationShould()
        {
            smsConfiguration = new Mock<ISmsConfiguration>();

            sut = new Mock<SmsNotification>(smsConfiguration.Object);
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
