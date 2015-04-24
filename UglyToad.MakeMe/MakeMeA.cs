namespace UglyToad.MakeMe
{
    using Makers;

    public static class MakeMeA
    {
        public static DateMaker Date(bool includeTime = true)
        {
            return new DateMaker(includeTime);
        }

        public static NameMaker Name()
        {
            return new NameMaker();
        }
    }
}
