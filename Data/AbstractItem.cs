using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStructures
{
    public abstract class Item<T> : IData<T> where T : class
    {
        public virtual T? Data {get; set;}
    }
}