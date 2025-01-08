using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataStructures;

namespace DataStructures
{
    public class Node<T> : Item<T>, INext<T> where T : class
    {
        public Node(T? value)
        {
            Data = value;
        }

        public Node<T>? Next { get; set; }
    }
}