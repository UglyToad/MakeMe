namespace UglyToad.MakeMe.Specification.Integer
{
    /// <summary>
    /// Specification for generating <see cref="int"/>s. Defaults to random numbers between 0 and 100.
    /// </summary>
    public class IntegerSpecification : ISpecification<int>
    {
        internal int Maximum { get; private set; } = 100;

        internal int Minimum { get; private set; } = 0;

        internal bool UseNormal { get; private set; } = false;

        /// <summary>
        /// Set the maximum inclusive value to generate numbers for.
        /// Where this is lower than the configured minimum, the configured minimum will set itself to the maximum passed in.
        /// </summary>
        /// <param name="maximum">The upper limit on generated numbers.</param>
        /// <returns>A <see cref="IntegerSpecification"/>.</returns>
        public IntegerSpecification WithMaximum(int maximum)
        {
            if (maximum < Minimum)
            {
                Minimum = maximum;
            }

            Maximum = maximum;

            return this;
        }

        /// <summary>
        /// Sets the minimum inclusive value to generate numbers for.
        /// Where this is higher than the maximum the maximum will be set to this minimum.
        /// </summary>
        /// <param name="minimum">The lower limit on generated numbers.</param>
        /// <returns>A <see cref="IntegerSpecification"/>.</returns>
        public IntegerSpecification WithMinimum(int minimum)
        {
            if (minimum > Maximum)
            {
                Maximum = minimum;
            }

            Minimum = minimum;

            return this;
        }

        /// <summary>
        /// Generates the random number according to a normal distribution defined between the minimum and maximum.
        /// Because values are clamped by minimum and maximum you should not use this for statistically meaningful data, only random test data.
        /// The mean of the distribution will be at the midpoint between the minimum and maximum.
        /// </summary>
        /// <param name="useNormal">Use a normal distribution to generate numbers if true. Standard random number generator if false.</param>
        /// <returns>A <see cref="IntegerSpecification"/>.</returns>
        public IntegerSpecification UseNormalDistribution(bool useNormal)
        {
            UseNormal = useNormal;
            return this;
        }
    }
}
