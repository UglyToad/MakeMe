namespace UglyToad.MakeMe.Makers
{
    using System;
    using Data;
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

        private Name GetCorrectlyCasedName(string firstName, string middleName, string lastName)
        {
            char[] firstNameChars;
            char[] lastNameChars;

            switch (specification.CaseStyle)
            {
                case CaseStyle.Pascal:
                    firstNameChars = firstName.ToCharArray();
                    lastNameChars = lastName.ToCharArray();
                    firstNameChars[0] = char.ToUpperInvariant(firstNameChars[0]);
                    lastNameChars[0] = char.ToUpperInvariant(lastNameChars[0]);

                    if (middleName != null)
                    {
                        char[] middleNameChars = middleName.ToCharArray();
                        middleNameChars[0] = char.ToUpperInvariant(middleNameChars[0]);

                        return new Name(new string(firstNameChars), 
                            new string(middleNameChars), 
                            new string(lastNameChars));
                    }

                    return new Name(new string(firstNameChars), new string(lastNameChars));

                case CaseStyle.Random:
                    firstNameChars = firstName.ToCharArray();
                    lastNameChars = lastName.ToCharArray();

                    for (int i = 0; i < firstNameChars.Length; i++)
                    {
                        if (Random.Next(0, 2) == 0)
                        {
                            firstNameChars[i] = char.ToUpperInvariant(firstNameChars[i]);
                        }
                    }

                    for (int i = 0; i < lastNameChars.Length; i++)
                    {
                        if (Random.Next(0, 2) == 0)
                        {
                            lastNameChars[i] = char.ToUpperInvariant(lastNameChars[i]);
                        }
                    }

                    if (middleName != null)
                    {
                        char[] middleNameChars = middleName.ToCharArray();
                        for (int i = 0; i < middleNameChars.Length; i++)
                        {
                            if (Random.Next(0, 2) == 0)
                            {
                                middleNameChars[i] = char.ToUpperInvariant(middleNameChars[i]);
                            }
                        }
                        return new Name(new string(firstNameChars), new string(middleNameChars), new string(lastNameChars));
                    }
                    return new Name(new string(firstNameChars), new string(lastNameChars));

                case CaseStyle.Upper:
                    if (middleName != null)
                    {
                        return new Name(firstName.ToUpperInvariant(), 
                            middleName.ToUpperInvariant(), 
                            lastName.ToUpperInvariant());
                    }
                    return new Name(firstName.ToUpperInvariant(), lastName.ToUpperInvariant());

                default:
                    if (middleName != null)
                    {
                        return new Name(firstName, middleName, lastName);
                    }
                    return new Name(firstName, lastName);
            }
        }
    }
}
