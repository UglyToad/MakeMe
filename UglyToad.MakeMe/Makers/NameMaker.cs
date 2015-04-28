namespace UglyToad.MakeMe.Makers
{
    using System;
    using System.Collections.Generic;
    using Pocos;

    public class NameMaker : IMake<Name>
    {
        private readonly bool includeMiddleName;
        private readonly StringGenerator stringGenerator;
        private readonly Random random;

        private CaseStyle casing = CaseStyle.Pascal;
        private bool includeAccentedCharacters;

        private int[] firstNameLength = { 3, 8 };
        private int[] middleNameLength = { 2, 8 };
        private int[] lastNameLength = { 4, 9 };

        public NameMaker(bool includeMiddleName)
        {
            this.random = new Random();
            this.includeMiddleName = includeMiddleName;
            this.stringGenerator = new StringGenerator(random);
        }

        public NameMaker()
            : this(false)
        {
        }

        public NameMaker UseAccentedCharacters()
        {
            this.includeAccentedCharacters = true;
            return this;
        }

        public NameMaker UseSpecificCase(CaseStyle caseStyle)
        {
            this.casing = caseStyle;
            return this;
        }

        public Name Please()
        {
            string firstName = stringGenerator.Generate(random.Next(firstNameLength[0], firstNameLength[1]));
            string lastName = stringGenerator.Generate(random.Next(lastNameLength[0], lastNameLength[1]));
            string middleName = null;

            if (includeMiddleName)
            {
                middleName = stringGenerator.Generate(random.Next(middleNameLength[0], middleNameLength[1]));
                return new Name(firstName, middleName, lastName);
            }

            return GetCorrectlyCasedName(firstName, middleName, lastName);
        }

        private Name GetCorrectlyCasedName(string firstName, string middleName, string lastName)
        {
            char[] firstNameChars;
            char[] lastNameChars;

            switch (casing)
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

                        return new Name(new string(firstNameChars), new string(middleNameChars), new string(lastNameChars));
                    }
                    return new Name(new string(firstNameChars), new string(lastNameChars));
                case CaseStyle.Random:
                    firstNameChars = firstName.ToCharArray();
                    lastNameChars = lastName.ToCharArray();

                    for (int i = 0; i < firstNameChars.Length; i++)
                    {
                        if (random.Next(0, 2) == 0)
                        {
                            firstNameChars[i] = char.ToUpperInvariant(firstNameChars[i]);
                        }
                    }

                    for (int i = 0; i < lastNameChars.Length; i++)
                    {
                        if (random.Next(0, 2) == 0)
                        {
                            lastNameChars[i] = char.ToUpperInvariant(lastNameChars[i]);
                        }
                    }

                    if (middleName != null)
                    {
                        char[] middleNameChars = middleName.ToCharArray();
                        for (int i = 0; i < middleNameChars.Length; i++)
                        {
                            if (random.Next(0, 2) == 0)
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
                        return new Name(firstName.ToUpperInvariant(), middleName.ToUpperInvariant(), lastName.ToUpperInvariant());
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

        public IEnumerable<Name> ThisManyTimes(int times)
        {
            for (int i = 0; i < times; i++)
            {
                yield return Please();
            }
        }
    }

    public enum CaseStyle
    {
        Pascal = 1,
        Lower = 2,
        Upper = 3,
        Random = 4
    }
}
