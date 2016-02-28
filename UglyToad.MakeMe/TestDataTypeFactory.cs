namespace UglyToad.MakeMe
{
    using System.Collections.Generic;
    using System.Linq;
    using Makers;

    /// <summary>
    /// Responsible for producing instances of test data of the correct type.
    /// </summary>
    /// <typeparam name="TGenerated">The type of test data to generate.</typeparam>
    public class TestDataTypeFactory<TGenerated>
    {
        private readonly Maker<TGenerated> maker;

        internal TestDataTypeFactory(Maker<TGenerated> maker)
        {
            this.maker = maker;
        }

        /// <summary>
        /// Generate a single instance of the given type of test data.
        /// </summary>
        /// <returns>An instance of the test data type.</returns>
        public TGenerated Generate()
        {
            return maker.Make();
        }

        /// <summary>
        /// Generate a series of the given type of test data.
        /// </summary>
        /// <param name="count">The number of records to generate.</param>
        /// <returns>An instance of the test data type.</returns>
        public IEnumerable<TGenerated> GenerateSeries(int count)
        {
            return Enumerable.Range(0, count).Select(_ => maker.Make());
        }
    }
}