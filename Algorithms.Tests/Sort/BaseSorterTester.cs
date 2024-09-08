using System.Diagnostics;
using System.Numerics;
using Algorithms.Implementations.Sort;
using Algorithms.Interfaces;

namespace Algorithms.Tests.Sort;

public abstract class BaseSorterTester<T> where T : INumber<T>
{ 
    protected abstract List<Func<int, IEnumerable<T>>> Creators { get; }

    [Test]
    public void SortRealTimeRandomDataTest()
    {
        foreach (var creator in Creators)
        {
            for (var i = 0; i < 50; i++)
            {
                var randomData = creator.Invoke(i).ToArray();
                var orderedData = randomData.Order().ToArray();
                CommonSortTest(randomData, orderedData);
            }
        }
    }
    
    private static IEnumerable<Lazy<ISorter<T>>> Sorters => new Lazy<ISorter<T>>[]
    {
        new(new BubbleSorter<T>()),
        new(new FastSorter<T>()),
        new(new MergingSorter<T>())
    };

    private static void CommonSortTest(IReadOnlyCollection<T> input, IReadOnlyCollection<T> expected)
    {
        foreach (var sorter in Sorters)
        {
            var sw = Stopwatch.StartNew();
            var sorted = sorter.Value.Sort(input).ToArray();
            sw.Stop();
            Console.WriteLine($"Sorting {input.Count} elements by {sorter.Value.GetType().Name} : {sw.Elapsed}");
            Assert.Multiple(() =>
            {
                Assert.That(sorted != null && expected.SequenceEqual(sorted));
                Assert.That(sorted != null && sorted.Length == input.Count);
                Assert.That(sorted != null && sorted.Length == expected.Count);
            });
        } 
    }
}