using Utils;

namespace Algorithms.Tests.Search;

[TestFixture]
public class LongSearcherTester: BaseSearchTests<long>
{
    protected override List<Func<int, IEnumerable<long>>> Creators => [RandomExtensions.GenerateRandomLongs];
}