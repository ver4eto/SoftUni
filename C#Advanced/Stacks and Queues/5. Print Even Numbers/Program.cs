using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Print_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                  .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                  .Select(int.Parse)
                  .ToArray();

            Queue<int> myNumbers = new Queue<int>();

            //for (int i = 0; i < myNumbers.Count; i++)
            //{
            //    int current = myNumbers.Peek();
            //    if (current%2 !=0)
            //    {
            //        myNumbers.Dequeue();
            //    }
            //}

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] % 2 == 0)
                {
                    myNumbers.Enqueue(input[i]);
                }
            }

            Console.WriteLine(string.Join(',', myNumbers));
        }
    }
}
