using System;

namespace _2._Ascii_Sumator
{
    class Program
    {
        static void Main(string[] args)
        {
            char start = char.Parse(Console.ReadLine());
            char end = char.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            int sum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                char current = input[i];
                if (current>start&&current<end)
                {
                    sum += (int)current;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
