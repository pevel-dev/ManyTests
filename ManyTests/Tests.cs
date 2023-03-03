using System.Collections;
using NUnit.Framework;

namespace ManyTests;

[TestFixture]
public class Tests
{
    

    [Test, Timeout(2000)]
    public void IsLazy<T>(Func<IEnumerable<T>, IEnumerable<T>> func)
    {
        var list = new T[100000];
        var savedItem = default(T);

        for (var i = 0; i < 100000; ++i)
        {
            var item = func(list).FirstOrDefault();
            savedItem = item;
        }
    }

    [Test]
    public void DoubleEnumerable<T>(Func<IEnumerable<T>, IEnumerable<T>> testMethod)
    {
        var fakeEnumerable = new FakeEnumerable<T>();
        testMethod(fakeEnumerable);
        if (fakeEnumerable.EnumerationCount > 1)
            Assert.Fail("Double enumeration!");
        Assert.Pass();
    }
}