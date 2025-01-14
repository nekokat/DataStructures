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
        
        public Node<T>? Next
        {
            get {Current = Current!.Next; return Current;}
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

        public void AddToTail(Node<T> node)
        {
            Last!.Next = node;
            Last = Last!.Next;
        }

        public void AddToTail(T item)
        {
            Node<T> node = new Node<T>(item);
            AddToTail(node);
        }

        public void AddToHead(T item)
        {
            Node<T> node = new Node<T>(item);
             AddToHead(node);
        }
        
        public void AddToHead(Node<T> node)
        {
            Node<T> tempNode = Head!;
            Head = node;
            Head.Next = tempNode;
            Current = Head;
        }

        public void AddAfter(Node<T> node)
        {
            node.Next = Current!.Next;
            Current!.Next = node;
        }

        public void AddAfter(T item)
        {
            Node<T> node = new Node<T>(item);
            AddAfter(node);
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
                Head = node;
                Current = Head;
                Last = Head;

            }
            else
            {
                Last!.Next = node;
                Last = node;
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

        public bool Remove(T item)
        {
            int cnt = 0;

            if (item == Head!.Data)
            {
                Head = Head!.Next;
                return true;
            }

            if(!Contains(item))
            {
                return false;
            }

            while(Current!.Next! != null)
            {
                if(Current.Data == item)
                {
                    Last!.Next = null;
                    break;
                }
                else{
                    Last = Current;
                    Current = Current!.Next;
                    cnt++;
                }

                if(Count == cnt)
                {
                    return false;
                }
            }            

            Current = Head;
            Count = cnt;
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