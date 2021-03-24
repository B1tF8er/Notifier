using FluentAssertions;
using Notifier.Models;
using System;
using Xunit;

namespace Notifier.Tests.Models
{
    public class CellPhoneNumberShould
    {
        [Fact]
        public void Implicit_Convert_CellPhoneNumber_From_String()
        {
            CellPhoneNumber left = "1234567890";
            string right = left;

            Assert.True(left == right);
        }

        [Fact]
        public void Implicit_Convert_CellPhoneNumber_From_Int()
        {
            CellPhoneNumber left = 1234567890;
            int right = left;

            Assert.True(left == right);
        }

        [Fact]
        public void Return_True_When_CellPhoneNumbers_Are_Equal()
        {
            CellPhoneNumber left = 1234567890;
            CellPhoneNumber right = 1234567890;

            Assert.True(left == right);
        }

        [Fact]
        public void Return_False_When_CellPhoneNumbers_Are_Not_Equal()
        {
            CellPhoneNumber left = 1234567890;
            CellPhoneNumber right = 1234567891;

            Assert.False(left == right);
        }

        [Fact]
        public void Return_False_When_CellPhoneNumbers_Are_Equal()
        {
            CellPhoneNumber left = 1234567890;
            CellPhoneNumber right = 1234567890;

            Assert.False(left != right);
        }

        [Fact]
        public void Return_True_When_CellPhoneNumbers_Are_Not_Equal()
        {
            CellPhoneNumber left = 1234567890;
            CellPhoneNumber right = 1234567891;

            Assert.True(left != right);
        }

        [Fact]
        public void Return_True_When_Both_CellPhoneNumbers_Are_Equal()
        {
            CellPhoneNumber left = "1234567890";
            CellPhoneNumber right = "1234567890";

            Assert.True(left.Equals(right));
        }

        [Fact]
        public void Return_CellPhoneNumber_As_String()
        {
            CellPhoneNumber left = "1234567890";
            CellPhoneNumber right = "1234567890";

            Assert.True(left.ToString() == right.ToString());
        }

        [Fact]
        public void Return_CellPhoneNumber_As_HashCode()
        {
            CellPhoneNumber left = "1234567890";
            CellPhoneNumber right = "1234567890";

            Assert.True(left.GetHashCode() == right.GetHashCode());
        }

        [Theory]
        [InlineData(default(string))]
        [InlineData("")]
        [InlineData("     ")]
        public void Throw_ArgumentNullException_When_CellPhoneNumber_Is_Invalid(string cellPhoneNumber)
        {
            Func<CellPhoneNumber> create = () => CellPhoneNumber.Create(cellPhoneNumber);

            create.Should().Throw<ArgumentNullException>();
        }

        [Theory]
        [InlineData("1")]
        [InlineData("12")]
        [InlineData("123")]
        [InlineData("1234")]
        [InlineData("12345")]
        [InlineData("123456")]
        [InlineData("1234567")]
        [InlineData("12345678")]
        [InlineData("123456789")]
        public void Throw_InvalidOperationException_When_CellPhoneNumber_Is_Not_Ten_Digits_Long(string cellPhoneNumber)
        {
            Func<CellPhoneNumber> create = () => CellPhoneNumber.Create(cellPhoneNumber);

            create.Should().Throw<InvalidOperationException>();
        }

        [Theory]
        [InlineData("1234567890a")]
        [InlineData("a1234567890")]
        [InlineData("abcdefghij")]
        public void Throw_FormatException_When_CellPhoneNumber_Has_Invalid_Format(string cellPhoneNumber)
        {
            Func<CellPhoneNumber> create = () => CellPhoneNumber.Create(cellPhoneNumber);

            create.Should().Throw<FormatException>();
        }
    }
}
