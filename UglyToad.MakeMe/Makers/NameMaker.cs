namespace UglyToad.MakeMe.Makers
{
    using System;
    using Data;
    using Internal;
    using Specification.Name;

    internal class NameMaker : Maker<Name>
    {
        private readonly NameSpecification specification;
        private readonly StringGenerator stringGenerator;

        public NameMaker(NameSpecification specification, Random random) 
            : base(specification, random)
        {
            this.specification = specification;
            stringGenerator = new StringGenerator(random);
        }

        public override Name Make()
        {
            var firstName = WordGenerator.Generate(Random.Next(specification.FirstNameRange.Minimum, specification.FirstNameRange.Maximum + 1), specification.CaseStyle, Random);
            var lastName = WordGenerator.Generate(Random.Next(specification.LastNameRange.Minimum, specification.LastNameRange.Maximum + 1), specification.CaseStyle, Random);
            string middleName = null;

            if (specification.NamePartData.MiddleNamePercentage.Met(Random))
            {
                middleName = WordGenerator.Generate(Random.Next(specification.MiddleNameRange.Minimum, specification.MiddleNameRange.Maximum + 1), specification.CaseStyle, Random);

                return new Name(firstName, middleName, lastName);
            }

            if (specification.AccentedCharacterPercentage.Met(Random))
            {
                int nameToUse = Random.Next(1, 3);
                
                if ((nameToUse == 1 && middleName != null) || (nameToUse < 3 && middleName == null))
                {
                    firstName = stringGenerator.MakeStringAccented(firstName);
                }
                else if (nameToUse == 2 && middleName != null)
                {
                    middleName = stringGenerator.MakeStringAccented(middleName);
                }
                else if (lastName != null)
                {
                    lastName = stringGenerator.MakeStringAccented(lastName);
                }
            }

            return new Name(firstName, middleName, lastName);
        }
    }
}
