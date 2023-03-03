using System.Collections;

namespace ManyTests;

public class FakeEnumerable<Item> : IEnumerable<Item>
{
    public int EnumerationCount { get; private set; }
    private const int CountElements = 5;
    public IEnumerator<Item> GetEnumerator()
    {
        EnumerationCount++;
        for (var i = 0; i < CountElements; i++)
        {
            yield return default(Item);
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}