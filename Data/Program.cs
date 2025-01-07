using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
            DataStructures.LinkedList<string> linkedList = new(arr.ToArray());
            System.Console.WriteLine(string.Join(", ", linkedList.List()));
        }
        
    }
}