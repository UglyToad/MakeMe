namespace UglyToad.MakeMe
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CharacterStatistics
    {
        public static readonly int SuggestedMaxVowels = 1;
        public static readonly int SuggestedMaxConsonants = 2;

        public static readonly char[] UppercaseLetters =
        {
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N',
            'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
        };
        public static readonly char[] Vowels = { 'a', 'e', 'i', 'o', 'u' };
        public static readonly char[] Consonants =
        {
            'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v',
            'w', 'x', 'y', 'z'
        };

        public static readonly AccentedCharacter[] AccentedCharacters =
        {
            new AccentedCharacter('\xE0','a', true),
            new AccentedCharacter('\xE1','a', true), 
            new AccentedCharacter('\xE2','a', true),
            new AccentedCharacter('\xE3','a', true),
            new AccentedCharacter('\xE4','a', true),
            new AccentedCharacter('\xE5','a', true),
            new AccentedCharacter('\xE6','a', true),
            new AccentedCharacter('\xE7','c', false),
            new AccentedCharacter('\xE8','e', true),
            new AccentedCharacter('\xE9','e', true),
            new AccentedCharacter('\xEA','e', true),
            new AccentedCharacter('\xEB','e', true),
            new AccentedCharacter('\xEC','i', true),
            new AccentedCharacter('\xED','i', true),
            new AccentedCharacter('\xEE','i', true),
            new AccentedCharacter('\xEF','i', true),
            new AccentedCharacter('\xF1','n', false),
            new AccentedCharacter('\xF2','o', true),
            new AccentedCharacter('\xF3','o', true),
            new AccentedCharacter('\xF4','o', true),
            new AccentedCharacter('\xF5','o', true),
            new AccentedCharacter('\xF6','o', true),
            new AccentedCharacter('\xF9','u', true),
            new AccentedCharacter('\xFA','u', true),
            new AccentedCharacter('\xFB','u', true),
            new AccentedCharacter('\xFC','u', true),
            new AccentedCharacter('\xFD','y', false),
            new AccentedCharacter('\xFF','y', false),	
            new AccentedCharacter('\u0153','o', true)	
        };

        private static char[] CommonlyDoubled = { 's', 'e', 't', 'f', 'l', 'm', 'o', 'r', 'd', 'f', 'p' };

        private static char[] UnlikelyConsonantPartner = { 'v', 'j', 'k', 'q', 'x', 'y', 'z', 'g' };

        private static KeyValuePair<char, char>[] UnlikelyPairings =
        {
            new KeyValuePair<char, char>('t', 'c'),
            new KeyValuePair<char, char>('k', 'p'),
            new KeyValuePair<char, char>('h', 's'),
            new KeyValuePair<char, char>('h', 'n'),
            new KeyValuePair<char, char>('h', 'l'),
            new KeyValuePair<char, char>('h', 't'),
            new KeyValuePair<char, char>('f', 's'),
            new KeyValuePair<char, char>('f', 'h'),
            new KeyValuePair<char, char>('f', 'w'),
            new KeyValuePair<char, char>('f', 'd'),
            new KeyValuePair<char, char>('f', 'w'),
            new KeyValuePair<char, char>('m', 'd'),
            new KeyValuePair<char, char>('m', 'v'),
            new KeyValuePair<char, char>('m', 'r'),
            new KeyValuePair<char, char>('m', 't')
        };

        public static KeyValuePair<char, float>[] FrequenciesInWord =
        {
            new KeyValuePair<char, float>('a', 8.2f),
            new KeyValuePair<char, float>('b', 1.5f),
            new KeyValuePair<char, float>('c', 2.8f),
            new KeyValuePair<char, float>('d', 4.3f),
            new KeyValuePair<char, float>('e', 12.7f),
            new KeyValuePair<char, float>('f', 2.2f),
            new KeyValuePair<char, float>('g', 2.0f),
            new KeyValuePair<char, float>('h', 6f),
            new KeyValuePair<char, float>('i', 7f),
            new KeyValuePair<char, float>('j', 0.2f),
            new KeyValuePair<char, float>('k', 0.8f),
            new KeyValuePair<char, float>('l', 4f),
            new KeyValuePair<char, float>('m', 2.4f),
            new KeyValuePair<char, float>('n', 6.7f),
            new KeyValuePair<char, float>('o', 7.5f),
            new KeyValuePair<char, float>('p', 1.9f),
            new KeyValuePair<char, float>('q', 0.1f),
            new KeyValuePair<char, float>('r', 6f),
            new KeyValuePair<char, float>('s', 6.3f),
            new KeyValuePair<char, float>('t', 9.1f),
            new KeyValuePair<char, float>('u', 2.8f),
            new KeyValuePair<char, float>('v', 1f),
            new KeyValuePair<char, float>('w', 2.4f),
            new KeyValuePair<char, float>('x', 0.2f),
            new KeyValuePair<char, float>('y', 2f),
            new KeyValuePair<char, float>('z', 0.07f)
        };

        public static KeyValuePair<char, float>[] FrequenciesAtStart =
        {
            new KeyValuePair<char, float>('a', 11.6f),
            new KeyValuePair<char, float>('b', 4.7f),
            new KeyValuePair<char, float>('c', 3.5f),
            new KeyValuePair<char, float>('d', 2.7f),
            new KeyValuePair<char, float>('e', 2f),
            new KeyValuePair<char, float>('f', 3.8f),
            new KeyValuePair<char, float>('g', 2f),
            new KeyValuePair<char, float>('h', 7.2f),
            new KeyValuePair<char, float>('i', 6.3f),
            new KeyValuePair<char, float>('j', 0.6f),
            new KeyValuePair<char, float>('k', 0.6f),
            new KeyValuePair<char, float>('l', 2.7f),
            new KeyValuePair<char, float>('m', 4.4f),
            new KeyValuePair<char, float>('n', 2.4f),
            new KeyValuePair<char, float>('o', 6.3f),
            new KeyValuePair<char, float>('p', 2.5f),
            new KeyValuePair<char, float>('q', 0.2f),
            new KeyValuePair<char, float>('r', 1.7f),
            new KeyValuePair<char, float>('s', 7.8f),
            new KeyValuePair<char, float>('t', 16.7f),
            new KeyValuePair<char, float>('u', 1.5f),
            new KeyValuePair<char, float>('v', 0.6f),
            new KeyValuePair<char, float>('w', 6.8f),
            new KeyValuePair<char, float>('x', 0.02f),
            new KeyValuePair<char, float>('y', 1.6f),
            new KeyValuePair<char, float>('z', 0.03f)
        };

        public static char[] NormalisedCharsForWord()
        {
            char[] returnChars = new char[5000];
            int index = 0;

            foreach (var charPair in FrequenciesInWord.OrderByDescending(kvp => kvp.Value))
            {
                for (int i = 0; i < (int)(charPair.Value * 50); i++)
                {
                    if (index < returnChars.Length)
                    {
                        returnChars[index] = charPair.Key;
                        index++;
                    }
                }
            }

            return returnChars;
        }

        public static char[] NormalisedCharsForWordStart()
        {
            char[] returnChars = new char[5000];
            int index = 0;

            foreach (var charPair in FrequenciesAtStart.OrderBy(kvp => kvp.Value))
            {
                for (int i = 0; i < (int)(charPair.Value * 50); i++)
                {
                    if (index < returnChars.Length)
                    {
                        returnChars[index] = charPair.Key;
                        index++;
                    }
                }
            }

            return returnChars;
        }

        public static bool IsVowel(char c)
        {
            bool isVowel = false;

            for (int i = 0; i < Vowels.Length; i++)
            {
                if (c == Vowels[i])
                {
                    isVowel = true;
                    break;
                }
            }

            return isVowel;
        }

        public static bool IsCommonlyDoubled(char c)
        {
            bool isCommonlyDoubled = false;

            for (int i = 0; i < CommonlyDoubled.Length; i++)
            {
                if (c == CommonlyDoubled[i])
                {
                    isCommonlyDoubled = true;
                    break;
                }
            }

            return isCommonlyDoubled;
        }

        public static bool IsUnlikelyConsonantPairing(char thisChar)
        {
            bool isUnlikely = false;

            for (int i = 0; i < UnlikelyConsonantPartner.Length; i++)
            {
                if (thisChar == UnlikelyConsonantPartner[i])
                {
                    isUnlikely = true;
                    break;
                }
            }

            return isUnlikely;
        }

        public static bool CanBePaired(char prevChar, char thisChar)
        {
            for (int i = 0; i < UnlikelyPairings.Length; i++)
            {
                if (prevChar == UnlikelyPairings[i].Key && thisChar == UnlikelyPairings[i].Value)
                {
                    return false;
                }
            }

            return true;
        }

        internal static bool HasAccentedReplacement(char thisChar)
        {
            var hasReplacement = false;

            for (int i = 0; i < AccentedCharacters.Length && !hasReplacement; i++)
            {
                hasReplacement = AccentedCharacters[i].NonAccentedEquivalent == thisChar;
            }

            return hasReplacement;
        }

        internal static char ReplaceWithAccented(char character, Random random)
        {
            var possibleReplacements = new List<AccentedCharacter>();

            for (int i = 0; i < AccentedCharacters.Length; i++)
            {
                if (char.ToUpperInvariant(AccentedCharacters[i].NonAccentedEquivalent).Equals(char.ToUpperInvariant(character)))
                {
                    possibleReplacements.Add(AccentedCharacters[i]);
                }
            }

            int index = random.Next(0, possibleReplacements.Count - 1);

            return possibleReplacements[index].Character;
        }
    }
}

