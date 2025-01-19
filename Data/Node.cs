using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataStructures;

namespace DataStructures
{
    public class Node<T> : Item<T>, INext<T>, IEquatable<Node<T>>  where T : class
    {
        public Node(T? value)
        {
            Data = value;
        }

        public Node<T>? Next { get; set; }

        public bool Equals(Node<T>? other)
        {
            return this.Data == other?.Data && this.Next == other?.Next;
        }
    }
}