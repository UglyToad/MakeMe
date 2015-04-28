namespace UglyToad.MakeMe
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CharacterStatistics
    {
        public static int SuggestedMaxVowels = 1;
        public static int SuggestedMaxConsonants = 2;

        public static char[] Vowels = { 'a', 'e', 'i', 'o', 'u' };

        public static char[] Consonants =
        {
            'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v',
            'w', 'x', 'y', 'z'
        };

        private static char[] CommonlyDoubled = {'s', 'e', 't', 'f', 'l', 'm', 'o', 'r', 'd', 'f', 'p'};

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
    }
}
