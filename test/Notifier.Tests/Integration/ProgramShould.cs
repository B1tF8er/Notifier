using Xunit;

namespace Notifier.Tests.Integration
{
    public class ProgramShould
    {
        [Fact]
        public async void RunSmoothly() => await Program.Main().ConfigureAwait(false);
    }
}
