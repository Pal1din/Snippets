using Utils;

namespace Algorithms.Tests.Search;

[TestFixture]
public class DoubleSearcherTester: BaseSearchTests<double>
{
    protected override List<Func<int, IEnumerable<double>>> Creators =>
    [
        RandomExtensions.GenerateRandomDoubles, x => RandomExtensions.GenerateRandomDoublesExt(x)
    ];
}