using ThreatAssessment.Application.Interfaces;

namespace ThreatAssessment.Infrastructure
{
    public class RabbitPublisher : IPublisher
    {
        public Task Publish<T>(T message)
        {
            // publishes message via RabbitMQ

            throw new NotImplementedException();
        }
    }
}
