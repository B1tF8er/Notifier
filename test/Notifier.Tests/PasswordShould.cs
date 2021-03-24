using Notifier.Models;
using Xunit;

namespace Notifier.Tests
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
    }
}
