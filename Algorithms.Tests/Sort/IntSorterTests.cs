using Utils;

namespace Algorithms.Tests.Sort;

[TestFixture]
public class IntSorterTests : BaseSorterTester<int>
{
    protected override List<Func<int, IEnumerable<int>>> Creators => new()
    {
        x => RandomExtensions.GenerateRandomInts(x)
    };
}