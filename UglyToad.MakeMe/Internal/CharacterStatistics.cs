namespace UglyToad.MakeMe.Internal
{
    using System;
    using System.Collections.Generic;

    internal class CharacterStatistics
    {
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

