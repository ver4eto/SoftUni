using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _4._Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder final = new StringBuilder();
            Stack<string> stack = new Stack<string>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i]=='(')
                {
                    stack.Push(i.ToString());
                }
                else if (input[i]==')')
                {
                    int index =int.Parse( stack.Pop());
                   
                    final.Append(input, index, (i - index + 1));
                    final.AppendLine();
                }
            }
            Console.WriteLine(final);
        }
    }
}
