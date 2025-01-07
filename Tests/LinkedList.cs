using DataStructures;

namespace Tests;

public class LinkedListTests
{

    [TestCase("One")]
    [TestCase("Two")]
    [TestCase("Three")]
    public void LinkedListStringDataTest(string value)
    {
        DataStructures.LinkedList<string> linkedList = new(value);
        Assert.That(linkedList?.Current?.Data, Is.EqualTo(value));
    }

    [Test]
    public void LinkedListAddDataTest()
    {
        var value = new DataStructures.LinkedList<string>("One");
        value.AddAfter("Two");
        Assert.That(value?.Next?.Data, Is.EqualTo("Two"));
        value?.AddAfter("Three");
        Assert.That(value?.Next?.Data, Is.EqualTo("Three"));
        Assert.That(value?.Next?.Next?.Data, Is.EqualTo("Two"));
    }

    [Test]
    public void LinkedListArrayTest()
    {
        List<string> arr = new() { "One", "Two", "Three", "Four", "Five"};
        DataStructures.LinkedList<string> value = new(arr.ToArray());
        System.Console.WriteLine(string.Join(", ", value.List()));
        Assert.That(value.List(), Is.EqualTo(arr));
    }
}