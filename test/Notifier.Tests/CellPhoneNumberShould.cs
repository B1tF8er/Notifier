using Notifier.Models;
using Xunit;

namespace Notifier.Tests
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
    }
}
