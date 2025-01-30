using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedListBase
{
    public interface IPrev<T> where T : class
    {
        public Node<T>? Previous { get; set;}
    }
}