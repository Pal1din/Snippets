using System.Numerics;
using Algorithms.Interfaces;

namespace Algorithms.Implementations.Sort;

public class FastSorter<T> : ISorter<T> where T : INumber<T>
{
    public IEnumerable<T> Sort(IEnumerable<T> source)
    {
        var arr = source as T[] ?? source.ToArray();
        var items = new T[arr.Length];
        arr.CopyTo(items, 0);
        DoSort(items, 0, items.Length - 1);
        return items;
    }

    private static void DoSort(T[] items, int fst, int lst)
    {
        if (fst >= lst)
            return;
        var i = fst;
        var j = lst;
        var x = items[(fst + lst) / 2];

        while (i < j)
        {
            while (items[i] < x) i++;
            while (items[j] > x) j--;
            if (i > j) continue;
            (items[i], items[j]) = (items[j], items[i]);
            i++;
            j--;
        }

        DoSort(items, fst, j);
        DoSort(items, i, lst);
    }
}