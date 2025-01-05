namespace Tests;

public class LinkedListTests
{

    [TestCase("One")]
    [TestCase("Two")]
    [TestCase("Three")]
    public void LinkedListStringDataTest(string value)
    {
        Assert.That(new DataStructures.LinkedList<string>(value).Data, Is.EqualTo(value));
    }

    [Test]
    public void LinkedListAddDataTest()
    {
        var value = new DataStructures.LinkedList<string>("One");
        value.Add("Two");
        Assert.That(value?.Next?.Data, Is.EqualTo("Two"));
        value?.Add("Three");
        Assert.That(value?.Next?.Data, Is.EqualTo("Three"));
        Assert.That(value?.Next?.Next?.Data, Is.EqualTo("Two"));
    }
}