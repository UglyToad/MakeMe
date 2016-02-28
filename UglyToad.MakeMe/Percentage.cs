namespace UglyToad.MakeMe
{
    using System;

    public struct Percentage
    {
        public const int MinimumValue = 0;
        public const int MaximumValue = 100;

        public static readonly Percentage Maximum = new Percentage(MaximumValue);
        public static readonly Percentage Minimum = new Percentage(MinimumValue);

        public int Value { get; }

        public Percentage(int percentage)
        {
            if (percentage < MinimumValue)
            {
                Value = MinimumValue;
            }
            else if (percentage > MaximumValue)
            {
                Value = MaximumValue;
            }
            else
            {
                Value = percentage;
            }
        }

        public bool Met(Random random)
        {
            if (Value == MinimumValue)
            {
                return false;
            }

            if (Value == MaximumValue)
            {
                return true;
            }
            
            return random.Next(MinimumValue, MaximumValue) <= Value;
        }

        public bool Equals(Percentage other)
        {
            return Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (obj is Percentage)
            {
                return Equals((Percentage) obj);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public static bool operator ==(Percentage a, Percentage b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Percentage a, Percentage b)
        {
            return !(a == b);
        }
    }
}