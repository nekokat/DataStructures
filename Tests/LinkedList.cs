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
        DataStructures.LinkedList<string> value = new("One");
        Assert.That(value!.Head!.Data, Is.EqualTo("One"));
        value.Clear();
        value.Add("Two");
        Assert.That(value!.Head!.Data, Is.EqualTo("Two"));
        value!.Add("Three");
        Assert.That(value!.Last!.Data, Is.EqualTo("Three"));
        Assert.That(value!.Next!.Data, Is.EqualTo("Three"));
    }

    [Test]
    public void LinkedListArrayTest()
    {
        List<string> arr = new() { "One", "Two", "Three", "Four", "Five"};
        DataStructures.LinkedList<string> value = new(arr.ToArray());
        System.Console.WriteLine(string.Join(", ", value.GetList));
        Assert.That(value.GetList, Is.EqualTo(arr));
    }
}