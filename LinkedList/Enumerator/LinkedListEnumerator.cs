using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStructures
{
    public class LinkedListEnumerator<T> : IEnumerator<T> where T : class
    {
        private LinkedList<T>? _list;

        protected LinkedList<T>? LinkedList {get => _list; private set => _list = value; }

        public LinkedListEnumerator(LinkedList<T> linkedList)
        {
            LinkedList = linkedList;
        }

        public T Current => LinkedList!.Current!.Data!;

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            return LinkedList!.Next.Current!.Data != null;
        }

        public void Reset()
        {
            LinkedList!.Reset();
        }
    }
}