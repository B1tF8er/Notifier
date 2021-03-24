using FluentAssertions;
using Moq;
using Notifier.Configuration;
using Notifier.Models;
using Xunit;

namespace Notifier.Tests.Configuration
{
    public class SmsConfigurationShould
    {
        private readonly Mock<SmsConfiguration> sut;

        public SmsConfigurationShould() =>
            sut = new Mock<SmsConfiguration>(
                () => new SmsConfiguration()
            );

        [Fact]
        public void Get_Port_As_CellPhoneNumber_From_String()
        {
            CellPhoneNumber actual = sut.Object.Number;
            CellPhoneNumber expected = "1234567890";

            actual.Should().Be(expected);
        }

        [Fact]
        public void Get_Port_As_CellPhoneNumber_From_Int()
        {
            CellPhoneNumber actual = sut.Object.Number;
            CellPhoneNumber expected = 1234567890;

            actual.Should().Be(expected);
        }

        [Fact]
        public void Get_Port_As_String()
        {
            string actual = sut.Object.Number;
            string expected = "1234567890";

            actual.Should().Be(expected);
        }

        [Fact]
        public void Get_Port_As_Int()
        {
            int actual = sut.Object.Number;
            int expected = 1234567890;

            actual.Should().Be(expected);
        }

        [Fact]
        public void Call_ToString_Once()
        {
            const string Message = "Test";

            sut.Setup(it => it.ToString()).Returns(Message);

            sut.Object.ToString();

            sut.Verify(it => it.ToString(), Times.Once);
        }

        [Fact]
        public void Return_Custom_ToString_Message()
        {
            const string Message = "Test";

            sut.Setup(it => it.ToString()).Returns(Message);

            var actual = sut.Object.ToString();

            actual.Should().Be(Message);
        }
    }
}
