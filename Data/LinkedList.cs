using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStructures
{
    public record LinkedList<T> : Item<T>, INext<T> where T: class
    {
        public LinkedList(T data) 
        {
            Data = data;
        }
        
        public LinkedList<T>? Next { get; set; }

        public void Add(T value)
        {
            if (Next is null)
            {
                Next = new LinkedList<T>(value);
            }
            else
            {
                var newValue = new LinkedList<T>(value)
                {
                    Next = this.Next
                };
                
                Next = newValue;
            }
        }
    }
}