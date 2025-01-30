using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedListBase
{
    public interface INext<T> where T : class
    {
        public Node<T>? Next { get; set;}
    }
}