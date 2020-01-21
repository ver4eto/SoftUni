using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] expression = input.Split(" ",StringSplitOptions.RemoveEmptyEntries);
            Stack<string> stack = new Stack<string>(expression.Reverse());
           
            while (stack.Count>1)
            {
                int operandOne = int.Parse(stack.Pop());
                string opr = stack.Pop();
                int operandTwo = int.Parse(stack.Pop());

                switch (opr)
                {
                    case "+":
                        stack.Push($"{operandOne+operandTwo}");
                        break;
                    case "-":
                        stack.Push($"{operandOne - operandTwo}");
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine(stack.Pop());

        }
    }
}
