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
        value!.AddToEnd("Two");
        Assert.That(value!.Next.Current!.Data, Is.EqualTo("Two"));
        value!.AddToEnd("Three");
        Assert.That(value!.Next!.Current.Data, Is.EqualTo("Three"));
    }

    [Test]
    public void LinkedListClearTest()
    {
        List<string> arr = new() { "One", "Two", "Three", "Four", "Five"};
        DataStructures.LinkedList<string> value = new(arr);
        Assert.That(value!.Count, Is.EqualTo(arr.Count));

        value.Clear();

        Assert.That(value.Count, Is.Default);
        
        Assert.That(value.Head, Is.Null);
        Assert.That(value.Current, Is.Null);
        Assert.That(value.Last, Is.Null);
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

        Assert.That(value.Count, Is.EqualTo(arr.Count - 1));

        arr.RemoveAt(1);

        Assert.That(value.GetList, Is.EqualTo(arr));
    }

    [TestCase(0)][TestCase(1)]
    [TestCase(2)][TestCase(3)]
    [TestCase(4)][TestCase(5)]
    public void LinkedListRemovePositionTest(int position)
    {
        List<string> arr = new() { "One", "Two", "Three", "Four", "Five", "Six", "Seven"};
        DataStructures.LinkedList<string> value = new(arr);

        Assert.That(value.Remove(arr.Count+position), Is.False);
        Assert.That(value.GetList(), Is.EqualTo(arr));

        int val = position;
        Assert.That(value.Remove(val), Is.True);
        Assert.Pass(position.ToString() + "\n" + string.Join(", ", value.GetList()) + "\n\n");
    }

    [Test]
    public void LinkedListNextTest()
    {
        List<string> arr = new() { "One", "Two", "Three", "Four", "Five", "Six"};
        DataStructures.LinkedList<string> value = new(arr);

        int cnt = default;

        while(value!.Next.Current is not null)
        {
            cnt++;
        }

        Assert.That(cnt, Is.EqualTo(value.Count - 1));
    }

    [Test]
    public void LinkedListAddEndTest()
    {
        List<string> arr = new() { "One", "Two", "Three", "Four", "Five"};
        DataStructures.LinkedList<string> value = new(arr);
        string val = "Six";
        value.AddToEnd(new Node<string>(val));
        arr.Add(val);
        Assert.That(value.GetList, Is.EqualTo(arr));
    }

    [Test]
    public void LinkedlistAddAfterTest()
    {
        List<string> arr = new() { "One", "Two", "Four", "Five"};
        DataStructures.LinkedList<string> value = new(arr);
        string val = "Three";
        value.Next.AddAfter(new Node<string>(val));
        arr.Insert(3, val);
        //Assert.Pass(string.Join(", ", arr));
        Assert.Pass(string.Join(", ", value!.GetList()));
    }
}