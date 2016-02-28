namespace UglyToad.MakeMe
{
    using System;

    /// <summary>
    /// A data type used to represent the probability of something happening on a 0-100 percent scale.
    /// </summary>
    internal struct Percentage
    {
        /// <summary>
        /// There is no probability of something with this percentage occuring.
        /// </summary>
        public const int MinimumValue = 0;
        /// <summary>
        /// Something with this percentage will always occur.
        /// </summary>
        public const int MaximumValue = 100;

        /// <summary>
        ///  Something with this percentage will always occur.
        /// </summary>
        public static readonly Percentage Maximum = new Percentage(MaximumValue);
        /// <summary>
        /// There is no probability of something with this percentage occuring.
        /// </summary>
        public static readonly Percentage Minimum = new Percentage(MinimumValue);

        /// <summary>
        /// The percentage as an <see cref="int"/>.
        /// </summary>
        public int Value { get; }

        /// <summary>
        /// Create a new percentage with the given chance. The value will always be clamped in the range 0-100.
        /// </summary>
        /// <param name="percentage">The chance represented by this percentage.</param>
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

        /// <summary>
        /// For a given random number generator will return true approximately ~value% of the time.
        /// </summary>
        /// <param name="random">The random number generator to use.</param>
        /// <returns>True on value% of occasions. For example if value = 70 then this method should return true approximately 70% of the time.</returns>
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

        /// <summary>
        /// Equality comparison.
        /// </summary>
        /// <param name="other">The other percentage to compare.</param>
        /// <returns>True if the percentages are equal.</returns>
        public bool Equals(Percentage other)
        {
            return Value == other.Value;
        }

        /// <summary>
        /// Equality comparison.
        /// </summary>
        /// <param name="obj">The object to compare this percentage to.</param>
        /// <returns>True if the object represents an equal percentage, false otherwise.</returns>
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

        /// <summary>
        /// Generates hash code.
        /// </summary>
        /// <returns>The hash code.</returns>
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        /// <summary>
        /// Equality operator.
        /// </summary>
        /// <param name="a">Left hand operand.</param>
        /// <param name="b">Right hand operand.</param>
        /// <returns>Returns false if its operands are equal, true otherwise.</returns>
        public static bool operator ==(Percentage a, Percentage b)
        {
            return a.Equals(b);
        }

        /// <summary>
        /// Inequality operator.
        /// </summary>
        /// <param name="a">Left hand operand.</param>
        /// <param name="b">Right hand operand.</param>
        /// <returns>Returns false if its operands are equal, true otherwise.</returns>
        public static bool operator !=(Percentage a, Percentage b)
        {
            return !(a == b);
        }
    }
}