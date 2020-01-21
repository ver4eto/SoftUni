using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Reverse_and_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {           

            Func<int,int, bool> first =( x,y) => x % y != 0;
                       

            List<int> input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                //.Where(first)
                .ToList();

            int numberForDivision = int.Parse(Console.ReadLine());

          List<int> revisedInput= new List<int>();
            for (int i = input.Count - 1; i >= 0; i--)
            {
                if (first(input[i],numberForDivision))
                {
                    revisedInput.Add(input[i]);
                }
            }

            Console.WriteLine(string.Join(" ",revisedInput));
        }
    }
}
