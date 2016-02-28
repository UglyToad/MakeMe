namespace UglyToad.MakeMe.Data
{
    public struct Name
    {
        public readonly string FirstName;

        public bool Equals(Name other)
        {
            return string.Equals(FirstName, other.FirstName) && string.Equals(MiddleName, other.MiddleName) &&
                   string.Equals(LastName, other.LastName);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Name && Equals((Name) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = FirstName?.GetHashCode() ?? 0;
                hashCode = (hashCode*397) ^ (MiddleName?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (LastName?.GetHashCode() ?? 0);
                return hashCode;
            }
        }

        public static bool operator ==(Name a, Name b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Name a, Name b)
        {
            return !(a == b);
        }

        public readonly string MiddleName;

        public readonly string LastName;

        public Name(string firstName, string lastName) : this(firstName, null, lastName)
        {
        }

        public Name(string firstName, string middleName, string lastName)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
        }

        public override string ToString()
        {
            if (MiddleName != null)
            {
                return FirstName + " " + MiddleName + " " + LastName;
            }
            return FirstName + " " + LastName;
        }

        public static implicit operator string(Name n)
        {
            return n.ToString();
        }
    }
}