namespace UglyToad.MakeMe
{
    using System;
    using System.Collections.Generic;

    public class StringGenerator
    {
        private readonly Random random;
        private readonly char[] normalisedChars = CharacterStatistics.NormalisedCharsForWord();
        private readonly char[] normalisedStartingChars = CharacterStatistics.NormalisedCharsForWordStart();

        public StringGenerator(Random random)
        {
            this.random = random;
        }

        public string Generate(int length)
        {
            char[] chars = new char[length];

            for (int i = 0; i < length; i++)
            {
                if (i == 0)
                {
                    chars[i] = normalisedStartingChars[random.Next(0, normalisedStartingChars.Length - 1)];
                }
                else
                {
                    char thisChar = normalisedChars[random.Next(0, normalisedChars.Length - 1)];
                    char prevChar = chars[i - 1];

                    var previousTypeRepeated = InspectPrevious(chars, thisChar, i);

                    if (previousTypeRepeated.Key.Equals("vowel") && previousTypeRepeated.Value > CharacterStatistics.SuggestedMaxVowels)
                    {
                        int retry = 0;
                        while (retry < 2 && CharacterStatistics.IsVowel(thisChar))
                        {
                            thisChar = normalisedChars[random.Next(0, normalisedChars.Length - 1)];
                            retry++;
                        }
                    }
                    else if (previousTypeRepeated.Key.Equals("consonant") && previousTypeRepeated.Value > CharacterStatistics.SuggestedMaxConsonants)
                    {
                        int retry = 0;
                        while (retry < 25 && !CharacterStatistics.IsVowel(thisChar))
                        {
                            thisChar = normalisedChars[random.Next(0, normalisedChars.Length - 1)];
                            retry++;
                        }
                    }

                    if (thisChar == prevChar &&
                        !CharacterStatistics.IsCommonlyDoubled(thisChar))
                    {
                        int retry = 0;
                        while (retry < 5 && thisChar == prevChar)
                        {
                            thisChar = normalisedChars[random.Next(0, normalisedChars.Length - 1)];
                            retry++;
                        }
                    }
                    else if (!CharacterStatistics.IsVowel(prevChar) &&
                        CharacterStatistics.IsUnlikelyConsonantPairing(thisChar))
                    {
                        int retry = 0;
                        bool isStillUnlikely = true;
                        while (retry < 3 && isStillUnlikely)
                        {
                            thisChar = normalisedChars[random.Next(0, normalisedChars.Length - 1)];
                            isStillUnlikely = CharacterStatistics.IsUnlikelyConsonantPairing(thisChar);
                            retry++;
                        }
                    }
                    else if (!CharacterStatistics.IsVowel(thisChar) &&
                             CharacterStatistics.IsUnlikelyConsonantPairing(prevChar))
                    {
                        int retry = 0;
                        bool isStillConsonant = true;
                        while (retry < 3 && isStillConsonant)
                        {
                            thisChar = normalisedChars[random.Next(0, normalisedChars.Length - 1)];
                            isStillConsonant = !CharacterStatistics.IsVowel(thisChar);
                            retry++;
                        }
                    }
                    
                    if (!CharacterStatistics.CanBePaired(prevChar, thisChar))
                    {
                        int retry = 0;
                        bool canBePaired = false;
                        while (retry < 3 && !canBePaired)
                        {
                            thisChar = normalisedChars[random.Next(0, normalisedChars.Length - 1)];
                            canBePaired = CharacterStatistics.CanBePaired(prevChar, thisChar);
                            retry++;
                        }
                    }

                    if (i == 1 && !CharacterStatistics.IsVowel(prevChar) && !CharacterStatistics.IsVowel(thisChar))
                    {
                        int retry = 0;
                        while (retry < 5 && !CharacterStatistics.IsVowel(thisChar))
                        {
                            thisChar = normalisedChars[random.Next(0, normalisedChars.Length - 1)];
                            retry++;
                        }
                    }

                    chars[i] = thisChar;
                }
            }

            return new string(chars);
        }

        private static KeyValuePair<string, int> InspectPrevious(char[] thisString, char thisChar, int index)
        {
            bool isSameType = true;
            string type = CharacterStatistics.IsVowel(thisChar) ? "vowel" : "consonant";

            int repeated = 1;
            index -= 1;

            while (index > 0 && isSameType)
            {
                string thisType = CharacterStatistics.IsVowel(thisString[index]) ? "vowel" : "consonant";

                isSameType = thisType.Equals(type);

                if (isSameType)
                {
                    repeated++;
                }

                index -= 1;
            }

            return new KeyValuePair<string, int>(type, repeated);
        }
    }
}
