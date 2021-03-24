using Notifier.Models;
using Xunit;

namespace Notifier.Tests
{
    public class UserShould
    {
        [Fact]
        public void Implicit_Convert_User_From_String()
        {
            User left = "someone";
            string right = left;

            Assert.True(left == right);
        }

        [Fact]
        public void Return_True_When_Users_Are_Equal()
        {
            User left = "someone";
            User right = "someone";

            Assert.True(left == right);
        }

        [Fact]
        public void Return_False_When_Users_Are_Not_Equal()
        {
            User left = "someone";
            User right = "5ome0ne";

            Assert.False(left == right);
        }

        [Fact]
        public void Return_False_When_Users_Are_Equal()
        {
            User left = "someone";
            User right = "someone";

            Assert.False(left != right);
        }

        [Fact]
        public void Return_True_When_Users_Are_Not_Equal()
        {
            User left = "someone";
            User right = "5ome0ne";

            Assert.True(left != right);
        }

        [Fact]
        public void Return_True_When_Both_Users_Are_Equal()
        {
            User left = "someone";
            User right = "someone";

            Assert.True(left.Equals(right));
        }

        [Fact]
        public void Return_User_As_String()
        {
            User left = "someone";
            User right = "someone";

            Assert.True(left.ToString() == right.ToString());
        }

        [Fact]
        public void Return_User_As_HashCode()
        {
            User left = "someone";
            User right = "someone";

            Assert.True(left.GetHashCode() == right.GetHashCode());
        }
    }
}
