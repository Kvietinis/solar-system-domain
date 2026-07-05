using Orbit.Domain.ValueObjects;

namespace Orbit.Domain.DomainEvents
{
    public record TrajectoryOrVelocityChanged : IIsDomainEvent
    {
        public Guid Id { get; init; }

        public Trajectory? Trajectory { get; init; } = Trajectory.FromDouble(0);

        public Velocity? Velocity { get; init; } = Velocity.FromDouble(0);

        public string EventName => nameof(TrajectoryOrVelocityChanged);
    }
}
