using System;
using System.Collections.Generic;
using System.Linq;

namespace Stacks_and_QueuesExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int push = numbers[0];
            int pop = numbers[1];
            int isPresent = numbers[2];

            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> myStack = new Stack<int>();

            for (int i = 0; i < push; i++)
            {
                myStack.Push(input[i]);
            }
            for (int i = 0; i < pop && myStack.Count>0; i++)
            {
                myStack.Pop();
            }
            if (myStack.Contains(isPresent))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (myStack.Count==0)
                {
                    Console.WriteLine("0");
                }
                else
                {
                    Console.WriteLine($"{myStack.Min()}");
                }
            }
        }
    }
}
