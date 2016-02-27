namespace UglyToad.MakeMe
{
    using Specification.Date;
    using Specification.Name;
    using Specification.PostalCode;

    public static class A
    {
        public static DateSpecification Date()
        {
            return new DateSpecification();
        }

        public static NameSpecification Name()
        {
            return new NameSpecification();
        }

        public static PostalCodeSpecification PostalCode()
        {
            return new PostalCodeSpecification();
        }
    }
}
