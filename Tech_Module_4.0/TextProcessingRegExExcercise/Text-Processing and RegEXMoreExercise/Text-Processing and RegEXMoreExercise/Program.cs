using System;
using System.Text.RegularExpressions;

namespace Text_Processing_and_RegEXMoreExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            bool hasName = false;
            string name = string.Empty;
            string age = string.Empty;
            bool hasAge = false;
            int startIndexName = 0;
            int startAge = 0;

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                for (int j = 0; j < input.Length; j++)
                {
                    if (input[j] == '@')
                    {
                        hasName = true;
                        startIndexName = j+1;
                    }
                    if (input[j] == '|' && hasName)
                    {
                        name = input.Substring(startIndexName, j - startIndexName);
                    }
                    if (input[j] == '#')
                    {
                        hasAge = true;
                        startAge = j+1;

                    }
                    if (input[j] == '*' && hasAge)
                    {
                        age = input.Substring(startAge, j - startAge);
                    }
                }

                if (hasAge&&hasName)
                {
                    Console.WriteLine($"{name} is {age} years old.");
                }
            }
        }
    }
}
