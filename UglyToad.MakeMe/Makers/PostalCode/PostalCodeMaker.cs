namespace UglyToad.MakeMe.Makers.PostalCode
{
    using System;
    using System.Collections.Generic;
    using Data;
    using Specification.PostalCode;

    public class PostalCodeMaker : Maker<string>
    {
        private readonly PostalCodeSpecification specification;
        private static readonly Dictionary<IsoAlpha2Code, Func<PostalCodeSpecification, Random, string>> Makers 
            = new Dictionary<IsoAlpha2Code, Func<PostalCodeSpecification, Random, string>>
        {
                { IsoAlpha2Code.UnitedKingdom, (s, r) => new UnitedKingdomPostcodeMaker(s, r).Make() }
        }; 

        public PostalCodeMaker(PostalCodeSpecification specification, Random random) 
            : base(specification, random)
        {
            this.specification = specification;
        }

        public override string Make()
        {
            var country = specification.Country.GetValueOrDefault(IsoAlpha2Code.Unknown);
            Func<PostalCodeSpecification, Random, string> makerFunc;

            if (Makers.TryGetValue(country, out makerFunc))
            {
                return makerFunc(specification, Random);
            }

            return new FiveDigitPostcodeMaker(specification, Random).Make();
        }
    }
}
