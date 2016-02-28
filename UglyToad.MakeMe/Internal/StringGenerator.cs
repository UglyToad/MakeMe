namespace UglyToad.MakeMe.Internal
{
    using System;

    internal class StringGenerator
    {
        private readonly Random random;

        public StringGenerator(Random random)
        {
            this.random = random;
        }

        internal string MakeStringAccented(string thisString)
        {
            var hasReplaced = false;
            var theseChars = thisString.ToCharArray();

            for (int i = 0; i < thisString.Length && !hasReplaced; i++)
            {
                if (CharacterStatistics.HasAccentedReplacement(thisString[i]))
                {
                    // Replace
                    theseChars[i] = CharacterStatistics.ReplaceWithAccented(theseChars[i], random);
                    hasReplaced = true;
                }
            }

            if (!hasReplaced)
            {
                int replaceIndex = random.Next(0, theseChars.Length - 1);
                int replaceValue = random.Next(0, CharacterStatistics.AccentedCharacters.Length);

                theseChars[replaceIndex] = CharacterStatistics.AccentedCharacters[replaceValue].Character;
            }

            return new string(theseChars);
        }
    }
}
