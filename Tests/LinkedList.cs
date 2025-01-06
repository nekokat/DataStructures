namespace Tests;

public class LinkedListTests
{

    [TestCase("One")]
    [TestCase("Two")]
    [TestCase("Three")]
    public void LinkedListStringDataTest(string value)
    {
        Assert.That(new DataStructures.LinkedList<string>(value).Current.Data, Is.EqualTo(value));
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
}