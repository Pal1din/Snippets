using Utils;

namespace Algorithms.Tests.Sort;

[TestFixture]
public class FloatSorterTests : BaseSorterTester<float>
{
    protected override List<Func<int, IEnumerable<float>>> Creators => new()
    {
        RandomExtensions.GenerateRandomFloats,
        x => RandomExtensions.GenerateRandomFloatsExt(x)
    };
}