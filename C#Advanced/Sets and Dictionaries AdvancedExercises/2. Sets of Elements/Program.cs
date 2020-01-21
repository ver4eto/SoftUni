using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizeOfSets = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int firstSetLenght = sizeOfSets[0];
            int secondSetLenght = sizeOfSets[1];
            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();

            for (int i = 0; i < firstSetLenght+secondSetLenght; i++)
            {
                int input = int.Parse(Console.ReadLine());
                if (i<firstSetLenght)
                {
                    firstSet.Add(input);
                }
                else
                {
                    secondSet.Add(input);
                }
            }

            foreach (var item in firstSet)
            {
                if (secondSet.Contains(item))
                {
                    Console.Write(item+" ");
                }
            }
            Console.WriteLine();
        }
    }
}
