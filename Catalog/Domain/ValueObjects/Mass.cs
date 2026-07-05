namespace Catalog.Domain.ValueObjects
{
    public record Mass
    {
        public double Value { get; init; }

        private Mass(double value)
        {
            Value = value;
        }

        public static Mass FromDouble(double mass)
        {
            // some validation
            return new Mass(mass);
        }
    }
}
