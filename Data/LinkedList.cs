using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStructures
{
    public record LinkedList<T> where T: class
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
            Node<T>? value = default;

            foreach (T item in data)
            {
                value = new(item);

                if (head is null)
                {
                    Head = value;
                    current = Head;         
                }
                else
                {
                    AddAfter(value);
                }
                current = Next;
            }
            Current = Head;
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

        public void AddAfter(T? value)
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

        public void AddAfter(Node<T>? node)
        {
            AddAfter(node?.Data ?? default);
        }
    }
}