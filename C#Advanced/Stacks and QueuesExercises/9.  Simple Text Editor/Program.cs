using System;
using System.Collections.Generic;
using System.Linq;

namespace _9.__Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int operationsCount = int.Parse(Console.ReadLine());
            Stack<string> textUpdated = new Stack<string>();
            Stack<string> nonUpdated = new Stack<string>();

            for (int i = 0; i < operationsCount; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = input[0];

                switch (command)
                {
                    case "1":
                        string data = input[1];
                        for (int k = 0; k < data.Length; k++)
                        {
                            nonUpdated.Push(data[k].ToString());
                        }
                        //nonUpdated.Push(data);
                        break;
                    case "2":
                        int countOfErase = int.Parse(input[1]);
                        for (int j = 0; j < countOfErase && nonUpdated.Count>0; j++)
                        {
                            nonUpdated.Peek();
                        }
                        break;
                    case "3":
                        int index = int.Parse(input[1]);
                        for (int j = 0; j < index; j++)
                        {
                            string current = nonUpdated.Pop();
                            if (j==index-1)
                            {
                                Console.WriteLine(current);
                            }
                            nonUpdated.Push(current);
                        }
                        break;
                    case "4":
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
