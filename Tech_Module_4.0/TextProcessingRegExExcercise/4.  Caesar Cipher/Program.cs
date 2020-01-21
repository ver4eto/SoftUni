using System;
using System.Text;

namespace _4.__Caesar_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder finalResult = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                char current = input[i];
                int updatedChar = (int)current + 3;
                finalResult.Append((char)updatedChar);
            }
            Console.WriteLine(finalResult);
        }
    }
}
