using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace DataStructures
{
    internal class Program
    { 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            List<string> arr = new() { "One", "Two", "Three", "Four", "Five"};
            DataStructures.LinkedList<string> value = new(arr);
            System.Console.WriteLine(value.IsCircular);
            value.Last!.Next = value.Head;
            System.Console.WriteLine(value.IsCircular);
        }
        
    }
}