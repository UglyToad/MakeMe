namespace UglyToad.MakeMe.Specification
{
    internal class DefaultString
    {
        public string Value { get; private set; }

        public bool Set { get; private set; }

        public DefaultString()
        {
            Set = false;
        }

        public DefaultString(string value)
        {
            Set = true;
            Value = value;
        }
    }
}