using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStructures
{
    public class LinkedList<T> : ICollection<T>, ICollection where T: class
    {
        Node<T>? head;
        Node<T>? current;
        Node<T>? last;

        protected int count;
        List<T?> list = new();

        public int Count => count;

        public Node<T>? Current { get => current; set => current = value; }
        public Node<T>? Head { get => head; set => head = value; }
        
        public Node<T>? Next
        {
            get => Current?.Next;
            set => Current!.Next = value;
        }

        public bool IsReadOnly => throw new NotImplementedException();

        public bool IsSynchronized => throw new NotImplementedException();

        public object SyncRoot => throw new NotImplementedException();

        public LinkedList() : this(default(T )){}


        public LinkedList(T? data) 
        {
            Head = new Node<T>(data);
            Current = Head;
        }

        public LinkedList(T[] data)
        {
            Add(data);
        }

        private void Add(ICollection<T> data)
        {
            foreach (T item in data)
            {
                Add(item);
            }
        }

        public List<T?> GetList => list;


        public void AddLast(Node<T>? node)
        {

        }

        public void Add(T item)
        {   
            if(Head == null)
            {
                Head = new Node<T>(item);
                Current = Head;

            }
            else if (Next == null)
            {
                Node<T> node = new(item);
                Current!.Next = node;
            }
            count++;
        }

        public void Clear()
        {
            Head = null;
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
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