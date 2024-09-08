using System.Numerics;

namespace Algorithms.Interfaces;

public interface ISorter<T> where T : INumber<T>
{
    public IEnumerable<T> Sort(IEnumerable<T> source);
}