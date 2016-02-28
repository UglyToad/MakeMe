namespace UglyToad.MakeMe.Internal
{
    using System;

    internal class WordGenerator
    {
        public static string Generate(int length, CaseStyle caseStyle, Random random)
        {
            if (length == 1)
            {
                return GenerateSingleCharacter(random, caseStyle).ToString();
            }

            var runCharacterTransformPerIteration = caseStyle == CaseStyle.Upper
                || caseStyle == CaseStyle.Random;
            var transform = CorrectCase(caseStyle, random);
            var chars = new char[length];

            var consecutiveVowels = 0;
            var consecutiveConsonants = 0;
            var c = char.MinValue;

            for (var i = 0; i < length; i++)
            {
                c = GetCharacter(random, i, c, consecutiveVowels, consecutiveConsonants);

                if (LetterTypes.IsVowel(c))
                {
                    consecutiveVowels++;
                    consecutiveConsonants = 0;
                }
                else
                {
                    consecutiveConsonants++;
                    consecutiveVowels = 0;
                }

                if (runCharacterTransformPerIteration)
                {
                    c = transform(c);
                }

                if (i == 0 && caseStyle == CaseStyle.Pascal)
                {
                    c = char.ToUpperInvariant(c);
                }

                chars[i] = c;
            }

            return new string(chars);
        }

        private static char GenerateSingleCharacter(Random random, CaseStyle caseStyle)
        {
            var c = LetterFrequency.Vowels[random.Next(LetterFrequency.Vowels.Length)];
            switch (caseStyle)
            {
                case CaseStyle.Pascal:
                case CaseStyle.Upper:
                    return char.ToUpperInvariant(c);
                case CaseStyle.Random:
                    return (random.Next(2) > 0) ? char.ToUpperInvariant(c) : c;
                default:
                    return c;
            }
        }

        private static char GetCharacter(Random random, int index, char previous, int consecutiveVowels, int consecutiveConsonants)
        {
            if (index == 0)
            {
                return GetRandomStartLetter(random);
            }

            var allowExtra = random.Next(10) == 9;

            if (consecutiveVowels > LetterFrequency.TypicalMaxVowels
                || (consecutiveVowels == LetterFrequency.TypicalMaxVowels && !allowExtra))
            {
                return LetterFrequency.Consonants[random.Next(LetterFrequency.Consonants.Length)];
            }

            if (consecutiveConsonants > LetterFrequency.TypicalMaxConsonants
                || (consecutiveConsonants == LetterFrequency.TypicalMaxConsonants && !allowExtra))
            {
                return LetterFrequency.Vowels[random.Next(LetterFrequency.Vowels.Length)];
            }

            var c = GetRandomWordLetter(random);

            if (c == previous && !CharacterStatistics.IsCommonlyDoubled(c) && !allowExtra)
            {
                c = GetRandomWordLetter(random);
            }

            return c;
        }

        private static char GetRandomStartLetter(Random random)
        {
            return LetterFrequency.StartLetters[random.Next(LetterFrequency.StartLetters.Length)];
        }

        private static char GetRandomWordLetter(Random random)
        {
            return LetterFrequency.WordLetters[random.Next(LetterFrequency.WordLetters.Length)];
        }

        private static Func<char, char> CorrectCase(CaseStyle caseStyle, Random random)
        {
            switch (caseStyle)
            {
                case CaseStyle.Upper:
                    return char.ToUpperInvariant;
                case CaseStyle.Random:
                    return c => random.Next(2) > 0 ? char.ToUpperInvariant(c) : c;
                default:
                    return null;
            }
        }
    }
}
