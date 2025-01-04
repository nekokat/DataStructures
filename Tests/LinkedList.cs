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
}