using System.Numerics;
using Algorithms.Implementations.Search;
using Algorithms.Implementations.Sort;
using Algorithms.Interfaces;

namespace Algorithms.Tests.Search;

public abstract class BaseSearchTests<T> where T: INumber<T>
{
    protected abstract List<Func<int, IEnumerable<T>>> Creators { get; }
    
    [Test]
    public void ElementContainsInCollection()
    {
        foreach (var creator in Creators)
        {
            for (var i = 1; i < 50; i++)
            {
                var randomData = creator.Invoke(i).ToArray();
                var toFind = randomData[Random.Shared.Next(0, i)];
                CommonSearchTest(randomData, toFind);
            }
        }
    }
    
    private void CommonSearchTest(T[] source, T value)
    {
        foreach (var searcher in Searchers)
        {
            //Binary search uses only on sorted collection
            if (searcher.Value.GetType() == typeof(BinarySearcher<T>))
            {
                source = new FastSorter<T>().Sort(source).ToArray();
            } 
            var expected = Array.IndexOf(source, value);
            var search = searcher.Value.Search(source, value);
            Assert.That(search, Is.EqualTo(expected));
        }
    }
    
    private static IEnumerable<Lazy<ISearcher<T>>> Searchers => new Lazy<ISearcher<T>>[]
    {
        new(new LinearSearcher<T>()),
        new(new BinarySearcher<T>())
    };
}