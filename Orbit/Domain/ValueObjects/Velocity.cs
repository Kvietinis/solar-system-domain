namespace Orbit.Domain.ValueObjects
{
    public record Velocity
    {
        public double Value { get; init; }

        private Velocity(double value)
        {
            Value = value;
        }

        public static Velocity FromDouble(double mass)
        {
            // some validation
            return new Velocity(mass);
        }
    }
}
