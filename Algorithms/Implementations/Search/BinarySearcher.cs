using System.Numerics;
using Algorithms.Interfaces;

namespace Algorithms.Implementations.Search;

public class BinarySearcher<T>: ISearcher<T> where T: INumber<T>
{
    public int Search(IEnumerable<T> source, T value)
    {
        var arr = source.ToArray();
        var i = 0;
        var j = arr.Length;
        while (i != j)
        {
            var m = (i + j) / 2;
            if (value == arr[m])
                return m;
            if (value < arr[m])
                j = m;
            else
                i = m + 1;
        }

        return -1;
    }
}