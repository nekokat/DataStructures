using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStructures
{
    public record LinkedList<T> where T: class
    {
        Node<T> head;
        Node<T> current;
        int count;

        public int Count {  get => count; private set => count = value; }

        public Node<T> Current { get => current; private set => current = value; }
        public Node<T> Head { get => head; private set => head = value; }

        public LinkedList(T data) 
        {
            if (head is default(T) || head is null)
            {
                Head = new Node<T>(data);
                Current = Head;
                Count += 1;
            }
        }

        public LinkedList() : this(default(T)){}
        
        public Node<T>? Next { get => current.Next; set => current.Next = value;}

        public void AddAfter(T value)
        {
            if (Next is null)
            {
                Next = new Node<T>(value);
            }
            else
            {
                var newValue = new Node<T>(value)
                {
                    Next = this.Next
                };

                Next = newValue;
            }
            Count += 1;
        }

        public void AddAfter(Node<T> linkedList)
        {
            if (Next is null)
            {
                Next = linkedList;
            }
            else
            {
                linkedList.Next = Next;
                Next = linkedList;
            }
            Count += 1;
        }
    }
}