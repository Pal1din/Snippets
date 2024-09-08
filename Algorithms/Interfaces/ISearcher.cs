namespace Algorithms.Interfaces;

public interface ISearcher<T>
{
    int Search(IEnumerable<T> source, T value);
}