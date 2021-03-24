using FluentAssertions;
using Notifier.Models;
using System;
using Xunit;

namespace Notifier.Tests.Models
{
    public class ServerShould
    {
        [Fact]
        public void Implicit_Convert_Server_From_String()
        {
            Server left = "localhost";
            string right = left;

            Assert.True(left == right);
        }

        [Fact]
        public void Return_True_When_Servers_Are_Equal()
        {
            Server left = "localhost";
            Server right = "localhost";

            Assert.True(left == right);
        }

        [Fact]
        public void Return_False_When_Servers_Are_Not_Equal()
        {
            Server left = "localhost";
            Server right = "some-server";

            Assert.False(left == right);
        }

        [Fact]
        public void Return_False_When_Servers_Are_Equal()
        {
            Server left = "localhost";
            Server right = "localhost";

            Assert.False(left != right);
        }

        [Fact]
        public void Return_True_When_Servers_Are_Not_Equal()
        {
            Server left = "localhost";
            Server right = "some-server";

            Assert.True(left != right);
        }

        [Fact]
        public void Return_True_When_Both_Servers_Are_Equal()
        {
            Server left = "localhost";
            Server right = "localhost";

            Assert.True(left.Equals(right));
        }

        [Fact]
        public void Return_Server_As_String()
        {
            Server left = "localhost";
            Server right = "localhost";

            Assert.True(left.ToString() == right.ToString());
        }

        [Fact]
        public void Return_Server_As_HashCode()
        {
            Server left = "localhost";
            Server right = "localhost";

            Assert.True(left.GetHashCode() == right.GetHashCode());
        }

        [Theory]
        [InlineData(default(string))]
        [InlineData("")]
        [InlineData("     ")]
        public void Throw_ArgumentNullException_When_Server_Is_Invalid(string server)
        {
            Func<Server> create = () => Server.Create(server);

            create.Should().Throw<ArgumentNullException>();
        }
    }
}
