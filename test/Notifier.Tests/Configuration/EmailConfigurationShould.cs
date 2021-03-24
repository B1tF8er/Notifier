using FluentAssertions;
using Moq;
using Notifier.Configuration;
using Notifier.Models;
using Xunit;

namespace Notifier.Tests.Configuration
{
    public class EmailConfigurationShould
    {
        private readonly Mock<EmailConfiguration> sut;

        public EmailConfigurationShould() =>
            sut = new Mock<EmailConfiguration>(
                () => new EmailConfiguration()
            );

        [Fact]
        public void Get_Port_As_SmptPort()
        {
            SmptPort actual = sut.Object.Port;
            SmptPort expected = 2525;

            actual.Should().Be(expected);
        }

        [Fact]
        public void Get_Port_As_Int()
        {
            int actual = sut.Object.Port;
            int expected = 2525;

            actual.Should().Be(expected);
        }

        [Fact]
        public void Get_FromAddress_As_EmailAddress()
        {
            EmailAddress actual = sut.Object.FromAddress;
            EmailAddress expected = "some@domain.com";

            actual.Should().Be(expected);
        }

        [Fact]
        public void Get_FromAddress_As_String()
        {
            string actual = sut.Object.FromAddress;
            string expected = "some@domain.com";

            actual.Should().Be(expected);
        }

        [Fact]
        public void Get_ToAddress_As_EmailAddress()
        {
            EmailAddress actual = sut.Object.ToAddress;
            EmailAddress expected = "other@domain.com";

            actual.Should().Be(expected);
        }

        [Fact]
        public void Get_ToAddress_As_String()
        {
            string actual = sut.Object.ToAddress;
            string expected = "other@domain.com";

            actual.Should().Be(expected);
        }

        [Fact]
        public void Get_User_As_User()
        {
            User actual = sut.Object.User;
            User expected = "someone";

            actual.Should().Be(expected);
        }

        [Fact]
        public void Get_User_As_String()
        {
            string actual = sut.Object.User;
            string expected = "someone";

            actual.Should().Be(expected);
        }

        [Fact]
        public void Get_Password_As_Password()
        {
            Password actual = sut.Object.Password;
            Password expected = "5up3r53cur3";

            actual.Should().Be(expected);
        }

        [Fact]
        public void Get_Password_As_String()
        {
            string actual = sut.Object.Password;
            string expected = "5up3r53cur3";

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
