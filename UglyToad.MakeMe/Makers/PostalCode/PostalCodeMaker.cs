﻿namespace UglyToad.MakeMe.Makers.PostalCode
{
    using System;
    using System.Collections.Generic;
    using Data;
    using Specification.PostalCode;

    internal class PostalCodeMaker : Maker<string>
    {
        private readonly PostalCodeSpecification specification;
        private static readonly Dictionary<IsoAlpha2Code, Func<PostalCodeSpecification, Random, string>> Makers 
            = new Dictionary<IsoAlpha2Code, Func<PostalCodeSpecification, Random, string>>
        {
                { IsoAlpha2Code.UnitedKingdom, (s, r) => new UnitedKingdomPostcodeMaker(s, r).Make() },
                { IsoAlpha2Code.India, (s, r) => new DigitPostcodeMaker(s, r, 6).Make() }
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

            return new DigitPostcodeMaker(specification, Random, 5).Make();
        }
    }
}
