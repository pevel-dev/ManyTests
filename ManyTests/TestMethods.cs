namespace ManyTests;

public static class TestMethods
{
    public static IEnumerable<T> DoubleEnumerationMethod<T>(IEnumerable<T> source)
    {
        var firstEnumeration = source.ToList();
        var secondEnumeration = source.ToList();
        return firstEnumeration;
    }

    public static IEnumerable<T> NoDoubleEnumerationMethod<T>(IEnumerable<T> source)
    {
        var firstEnumeration = source.ToList();
        return firstEnumeration;
    }

    public static IEnumerable<T> LazyEnumerationMethod<T>(IEnumerable<T> source)
    {
        foreach (var value in source)
        {
            yield return value;
        }
    }

    public static IEnumerable<T> NonLazyEnumerationMethod<T>(IEnumerable<T> source)
    {
        return source.ToList();
    }
}