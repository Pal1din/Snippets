using System.Numerics;
using Algorithms.Interfaces;

namespace Algorithms.Implementations.Sort;

public class MergingSorter<T> : ISorter<T> where T : INumber<T>
{
    public IEnumerable<T> Sort(IEnumerable<T> source)
    {
        var arr = source.ToArray();
        var items = new T[arr.Length];
        arr.CopyTo(items, 0);
        DoSort(items);
        return items;
    }

    private void DoSort(T[] items)
    {
        if (items.Length is 1 or 0)
            return;

        var lLeft = items.Length / 2;
        var left = new T[lLeft];
        Array.Copy(items, left, lLeft);
        var lRight = items.Length - lLeft;
        var right = new T[lRight];
        Array.Copy(items, lLeft, right, 0, lRight);

        DoSort(left);
        DoSort(right);

        Merge(left, right, items);
    }

    private void Merge(T[] left, T[] right, T[] result)
    {
        var l = 0;
        var r = 0;
        var i = 0;

        while (l < left.Length && r < right.Length)
        {
            if (left[l] < right[r])
            {
                result[i] = left[l];
                l++;
            }
            else
            {
                result[i] = right[r];
                r++;
            }

            i++;
        }

        var len = left.Length - l;
        Array.Copy(left, l, result, i, len);
        Array.Copy(right, r, result,
            i + len, right.Length - r);
    }
}