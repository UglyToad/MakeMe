namespace UglyToad.MakeMe
{
    using System;
    using Data;
    using Makers;
    using Makers.PostalCode;
    using Specification.Date;
    using Specification.Name;
    using Specification.PostalCode;

    public class TestDataFactory
    {
        public static TestDataTypeFactory<TGenerated> Make<TGenerated>(ISpecification<TGenerated> config, int? seed = null)
        {
            var random = seed.HasValue ? new Random(seed.Value) : new Random();
            return new TestDataTypeFactory<TGenerated>((Maker<TGenerated>)CreateMaker(config, random));
        }

        private static object CreateMaker<TGenerated>(ISpecification<TGenerated> config, Random random)
        {
            var type = typeof (TGenerated);

            if (type == typeof(Name))
            {
                return new NameMaker((NameSpecification)config, random);
            }

            if (type == typeof(DateTime))
            {
                return new DateMaker((DateSpecification)config, random);
            }

            var specification = config as PostalCodeSpecification;
            if (specification != null)
            {
                return new PostalCodeMaker(specification, random);
            }

            throw new NotImplementedException($"No maker exists for the return type: {type}");
        }
    }
}
