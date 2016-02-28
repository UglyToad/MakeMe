namespace UglyToad.MakeMe.Makers
{
    using System;

    /// <summary>
    /// Represents a class which generates test data based on a specification.
    /// </summary>
    /// <typeparam name="TGenerated">The type of test data to generate.</typeparam>
    internal abstract class Maker<TGenerated>
    {
        // ReSharper disable once MemberCanBePrivate.Global
        /// <summary>
        /// The specification for this class.
        /// </summary>
        protected readonly ISpecification<TGenerated> Specification;
        /// <summary>
        /// The random number generator used for creating the test data.
        /// </summary>
        protected readonly Random Random;

        /// <summary>
        /// Create a new maker.
        /// </summary>
        /// <param name="specification">The specification used to configure generated test data.</param>
        /// <param name="random">The random number generator used in the test data generation process.</param>
        protected Maker(ISpecification<TGenerated> specification, Random random)
        {
            Specification = specification;
            Random = random;
        }

        /// <summary>
        /// Create a new instance of the test data.
        /// </summary>
        /// <returns></returns>
        public abstract TGenerated Make();
    }
}