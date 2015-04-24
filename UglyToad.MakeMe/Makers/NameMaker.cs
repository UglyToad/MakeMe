namespace UglyToad.MakeMe.Makers
{
    using System.Collections.Generic;
    using Pocos;

    public class NameMaker : IMake<Name>
    {
        private readonly bool includeMiddleName;

        private int maxLength;
        private CaseStyle casing = CaseStyle.Pascal;
        private bool includeAccentedCharacters;

        private char[] vowels = { 'a', 'e', 'i', 'o', 'u' };

        private char[] consonants =
        {
            'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v',
            'w', 'x', 'y', 'z'
        };

        private KeyValuePair<char, float>[] frequencies =
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

        private string firstName;
        private string lastName;
        private string middleName;

        public NameMaker(bool includeMiddleName)
        {
            this.includeMiddleName = includeMiddleName;
        }

        public NameMaker() : this(false)
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

            throw new System.NotImplementedException();
        }

        public IEnumerable<Name> ThisManyTimes(int times)
        {
            throw new System.NotImplementedException();
        }
    }

    public enum CaseStyle
    {
        Pascal = 1,
        Camel = 2,
        Lower = 3,
        Upper = 4,
        Random = 5
    }
}
