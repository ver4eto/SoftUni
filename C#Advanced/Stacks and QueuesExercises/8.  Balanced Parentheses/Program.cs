using System;
using System.Linq;
using System.Collections.Generic;

namespace _8.__Balanced_Parentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<char> parantheses = new Stack<char>();

            char[] input = Console.ReadLine().ToCharArray();
            bool isBalanced = false;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(' || input[i] == '{' || input[i] == '[')
                {
                    parantheses.Push(input[i]);
                }
                else if (input[i] == ')' || input[i] == '}' || input[i] == ']')
                {
                    if (parantheses.Count>0)
                    {
                        char cuurent = parantheses.Pop();

                        if (cuurent == '(' && input[i] == ')'
                            || cuurent == '{' && input[i] == '}'
                            || cuurent == '[' && input[i] == ']')
                        {
                            isBalanced = true;
                        }
                        else
                        {
                            isBalanced = false;
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                                                    
                  
                }
                else
                {
                    isBalanced = false;
                    break;
                }
            }
            if (isBalanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
