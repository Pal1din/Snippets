using System.Numerics;
using Algorithms.Implementations.Search;
using Algorithms.Interfaces;

namespace Algorithms.Tests.Search;

public abstract class BaseSearchTests<T> where T: INumber<T>
{
    protected abstract List<Func<int, IEnumerable<T>>> Creators { get; }
    
    [Test]
    public void Test1()
    {
        foreach (var creator in Creators)
        {
            for (var i = 1; i < 50; i++)
            {
                var randomData = creator.Invoke(i).ToArray();
                var toFind = randomData[Random.Shared.Next(0, i)];
                var expected = Array.IndexOf(randomData, toFind);
                CommonSearchTest(randomData, toFind, expected);
            }
        }
    }
    
    private void CommonSearchTest(T[] source, T value, int expected)
    {
        foreach (var searcher in Searchers)
        {
            var search = searcher.Value.Search(source, value);
            Assert.That(search, Is.EqualTo(expected));
        }
    }
    
    private static IEnumerable<Lazy<ISearcher<T>>> Searchers => new Lazy<ISearcher<T>>[]
    {
        new(new LinearSearcher<T>()),
    };
}