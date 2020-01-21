using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            HashSet<string> periodicTable = new HashSet<string>();

            for (int i = 0; i < number; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int j  = 0; j < input.Length; j++)
                {
                    string ccurrent = input[j];
                    periodicTable.Add(ccurrent);
                }
            }

            foreach (var item in periodicTable.OrderBy(x=>x))
            {
                Console.Write(item+" ");
            }
            Console.WriteLine();
        }
    }
}
