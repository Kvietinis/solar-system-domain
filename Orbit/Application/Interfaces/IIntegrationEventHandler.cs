namespace Orbit.Application.Interfaces
{
    public interface IIntegrationEventHandler<T>
    {
        Task Handle(T message);
    }
}
