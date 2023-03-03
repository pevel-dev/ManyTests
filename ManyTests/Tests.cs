using NUnit.Framework;

namespace ManyTests;

[TestFixture]
public class Tests
{


    [Test]
    public void IsLazy()
    {
        throw new NotImplementedException();
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