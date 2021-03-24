using Notifier.Models;
using Xunit;

namespace Notifier.Tests
{
    public class EmailAddressShould
    {
        [Fact]
        public void Implicit_Convert_EmailAddress_From_String()
        {
            EmailAddress left = "some@domain.com";
            string right = left;

            Assert.True(left == right);
        }

        [Fact]
        public void Return_True_When_EmailAddresses_Are_Equal()
        {
            EmailAddress left = "some@domain.com";
            EmailAddress right = "some@domain.com";

            Assert.True(left == right);
        }

        [Fact]
        public void Return_False_When_EmailAddresses_Are_Not_Equal()
        {
            EmailAddress left = "some@domain.com";
            EmailAddress right = "other@domain.com";

            Assert.False(left == right);
        }

        [Fact]
        public void Return_False_When_EmailAddresses_Are_Equal()
        {
            EmailAddress left = "some@domain.com";
            EmailAddress right = "some@domain.com";

            Assert.False(left != right);
        }

        [Fact]
        public void Return_True_When_EmailAddresses_Are_Not_Equal()
        {
            EmailAddress left = "some@domain.com";
            EmailAddress right = "other@domain.com";

            Assert.True(left != right);
        }

        [Fact]
        public void Return_True_When_Both_EmailAddresses_Are_Equal()
        {
            EmailAddress left = "some@domain.com";
            EmailAddress right = "some@domain.com";

            Assert.True(left.Equals(right));
        }

        [Fact]
        public void Return_EmailAddress_As_String()
        {
            EmailAddress left = "some@domain.com";
            EmailAddress right = "some@domain.com";

            Assert.True(left.ToString() == right.ToString());
        }

        [Fact]
        public void Return_EmailAddress_As_HashCode()
        {
            EmailAddress left = "some@domain.com";
            EmailAddress right = "some@domain.com";

            Assert.True(left.GetHashCode() == right.GetHashCode());
        }
    }
}
