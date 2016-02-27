namespace UglyToad.MakeMe
{
    using Specification.Date;
    using Specification.Name;

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
    }
}
