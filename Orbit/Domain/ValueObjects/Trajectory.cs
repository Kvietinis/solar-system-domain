namespace Orbit.Domain.ValueObjects
{
    public record Trajectory
    {
        public double Value { get; init; }

        private Trajectory(double value)
        {
            Value = value;
        }

        public static Trajectory FromDouble(double mass)
        {
            // some validation
            return new Trajectory(mass);
        }
    }
}
