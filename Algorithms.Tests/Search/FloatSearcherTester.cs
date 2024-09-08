using Utils;

namespace Algorithms.Tests.Search;

[TestFixture]
public class FloatSearcherTester: BaseSearchTests<float>
{
    protected override List<Func<int, IEnumerable<float>>> Creators =>
    [
        RandomExtensions.GenerateRandomFloats,
        x => RandomExtensions.GenerateRandomFloatsExt(x)
    ];
}