using FluentAssertions;
using Moq;
using Notifier.Configuration;
using Notifier.Models;
using Xunit;

namespace Notifier.Tests.Configuration
{
    public class SqlConfigurationShould
    {
        private readonly Mock<SqlConfiguration> sut;

        public SqlConfigurationShould() =>
            sut = new Mock<SqlConfiguration>(
                () => new SqlConfiguration()
            );

        [Fact]
        public void Get_Port_As_SqlServerPort()
        {
            SqlServerPort actual = sut.Object.Port;
            SqlServerPort expected = 443;

            actual.Should().Be(expected);
        }

        [Fact]
        public void Get_Port_As_Int()
        {
            int actual = sut.Object.Port;
            int expected = 443;

            actual.Should().Be(expected);
        }

        [Fact]
        public void Get_Server_As_Server()
        {
            Server actual = sut.Object.Server;
            Server expected = "localhost";

            actual.Should().Be(expected);
        }

        [Fact]
        public void Get_Server_As_String()
        {
            string actual = sut.Object.Server;
            string expected = "localhost";

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
