namespace UglyToad.MakeMe
{
    using System;
    using Specification.Date;
    using Specification.Integer;
    using Specification.Name;
    using Specification.PostalCode;
    using Specification.Text;

    /// <summary>
    /// The parent class for generating all specifications.
    /// </summary>
    public static class A
    {
        /// <summary>
        /// Create a specification for <see cref="DateTime"/>.
        /// </summary>
        /// <returns>A default <see cref="DateSpecification"/></returns>
        public static DateSpecification Date()
        {
            return new DateSpecification();
        }

        /// <summary>
        /// Create a specification for <see cref="Data.Name"/>.
        /// </summary>
        /// <returns>A default <see cref="NameSpecification"/></returns>
        public static NameSpecification Name()
        {
            return new NameSpecification();
        }

        /// <summary>
        /// Create a specification for postal codes as <see cref="string"/>.
        /// </summary>
        /// <returns>A default <see cref="PostalCodeSpecification"/></returns>
        public static PostalCodeSpecification PostalCode()
        {
            return new PostalCodeSpecification();
        }

        /// <summary>
        /// Create a specification for <see cref="int"/>.
        /// </summary>
        /// <returns>A default <see cref="IntegerSpecification"/></returns>
        public static IntegerSpecification Integer()
        {
            return new IntegerSpecification();
        }

        /// <summary>
        /// Create a specification for text as <see cref="string"/>.
        /// </summary>
        /// <returns>A default <see cref="TextSpecification"/>.</returns>
        public static TextSpecification Text()
        {
            return new TextSpecification();
        }
    }
}
