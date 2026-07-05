using Orbit.Domain.DomainEvents;
using Orbit.Domain.ValueObjects;

namespace Orbit.Domain.Aggregates
{
    public class Orbit
    {
        private readonly List<IIsDomainEvent> _events = [];

        public Guid Id { get; private set; } = Guid.NewGuid();

        public Velocity Velocity { get; private set; } = Velocity.FromDouble(0);

        public Trajectory Trajectory { get; private set; } = Trajectory.FromDouble(0);

        public void ChangeTrajectoryOrVelocity(Trajectory? trajectory, Velocity? velocity)
        {
            if (trajectory == null && velocity == null)
            {
                return;
            }

            if (trajectory != null)
            {
                Trajectory = trajectory;
            }

            if (velocity != null)
            {
                Velocity = velocity;
            } 

            _events.Add(new TrajectoryOrVelocityChanged { Id = Id, Trajectory = trajectory, Velocity = velocity });
        }

        public IIsDomainEvent[] GetEvents()
        {
            return [.. _events];
        }
    }
}
