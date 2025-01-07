using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStructures
{
    public record LinkedList<T> : ICollection<T>, ICollection where T: class
    {
        Node<T>? head;
        Node<T>? current;
        protected int count;

        public int Count => count;

        public Node<T>? Current { get => current; set => current = value; }
        public Node<T>? Head { get => head; set => head = value; }
        
        public Node<T>? Next
        {
            get => current?.Next;
            set => (current = new Node<T>(default)).Next = value;
        }

        public bool IsReadOnly => throw new NotImplementedException();

        public bool IsSynchronized => throw new NotImplementedException();

        public object SyncRoot => throw new NotImplementedException();

        public LinkedList() : this(default(T)){}


        public LinkedList(T? data) 
        {
            if (head is default(T) || head is null)
            {
                Head = new Node<T>(data);
                Current = Head;
            }
        }

        public LinkedList(T[] data)
        {
            Add(data);
        }

        private void Add(T[] data)
        {
            foreach (T item in data)
            {
                Add(item);
            }
        }

        public List<T?>? List()
        {
            List<T?>? list = [];
            Node<T>? current = Head;

            do
            {
                list.Add(current?.Data);
                current = Next;
            } while (current?.Next is not null);

            return list;
        }

        public void AddLast(T? value)
        {   
            if (current?.Next is null)
            {
                Next = new Node<T>(value);
            }
            else
            {
                Node<T> newNode = new(value);
                newNode.Next = current?.Next;
                Next = newNode;
            }
            count++;
        }

        public void AddLast(Node<T>? node)
        {
            AddLast(node?.Data ?? default);
        }

        public void Add(T item)
        {
            AddLast(item);
        }

        public void Clear()
        {
            this.Head = new Node<T>(default);
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

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }
    }
}