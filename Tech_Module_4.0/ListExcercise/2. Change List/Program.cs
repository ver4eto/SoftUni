using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Change_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToList();

            string[] command = Console.ReadLine()
                .Split()
                .ToArray();

            while (command[0]!="end")
            {
                string action = command[0];
                int element = int.Parse(command[1]);
                switch (action)
                {
                    case "Delete":                        
                        numbers.RemoveAll(x=>x==element);
                        break;
                    case "Insert":
                        int index = int.Parse(command[2]);
                        numbers.Insert(index, element);
                        break;
                    default:
                        break;
                }

                command = Console.ReadLine()
                    .Split()
                    .ToArray();
            }
            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
