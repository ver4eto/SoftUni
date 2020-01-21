using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] actions = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToArray();

            int add = actions[0];
            int remove = actions[1];
            int isPresent = actions[2];

            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> myQueue = new Queue<int>();

            for (int i = 0; i < add; i++)
            {
                myQueue.Enqueue(numbers[i]);
            }
            for (int i = 0; i < remove && myQueue.Count>0; i++)
            {
                myQueue.Dequeue();
            }

            if (myQueue.Contains(isPresent))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (myQueue.Count==0)
                {
                    Console.WriteLine("0");
                }
                else
                {
                    Console.WriteLine($"{myQueue.Min()}");
                }
            }
        }
    }
}
