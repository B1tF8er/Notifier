using System;
using Xunit;
using Notifier.Contracts;
using Notifier.Services;
using Moq;

namespace Notifier.Tests
{
    public class SqlNotificationShould
    {
        private readonly Mock<ISqlConfiguration> sqlConfiguration;

        private readonly Mock<SqlNotification> sut;

        public SqlNotificationShould()
        {
            sqlConfiguration = new Mock<ISqlConfiguration>();

            sut = new Mock<SqlNotification>(sqlConfiguration.Object);
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
