using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedListBase
{
    public interface IData<T> where T : class
    {
        T? Data { get; set;}
    }
}