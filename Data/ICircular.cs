using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStructures
{
    public interface ICircular<T> where T : class
    {
        public bool IsCircular { get; set;}
    }
}