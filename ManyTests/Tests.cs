using System.Collections;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace ManyTests;

[TestFixture]
public class Tests
{
    [Test]
    public void DetectNoLazyMethod()
    {
        var result = PerformanceTests.RunWithTimeout<int>(LazyCheck, TestMethods.NonLazyEnumerationMethod, 2000);
        Assert.IsFalse(result);
    }

    [Test]
    public void NoDetectNotLazyMethod()
    {
        var result = PerformanceTests.RunWithTimeout<int>(LazyCheck, TestMethods.LazyEnumerationMethod, 2000);
        Assert.IsTrue(result);
    }


    [Test]
    public void DetectDoubleEnumeration()
    {
        var result = MethodHasDoubleEnumerable<int>(TestMethods.DoubleEnumerationMethod);
        Assert.IsTrue(result);
    }

    [Test]
    public void NoTriggerForOnceEnumeration()
    {
        var result = MethodHasDoubleEnumerable<int>(TestMethods.NoDoubleEnumerationMethod);
        Assert.IsFalse(result);
    }

    public void LazyCheck<T>(Func<IEnumerable<T>, IEnumerable<T>> func)
    {
        var list = new T[100000];
        var savedItem = default(T);

        for (var i = 0; i < 100000; ++i)
        {
            var item = func(list).FirstOrDefault();
            savedItem = item;
        }
    }

    private bool MethodHasDoubleEnumerable<T>(Func<IEnumerable<T>, IEnumerable<T>> testMethod)
    {
        var fakeEnumerable = new FakeEnumerable<T>();
        testMethod(fakeEnumerable);
        return fakeEnumerable.EnumerationCount > 1;
    }
}