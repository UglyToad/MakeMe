namespace UglyToad.MakeMe
{
    using System;
    using Makers;
    using Makers.PostalCode;
    using Specification.Date;
    using Specification.Integer;
    using Specification.Name;
    using Specification.PostalCode;
    using Specification.Text;

    /// <summary>
    /// Factory for creating all types of test data.
    /// </summary>
    public class TestDataFactory
    {
        /// <summary>
        /// Takes in a specification of the type of data to generate and returns a factory for that data type.
        /// </summary>
        /// <typeparam name="TGenerated">The type of data to generate.</typeparam>
        /// <param name="config">The specification for the type of data to generate with any options.</param>
        /// <param name="seed">An optional seed for the random generator used internally. Set to a constant value for repeatable results.</param>
        /// <returns>A factory which will generate data of the configured type with the correct options.</returns>
        public static TestDataTypeFactory<TGenerated> Make<TGenerated>(ISpecification<TGenerated> config, int? seed = null)
        {
            var random = seed.HasValue ? new Random(seed.Value) : new Random();
            return new TestDataTypeFactory<TGenerated>((Maker<TGenerated>)CreateMaker(config, random));
        }

        private static object CreateMaker<TGenerated>(ISpecification<TGenerated> config, Random random)
        {
            var type = config.GetType();

            if (type == typeof(NameSpecification))
            {
                return new NameMaker((NameSpecification)config, random);
            }

            if (type == typeof(DateSpecification))
            {
                return new DateMaker((DateSpecification)config, random);
            }
            
            if (type == typeof(PostalCodeSpecification))
            {
                return new PostalCodeMaker((PostalCodeSpecification)config, random);
            }
            
            if (type == typeof(IntegerSpecification))
            {
                return new IntegerMaker((IntegerSpecification)config, random);
            }

            if (type == typeof(TextSpecification))
            {
                return new TextMaker((TextSpecification) config, random);
            }

            throw new NotImplementedException($"No maker exists for the return type: {type}");
        }
    }
}
