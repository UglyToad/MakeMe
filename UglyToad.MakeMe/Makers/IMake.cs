namespace UglyToad.MakeMe.Makers
{
    using System.Collections.Generic;

    internal interface IMake<T>
    {
        T Please();

        IEnumerable<T> ThisManyTimes(int times);
    }
}