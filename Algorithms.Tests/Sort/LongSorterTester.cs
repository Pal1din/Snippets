using Utils;

namespace Algorithms.Tests.Sort;

[TestFixture]
public class LongSorterTester: BaseSorterTester<long>
{
    protected override List<Func<int, IEnumerable<long>>> Creators => new()
    {
        RandomExtensions.GenerateRandomLongs
    };
}