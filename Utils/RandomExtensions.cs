namespace Utils;

public static class RandomExtensions
{
    public static IEnumerable<int> GenerateRandomInts(int count, int min = int.MinValue, int max = int.MaxValue)
    {
        return GenerateRandomTs(count, min, max, Random.Shared.Next);
    }
    
    public static IEnumerable<float> GenerateRandomFloats(int count)
    {
        return GenerateRandomTs(count, Random.Shared.NextSingle);
    }
    public static IEnumerable<float> GenerateRandomFloatsExt(int count, int min = int.MinValue, int max = int.MaxValue)
    {
        return GenerateRandomTs(count, min, max,
            (i, i1) => Random.Shared.Next(i + 1, i1 - 1) + Random.Shared.NextSingle());
    }

    public static IEnumerable<double> GenerateRandomDoubles(int count)
    {
        return GenerateRandomTs(count, Random.Shared.NextDouble);
    }
    
    public static IEnumerable<double> GenerateRandomDoublesExt(int count, int min = int.MinValue, int max = int.MaxValue)
    {
        return GenerateRandomTs(count, min, max,
            (i, i1) => Random.Shared.Next(i + 1, i1 - 1) + Random.Shared.NextDouble());
    }
    
    public static IEnumerable<long> GenerateRandomLongs(int count)
    {
        return GenerateRandomTs(count, Random.Shared.NextInt64);
    }

    private static IEnumerable<T> GenerateRandomTs<T>(int count, Func<T> random)
    {
        for (var i = 0; i < count; i++)
            yield return random();
    }
    private static IEnumerable<T> GenerateRandomTs<T>(int count, int min, int max, Func<int, int, T> random)
    {
        for (var i = 0; i < count; i++)
            yield return random(min, max);
    }
}