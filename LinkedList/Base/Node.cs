using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataStructures;

namespace LinkedListBase
{
    public class Node<T> : Item<T>, INext<T>, IPrev<T>  where T : class
    {
        public Node(T? value)
        {
            Data = value;
        }

        public Node<T>? Next { get; set; }

        public Node<T>? Previous { get; set; }
    }
}