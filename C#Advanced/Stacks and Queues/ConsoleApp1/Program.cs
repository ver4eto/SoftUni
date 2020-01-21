using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            Stack<int> stack = new Stack<int>();
            string input = Console.ReadLine();
            

            while (input.ToLower() !="end")
            {
                string[] tokens = input
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0].ToLower();
                switch (command)
                {
                    case "add":
                        for (int i = 1; i < tokens.Length; i++)
                        {
                            stack.Push(int.Parse(tokens[i]));
                        }
                        break;
                    case "remove":
                        int count =int.Parse( tokens[1]);
                        if (count<=stack.Count)
                        {
                            for (int i = 0; i < count; i++)
                            {
                                stack.Pop();
                            }
                        }

                        break;
                    default:
                        for (int i = 0; i < tokens.Length; i++)
                        {
                            stack.Push(int.Parse(tokens[i]));
                        }
                        break;
                }
                input = Console.ReadLine();
            }

            int sum = stack.Sum();

            Console.WriteLine($"Sum: {sum}");
        }
    }
}
