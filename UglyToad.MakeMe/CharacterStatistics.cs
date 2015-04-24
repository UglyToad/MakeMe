namespace UglyToad.MakeMe
{
    using System.Collections.Generic;

    public class CharacterStatistics
    {
        public static char[] Vowels = { 'a', 'e', 'i', 'o', 'u' };

        public static char[] Consonants =
        {
            'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v',
            'w', 'x', 'y', 'z'
        };

        public static char[] CommonlyDoubled = {'s', 'e', 't', 'f', 'l', 'm', 'o', 'r', 'd', 'f', 'p'};

        public KeyValuePair<char, float>[] FrequenciesInWord =
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

        public KeyValuePair<char, float>[] FrequenciesAtStart =
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
    }
}
