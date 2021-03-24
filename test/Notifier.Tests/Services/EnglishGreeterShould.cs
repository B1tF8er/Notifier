using Moq;
using Notifier.Contracts;
using Notifier.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Notifier.Tests
{
    public class EnglishGreeterShould
    {
        private const string Hello = "Hello World";

        private readonly Mock<INotification> notificationService;

        private readonly Mock<IList<INotification>> notificationServices;

        private readonly Mock<EnglishGreeter> sut;

        public EnglishGreeterShould()
        {
            notificationService = new Mock<INotification>();
            notificationServices = new Mock<IList<INotification>>();

            sut = new Mock<EnglishGreeter>(notificationServices.Object);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public async void Call_Send_Once_Per_Service(int maxNumberOfServices)
        {
            var services = Enumerable.Repeat(notificationService.Object, maxNumberOfServices);

            notificationServices.Setup(it => it.GetEnumerator()).Returns(services.GetEnumerator());
            notificationService.Setup(it => it.Send(Hello)).Returns(Task.CompletedTask);

            await sut.Object.SayHello().ConfigureAwait(false);

            notificationService.Verify(it => it.Send(Hello), Times.Exactly(maxNumberOfServices));
        }
    }
}
