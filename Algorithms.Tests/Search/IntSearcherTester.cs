using Utils;

namespace Algorithms.Tests.Search;

[TestFixture]
public class IntSearcherTester: BaseSearchTests<int>
{
    protected override List<Func<int, IEnumerable<int>>> Creators => [x => RandomExtensions.GenerateRandomInts(x)];
}