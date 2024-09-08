using System.Numerics;
using Algorithms.Interfaces;

namespace Algorithms.Implementations.Search;

public class LinearSearcher<T> : ISearcher<T> where T: INumber<T>
{
    public int Search(IEnumerable<T> source, T value)
    {
        var arr = source.ToArray();
        var i = 0;
        var count = arr.Length;
        while (i < count)
        {
            if (arr[i] == value)
                return i;
            i++;
        }
        return -1;
    }
}