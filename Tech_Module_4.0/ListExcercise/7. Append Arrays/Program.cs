using System;
using System.Linq;
using System.Collections.Generic;

namespace _7._Append_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                 .Split('|')
                 .Reverse()
                 .ToList();

            List<string> appendList = new List<string>();

            foreach (var item in input)
            {
                appendList.AddRange(item.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList());
            }

          
            Console.WriteLine(string.Join(" ",appendList));
        }
    }
}
