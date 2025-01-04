using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStructures
{
    public interface INext<T> where T : class
    {
        public Item<T>? Next { get; set;}
    }
}