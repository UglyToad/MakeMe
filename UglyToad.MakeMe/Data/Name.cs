namespace UglyToad.MakeMe.Data
{
    /// <summary>
    /// A data type representing person name data.
    /// </summary>
    public struct Name
    {
        /// <summary>
        /// The first part of the name.
        /// </summary>
        public readonly string FirstName;

        /// <summary>
        /// Equality comparison.
        /// </summary>
        /// <param name="other">The name to compare with.</param>
        /// <returns>True if all letters in the name are equal (case sensitive), false otherwise.</returns>
        public bool Equals(Name other)
        {
            return string.Equals(FirstName, other.FirstName) && string.Equals(MiddleName, other.MiddleName) &&
                   string.Equals(LastName, other.LastName);
        }

        /// <summary>
        /// Equality comparison.
        /// </summary>
        /// <param name="obj">The object to compare with.</param>
        /// <returns>True if the object is a name which is equal, false otherwise.</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Name && Equals((Name) obj);
        }

        /// <summary>
        /// Get hash code.
        /// </summary>
        /// <returns>Hash code.</returns>
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

        /// <summary>
        /// Equality operator.
        /// </summary>
        /// <param name="a">Left hand operand.</param>
        /// <param name="b">Right hand operand.</param>
        /// <returns>True if the names are equal based on letters in the name, false otherwise.</returns>
        public static bool operator ==(Name a, Name b)
        {
            return a.Equals(b);
        }

        /// <summary>
        /// Inequality operator.
        /// </summary>
        /// <param name="a">Left hand operand.</param>
        /// <param name="b">Right hand operand.</param>
        /// <returns>False if the names are equal based on letters in the name, true otherwise.</returns>
        public static bool operator !=(Name a, Name b)
        {
            return !(a == b);
        }

        /// <summary>
        /// The middle name.
        /// </summary>
        public readonly string MiddleName;

        /// <summary>
        /// The last name.
        /// </summary>
        public readonly string LastName;

        /// <summary>
        /// Creates a new <see cref="Name"/>.
        /// </summary>
        /// <param name="firstName">The first name to use.</param>
        /// <param name="lastName">The last name to use.</param>
        public Name(string firstName, string lastName) : this(firstName, null, lastName)
        {
        }

        /// <summary>
        /// Creates a new <see cref="Name"/>.
        /// </summary>
        /// <param name="firstName">The first name to use.</param>
        /// <param name="middleName">The middle name to use.</param>
        /// <param name="lastName">The last name to use.</param>
        public Name(string firstName, string middleName, string lastName)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
        }

        /// <summary>
        /// Generates a string representation of the name showing only the non-null part with conventional spacing.
        /// If all names are empty will return <see cref="string.Empty"/>.
        /// </summary>
        /// <returns>The name as a formatted string.</returns>
        public override string ToString()
        {
            var result = string.Empty;

            if (!string.IsNullOrEmpty(result))
            {
                result += FirstName;
            }

            if (!string.IsNullOrEmpty(MiddleName))
            {
                result += " " + MiddleName;
            }

            if (!string.IsNullOrEmpty(LastName))
            {
                result += " " + LastName;
            }

            return result;
        }

        /// <summary>
        /// Cast name to string using the ToString method.
        /// </summary>
        /// <param name="n">The name to cast to a <see cref="string"/>.</param>
        public static implicit operator string(Name n)
        {
            return n.ToString();
        }
    }
}