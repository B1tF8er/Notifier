using FluentAssertions;
using Notifier.Models;
using System;
using Xunit;

namespace Notifier.Tests
{
    public class SqlServerPortShould
    {
        [Fact]
        public void Implicit_Convert_SqlServerPort_From_Int()
        {
            SqlServerPort left = 443;
            int right = left;

            Assert.True(left == right);
        }

        [Fact]
        public void Return_True_When_SqlServerPorts_Are_Equal()
        {
            SqlServerPort left = 443;
            SqlServerPort right = 443;

            Assert.True(left == right);
        }

        [Fact]
        public void Return_False_When_SqlServerPorts_Are_Not_Equal()
        {
            SqlServerPort left = 443;
            SqlServerPort right = 135;

            Assert.False(left == right);
        }

        [Fact]
        public void Return_False_When_SqlServerPorts_Are_Equal()
        {
            SqlServerPort left = 443;
            SqlServerPort right = 443;

            Assert.False(left != right);
        }

        [Fact]
        public void Return_True_When_SqlServerPorts_Are_Not_Equal()
        {
            SqlServerPort left = 443;
            SqlServerPort right = 135;

            Assert.True(left != right);
        }

        [Fact]
        public void Return_True_When_Both_SqlServerPorts_Are_Equal()
        {
            SqlServerPort left = 443;
            SqlServerPort right = 443;

            Assert.True(left.Equals(right));
        }

        [Fact]
        public void Return_SqlServerPort_As_String()
        {
            SqlServerPort left = 443;
            SqlServerPort right = 443;

            Assert.True(left.ToString() == right.ToString());
        }

        [Fact]
        public void Return_SqlServerPort_As_HashCode()
        {
            SqlServerPort left = 443;
            SqlServerPort right = 443;

            Assert.True(left.GetHashCode() == right.GetHashCode());
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void Throw_ArgumentOutOfRangeException_When_SqlServerPort_Is_Invalid(int sqlServerPort)
        {
            Func<SqlServerPort> create = () => SqlServerPort.Create(sqlServerPort);

            create.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
