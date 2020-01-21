using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace _8._Anonymous_Threat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                  .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                  .ToList();
            string[] command = Console.ReadLine().Split();



            while (command[0] != "3:1")
            {
                string action = command[0].ToString();
                switch (action)
                {
                    case "merge":
                        int startIndex = int.Parse(command[1].ToString());
                        int endIndex = int.Parse(command[2].ToString());
                        if (startIndex < 0)
                        {
                            startIndex = 0;
                        }
                        if (endIndex > input.Count - 1)
                        {
                            endIndex = input.Count - 1;
                        }
                        if (startIndex>input.Count-1 || endIndex<0)
                        {
                            command = Console.ReadLine().Split();
                            continue;
                        }
                        MergeElements(startIndex, endIndex, input);
                        break;
                    case "divide":
                        int index = int.Parse(command[1].ToString());
                        int partitions = int.Parse(command[2].ToString());
                        string wordForManipulation = input[index];
                      List<string> newInput=  DivideElements(partitions, wordForManipulation);
                        input.RemoveAt(index);
                        input.InsertRange(index, newInput);
                        break;
                    default:
                        break;
                }
                command = Console.ReadLine().Split();
            }
            Console.WriteLine(string.Join(" ", input));
        }

        private static List<string> DivideElements(int partition, string word)
        {
            
            int count = word.Length / partition;
            int lastCount =count+ word.Length % partition;

            List<string> manipulatedWord = new List<string>();

            for (int i = 0; i < partition; i++)
            {
                string element = word.Substring(i * count, count);
                if (i==partition-1)
                {
                    element = word.Substring(i * count, lastCount);
                }
                manipulatedWord.Add(element);
            }
            return manipulatedWord;
            
        }

        private static void MergeElements(int startIndex, int endIndex, List<string> input)
        {
            StringBuilder mergedText = new StringBuilder();

            for (int i = startIndex; i <= endIndex; i++)
            {
                mergedText.Append(input[i]);
            }

            input.RemoveRange(startIndex, endIndex - startIndex + 1);
            input.Insert(startIndex, mergedText.ToString());
        }
    }
}
