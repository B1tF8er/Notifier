using FluentAssertions;
using Notifier.Models;
using System;
using Xunit;

namespace Notifier.Tests.Models
{
    public class PasswordShould
    {
        [Fact]
        public void Implicit_Convert_Password_From_String()
        {
            Password left = "5up3r53cur3";
            string right = left;

            Assert.True(left == right);
        }

        [Fact]
        public void Return_True_When_Passwords_Are_Equal()
        {
            Password left = "5up3r53cur3";
            Password right = "5up3r53cur3";

            Assert.True(left == right);
        }

        [Fact]
        public void Return_False_When_Passwords_Are_Not_Equal()
        {
            Password left = "5up3r53cur3";
            Password right = "SuperSecure";

            Assert.False(left == right);
        }

        [Fact]
        public void Return_False_When_Passwords_Are_Equal()
        {
            Password left = "5up3r53cur3";
            Password right = "5up3r53cur3";

            Assert.False(left != right);
        }

        [Fact]
        public void Return_True_When_Passwords_Are_Not_Equal()
        {
            Password left = "5up3r53cur3";
            Password right = "SuperSecure";

            Assert.True(left != right);
        }

        [Fact]
        public void Return_True_When_Both_Passwords_Are_Equal()
        {
            Password left = "5up3r53cur3";
            Password right = "5up3r53cur3";

            Assert.True(left.Equals(right));
        }

        [Fact]
        public void Return_Password_As_String()
        {
            Password left = "5up3r53cur3";
            Password right = "5up3r53cur3";

            Assert.True(left.ToString() == right.ToString());
        }

        [Fact]
        public void Return_Password_As_HashCode()
        {
            Password left = "5up3r53cur3";
            Password right = "5up3r53cur3";

            Assert.True(left.GetHashCode() == right.GetHashCode());
        }

        [Theory]
        [InlineData(default(string))]
        [InlineData("")]
        [InlineData("     ")]
        public void Throw_ArgumentNullException_When_Password_Is_Invalid(string password)
        {
            Func<Password> create = () => Password.Create(password);

            create.Should().Throw<ArgumentNullException>();
        }

        [Theory]
        [InlineData("a")]
        [InlineData("ab")]
        [InlineData("abc")]
        [InlineData("abcd")]
        [InlineData("abcde")]
        [InlineData("abcdef")]
        [InlineData("abcdefg")]
        [InlineData("abcdefgh")]
        [InlineData("abcdefghi")]
        public void Throw_InvalidOperationException_When_Password_Is_Not_Ten_Digits_Long(string password)
        {
            Func<Password> create = () => Password.Create(password);

            create.Should().Throw<InvalidOperationException>();
        }
    }
}
