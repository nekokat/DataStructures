using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        
        public LinkedList<T> Next
        {
            get {Current = Current!.Next; return this;}
        }

        public bool IsReadOnly => throw new NotImplementedException();

        public bool IsSynchronized => throw new NotImplementedException();

        public object SyncRoot => this;

        public LinkedList(ICollection<T> data)
        {
            Add(data);
        }

        public LinkedList(T data)
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
                Current = Head;
                Last = Head;
            }
            else
            {
                Node<T> tempNode = Head!;
                Head = node;
                Head.Next = tempNode;
                Current = Head;
            }
        }

        public void AddAfter(Node<T> node)
        {
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

        public List<T?> GetList()
        {
            List<T?> lst = new();

            while(Current! != null)
            {
                lst.Add(Current!.Data);
                Current = Current!.Next;
            }

            Current = Head;

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
            return GetList().Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int position)
        {
            if(position+1 > Count)
            {
                return false;
            }

            List<T> list = GetList()!;

            return Remove(list[position]);
        }   

        private bool RemoveHead()
        {
            Head = Head!.Next;
            return true;
        }

        private bool RemoveEnd(Node<T> node)
        {
            Last = node;
            return true;
        }

        public bool Remove(T item)
        {
            int cnt = 0;
            if (item == Head!.Data)
            {
                return RemoveHead();
            }

            while(Current!.Next! != null)
            {
                cnt++;
                if(Current.Data == item)
                {
                    Last!.Next = null;
                    break;
                }
                else{
                    Last = Current;
                    Current = Current!.Next;
                }
            }
            
            return true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return GetList().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }
    }
}