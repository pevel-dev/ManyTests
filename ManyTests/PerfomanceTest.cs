using NUnit.Framework;

namespace ManyTests;

public class PerformanceTests
{
    public static bool RunWithTimeout<T>(Action<Func<IEnumerable<T>, IEnumerable<T>>> method, Func<IEnumerable<T>, IEnumerable<T>> arg, int timeout)
    {
        var task = Task.Run(() => method(arg));
        return task.Wait(timeout);
    }
}