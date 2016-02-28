namespace UglyToad.MakeMe.Makers.PostalCode
{
    using System;
    using System.Linq;

    internal struct UkCodeFormat
    {
        private static readonly char[] ValidIncodeLetters =
        {
            'A', 'B', 'D', 'E', 'F', 'G', 'H', 'J', 'L', 'N',
            'P', 'Q', 'R', 'S', 'T', 'U', 'W', 'X', 'Y', 'Z'
        };

        public static readonly UkCodeFormat[] ValidFormats =
        {
            new UkCodeFormat("AN", "NAA"),
            new UkCodeFormat("ANN", "NAA"),
            new UkCodeFormat("AAN", "NAA"),
            new UkCodeFormat("AANN", "NAA"),
            new UkCodeFormat("ANA", "NAA"),
            new UkCodeFormat("AANA", "NAA")
        };
        
        private const char Digit = 'N';

        public string InCode { get; private set; }

        public string OutCode { get; private set; }

        public UkCodeFormat(string outCode, string inCode)
        {
            OutCode = outCode;
            InCode = inCode;
        }

        public UkCodeFormat GenerateRandom(Random random, CaseStyle caseStyle)
        {
            var outcode = OutCode.Select(o =>
                SubstituteTemplatedCharacterWithMatchingCase(o, random, CharacterStatistics.UppercaseLetters,
                    caseStyle))
                .ToArray();

            var incode = InCode.Select(i =>
                SubstituteTemplatedCharacterWithMatchingCase(i, random, ValidIncodeLetters, caseStyle)).ToArray();

            if (caseStyle == CaseStyle.Pascal)
            {
                outcode[0] = char.ToUpperInvariant(outcode[0]);
                incode[0] = char.ToUpperInvariant(incode[0]);
            }
            
            return new UkCodeFormat(new string(outcode), new string(incode));
        }

        private static char SubstituteTemplatedCharacterWithMatchingCase(char templateChar, Random random, char[] possibleValues,
            CaseStyle caseStyle)
        {
            if (templateChar == Digit)
            {
                return random.Next(10).ToString()[0];
            }

            var letterIndex = random.Next(possibleValues.Length);
            var character = possibleValues[letterIndex];

            switch (caseStyle)
            {
                case CaseStyle.Pascal:
                case CaseStyle.Lower:
                    character = char.ToLowerInvariant(character);
                    break;
                case CaseStyle.Random:
                    var chance = random.Next(2);
                    if (chance == 0)
                    {
                        character = char.ToLowerInvariant(character);
                    }
                    break;
            }

            return character;
        }
    }
}