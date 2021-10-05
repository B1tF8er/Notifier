using FluentAssertions;
using Notifier.Models;
using System;
using Xunit;

namespace Notifier.Tests.Models
{
    public class SmptPortShould
    {
        [Fact]
        public void Implicit_Convert_SmptPort_From_Int()
        {
            SmtpPort left = 2525;
            int right = left;

            Assert.True(left == right);
        }

        [Fact]
        public void Return_True_When_SmptPorts_Are_Equal()
        {
            SmtpPort left = 2525;
            SmtpPort right = 2525;

            Assert.True(left == right);
        }

        [Fact]
        public void Return_False_When_SmptPorts_Are_Not_Equal()
        {
            SmtpPort left = 2525;
            SmtpPort right = 587;

            Assert.False(left == right);
        }

        [Fact]
        public void Return_False_When_SmptPorts_Are_Equal()
        {
            SmtpPort left = 2525;
            SmtpPort right = 2525;

            Assert.False(left != right);
        }

        [Fact]
        public void Return_True_When_SmptPorts_Are_Not_Equal()
        {
            SmtpPort left = 2525;
            SmtpPort right = 587;

            Assert.True(left != right);
        }

        [Fact]
        public void Return_True_When_Both_SmptPorts_Are_Equal()
        {
            SmtpPort left = 2525;
            SmtpPort right = 2525;

            Assert.True(left.Equals(right));
        }

        [Fact]
        public void Return_SmptPort_As_String()
        {
            SmtpPort left = 2525;
            SmtpPort right = 2525;

            Assert.True(left.ToString() == right.ToString());
        }

        [Fact]
        public void Return_SmptPort_As_HashCode()
        {
            SmtpPort left = 2525;
            SmtpPort right = 2525;

            Assert.True(left.GetHashCode() == right.GetHashCode());
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void Throw_ArgumentOutOfRangeException_When_SmptPort_Is_Invalid(int smptPort)
        {
            Func<SmtpPort> create = () => SmtpPort.Create(smptPort);

            create.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
