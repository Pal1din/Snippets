using System.Numerics;
using Algorithms.Interfaces;

namespace Algorithms.Implementations.Sort;

public class BubbleSorter<T> : ISorter<T> where T : INumber<T>
{
    public IEnumerable<T> Sort(IEnumerable<T> source)
    {
        var arr = source as T[] ?? source.ToArray();
        var items = new T[arr.Length];
        arr.CopyTo(items, 0);
        for (var i = 0; i < items.Length; i++)
        for (var j = i + 1; j < items.Length; j++)
            if (items[j] < items[i])
            {
                (items[j], items[i]) = (items[i], items[j]);
            }

        return items;
    }
}