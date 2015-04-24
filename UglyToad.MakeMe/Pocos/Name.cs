namespace UglyToad.MakeMe.Pocos
{
    public struct Name
    {
        public readonly string FirstName;

        public readonly string MiddleName;

        public readonly string LastName;

        public Name(string firstName, string lastName) : this(firstName, null, lastName)
        {
        }

        public Name(string firstName, string middleName, string lastName)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
        }

        public override string ToString()
        {
            if (MiddleName != null)
            {
                return FirstName + " " + MiddleName + " " + LastName;
            }
            return FirstName + " " + LastName;
        }
    }
}
