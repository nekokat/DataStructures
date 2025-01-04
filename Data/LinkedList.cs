using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStructures
{
    public record LinkedList<T> : Item<T>, INext<T> where T: class
    {
        public LinkedList(T? data) 
        {
            Data = data;
        }
        
        public Item<T>? Next
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }
    }
}