using DataStructures;
using System.Linq;

namespace Tests;

public class LinkedListTests
{
    DataStructures.LinkedList<string> Value { get; set; }
    static List<string>? ValueData { get; set; }
    DataStructures.LinkedList<string> CircularValue { get; set; }

    [SetUp]
    public void SetUp()
    {
        ValueData = new() { "One", "Two", "Three", "Four", "Five"};
        Value = new(ValueData);
        CircularValue = new(ValueData, true);
    }

    [TestCase("One")]
    [TestCase("Two")]
    [TestCase("Three")]
    public void LinkedListStringDataTest(string value)
    {
        DataStructures.LinkedList<string> linkedList = new(value);
        Assert.That(linkedList!.Current!.Data, Is.EqualTo(value));
    }

    [Test]
    public void LinkedListAddDataTest()
    {
        DataStructures.LinkedList<string> value = new("One");
        Assert.That(value!.Head!.Data, Is.EqualTo("One"));
        value!.AddToEnd("Two");
        Assert.That(value!.Next.Current!.Data, Is.EqualTo("Two"));
        value!.AddToEnd("Three");
        Assert.That(value!.Next!.Current.Data, Is.EqualTo("Three"));
    }

    [Test]
    public void LinkedListClearTest()
    {
        Assert.That(Value!.Count, Is.EqualTo(Value.Count));

        Value.Clear();

        Assert.That(Value.Count, Is.Default);
        
        Assert.That(Value.Head, Is.Null);
        Assert.That(Value.Current, Is.Null);
        Assert.That(Value.Last, Is.Null);
    }

    [Test]
    public void LinkedListCollectionTest()
    {
        List<string> list = new List<string>(){"Two", "Three"};
        DataStructures.LinkedList<string> val = new(list);
        Assert.That(Value.Count, Is.Not.Default);
        Value.Clear();
        Assert.That(Value!.Head, Is.Null);
        Value.Add(list.ToArray());
        Assert.That(Value.Count, Is.EqualTo(list.Count));
    }

    [Test]
    public void LinkedListCurrentDataTest()
    {
        foreach(string value in ValueData!.Skip(1)){
            Assert.That(Value.Next.Data, Is.EqualTo(value));
        }
    }

    [Test]
    public void LinkedlistContainsTest()
    {
        foreach (string value in ValueData!){
            Assert.That(Value.Contains(value), Is.True);
        }
    }

    [TestCase("Zero")]
    [TestCase("One")]
    [TestCase("Two")]
    public void LinkedListAddToHeadTest(string value)
    {
        Node<string> node = new (value);
        Value.AddToHead(node);
        Assert.That(Value.Head!.Data, Is.EqualTo(value));
    }

    [Test]
    public void LinkedListToListTest()
    {  
        Assert.That(Value.GetList, Is.EqualTo(ValueData));
    }

    [Test]
    public void LinkedListRemoveItemTest()
    {
        Assert.That(Value.Remove("Six"), Is.False);
        Assert.That(Value.Remove("Two"), Is.True);
        
        ValueData!.RemoveAt(1);

        Assert.That(Value.Count, Is.EqualTo(ValueData.Count));
        Assert.That(Value.GetList(), Is.EqualTo(ValueData));
    }

    private static IEnumerable<int> RemovePositionData()
    {
        foreach(int i in Enumerable.Range(0, 4))
        {
            yield return i;
        }
    }

    [TestCaseSource(nameof(RemovePositionData))]
    public void LinkedListRemovePositionTest(int position)
    {
        Assert.That(Value.GetList(), Is.EqualTo(ValueData));
        Assert.That(Value.Remove(position), Is.True);
    }

    [Test]
    public void LinkedListNextTest()
    {
        int cnt = default;

        while(Value.Next.Current is not null)
        {
            cnt++;
        }

        Assert.That(cnt, Is.EqualTo(Value.Count - 1));
    }

    [TestCase("Six")]
    public void LinkedListAddEndTest(string val)
    {
        Value.AddToEnd(new Node<string>(val));
        ValueData!.Add(val);
        Assert.That(Value.GetList, Is.EqualTo(ValueData));
    }

    [TestCase("Zero", 0)]
    [TestCase("NewOne", 1)]
    [TestCase("NewTwo", 2)]
    [TestCase("NewThree", 3)]
    public void LinkedlistAddAfterTest(string value, int position)
    {
        Enumerable.Range(default, position).ToList().ForEach(x => Value.Next.Cast<string>());

        Value.AddAfter(new Node<string>(value));
        ValueData!.Insert(++position, value);

        Assert.That(Value.GetList(), Is.EqualTo(ValueData));
    }

    [Test]
    public void LinkedListIsCircularTest()
    {
        Assert.That(Value.IsCircular, Is.False);
        Assert.That(CircularValue.IsCircular, Is.True);
    }
}