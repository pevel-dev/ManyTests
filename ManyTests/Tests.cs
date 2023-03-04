using System.Collections;
using NUnit.Framework;
using NUnit.Framework.Internal;
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
    
    private bool MethodHasDoubleEnumerable<T>(Func<IEnumerable<T>, IEnumerable<T>> testMethod)
    {
        var fakeEnumerable = new FakeEnumerable<T>();
        testMethod(fakeEnumerable);
        return fakeEnumerable.EnumerationCount > 1;
    }
}