
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
}