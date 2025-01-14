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
        Assert.That(linkedList!.Current!.Data, Is.EqualTo(value));
    }

    [Test]
    public void LinkedListAddDataTest()
    {
        DataStructures.LinkedList<string> value = new("One");
        Assert.That(value!.Head!.Data, Is.EqualTo("One"));
        value!.Add("Two");
        Assert.That(value!.Next!.Data, Is.EqualTo("Two"));
        value!.Add("Three");
        Assert.That(value!.Last!.Data, Is.EqualTo("Three"));
        Assert.That(value!.Current!.Next!.Data, Is.EqualTo("Three"));
    }

    [Test]
    public void LinkedListClearTest()
    {
        DataStructures.LinkedList<string> value = new("One");
        value!.Add(new List<string>(){"Two", "Three"});
        Assert.That(value!.Count, Is.EqualTo(3));
        value.Clear();
        Assert.That(value!.Count, Is.Default);
        Assert.That(value!.Head, Is.Null);
        Assert.That(value!.Current, Is.Null);
        Assert.That(value!.Last, Is.Null);
    }

    [Test]
    public void LinkedListCollectionTest()
    {
        List<string> list = new List<string>(){"Two", "Three"};
        DataStructures.LinkedList<string> value = new(list);
        Assert.That(value!.Count, Is.EqualTo(list.Count));
        value.Clear();
        Assert.That(value!.Head, Is.Null);
        value.Add(list.ToArray());
        Assert.That(value!.Count, Is.EqualTo(list.Count));
    }


    [Test]
    public void LinkedListArrayTest()
    {
        List<string> arr = new() { "One", "Two", "Three", "Four", "Five"};
        DataStructures.LinkedList<string> value = new(arr);
        Assert.That(value.GetList(), Is.EqualTo(arr));
    }

    [Test]
    public void LinkedListRemoveItemTest()
    {
        
        List<string> arr = new() { "One", "Two", "Three", "Four", "Five"};
        DataStructures.LinkedList<string> value = new(arr);

        Assert.That(value.Remove("Six"), Is.False);
        Assert.That(value.Remove("Two"), Is.True);

        Assert.That(value.Count, Is.EqualTo(1));

        Assert.That(value.GetList(), Is.EqualTo([arr[0]]));
    }

    [TestCase(0)]
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    public void LinkedListRemovePositionTest(int position)
    {
        List<string> arr = new() { "One", "Two", "Three", "Four", "Five"};
        DataStructures.LinkedList<string> value = new(arr);

        Assert.That(value.Remove(arr.Count+position), Is.False);
        Assert.That(value.GetList(), Is.EqualTo(arr));

        int val = position%arr.Count;

        Assert.That(value.Remove(val), Is.True);
        Assert.That(value.Count, Is.EqualTo(val));
        Assert.That(value.GetList(), Is.EqualTo(arr.Take(val)));
    }

    [Test]
    public void LinkedListNextTest()
    {
        List<string> arr = new() { "One", "Two", "Three", "Four", "Five", "Six"};
        DataStructures.LinkedList<string> value = new(arr);

        int cnt = default;

        while(value!.Next is not null)
        {
            cnt++;
        }

        Assert.That(cnt, Is.EqualTo(value.Count - 1));
    }
}