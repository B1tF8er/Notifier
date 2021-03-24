using Moq;
using Notifier.Contracts;
using Notifier.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Notifier.Tests.Services
{
    public class SpanishGreeterShould
    {
        private const string Hello = "Hola Mundo";

        private readonly Mock<INotification> notificationService;

        private readonly Mock<IList<INotification>> notificationServices;

        private readonly Mock<SpanishGreeter> sut;

        public SpanishGreeterShould()
        {
            notificationService = new Mock<INotification>();
            notificationServices = new Mock<IList<INotification>>();

            sut = new Mock<SpanishGreeter>(notificationServices.Object);
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
