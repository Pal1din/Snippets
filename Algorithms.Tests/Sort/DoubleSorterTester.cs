using Utils;

namespace Algorithms.Tests.Sort;

[TestFixture]
public class DoubleSorterTester : BaseSorterTester<double>
{
    protected override List<Func<int, IEnumerable<double>>> Creators =>
    [
        RandomExtensions.GenerateRandomDoubles,
        x => RandomExtensions.GenerateRandomDoublesExt(x)
    ];
}