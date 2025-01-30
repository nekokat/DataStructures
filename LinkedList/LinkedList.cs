using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinkedListBase;

namespace DataStructures
{
    public class LinkedList<T> : ICollection<T>, ICollection where T: class
    {
        protected Node<T>? head;
        protected Node<T>? current;
        protected Node<T>? last;

        protected int count;

        public int Count { get => count; private set => count = value; }

        public Node<T>? Last { get => last; private set => last = value; }
        public Node<T>? Current { get => current; private set => current = value; }
        public Node<T>? Head { get => head; private set => head = value; }

        public T Data => Current!.Data!;
        
        public LinkedList<T> Next
        {
            get { Current = Current!.Next; return this; }
        }

        protected bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public bool IsSynchronized
        {
            get
            {
                return false;
            }
        }

        public object SyncRoot => this;

        bool ICollection<T>.IsReadOnly => IsReadOnly;


        public LinkedList(T data)
        {
            Add(data);         
        }

        public LinkedList(ICollection<T> data) 
        {
            Add(data);
        }

        public void AddToEnd(T item)
        {
            Node<T> node = new(item);
            AddToEnd(node);
        }

        public void AddToEnd(Node<T> node)
        {            
            Last!.Next = node;
            Last = Last!.Next;
        }
        
        public void AddToHead(Node<T> node)
        {
            if (Head is null)
            {   
                Head = node;
                Reset();
                Last = Head;
            }
            else
            {
                Node<T> tempNode = Head!;
                Head = node;
                Head.Next = tempNode;
                Reset();
            }
        }

        public void AddAfter(Node<T> node)
        {
            if (Current == Last)
            {
                AddToEnd(node);
            }

            node.Next = Current!.Next;
            Current!.Next = node;
        }

        public void Add(ICollection<T> data)
        {
            foreach (T item in data)
            {
                Add(item);
            }
        }

        public List<T?> AsList()
        {
            List<T?> lst = new();

            Node<T> current = Head!;

            while(current! != null)
            {
                lst.Add(current!.Data);
                current = current!.Next!;
            }

            return lst;
        }

        public void Add(T item)
        {   
            Node<T> node = new(item);

            if(Head == null)
            {
                AddToHead(node);
            }
            else
            {
                AddToEnd(node);
            }
            Count++;
        }

        public void Clear()
        {
            Head = null;
            Current = null;
            Last = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            return AsList().Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int position)
        {
            List<T> list = AsList()!;

            return Remove(list!.ElementAtOrDefault(position)!);
        }   

        private bool RemoveHead()
        {
            Head = Head!.Next;
            return true;
        }

        public bool Remove(T item)
        {
            Node<T> current = Head!;
            Node<T> last = Head!;

            if (item == Head!.Data)
            {
                Count--;
                return RemoveHead();
            }

            while(current!.Next! != null)
            {
                if(current!.Data != item)
                {
                    current = current.Next;
                }
                else
                {
                    Count--;
                    last!.Next = current!.Next;                    
                    return true;
                }
            }
            
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new LinkedListEnumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            Current = Head;
        }
    }
}