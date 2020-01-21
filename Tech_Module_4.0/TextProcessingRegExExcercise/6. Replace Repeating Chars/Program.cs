using System;

namespace _6._Replace_Repeating_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                if (i < input.Length - 1)
                {
                    if (input[i] == input[i + 1])
                    {
                        string curr = input[i].ToString();
                        int index = input.IndexOf(curr, i);

                        input = input.Remove(index + 1, 1);
                        i--;

                    }
                }
               
            }
            Console.WriteLine(input);
        }
    }
}
