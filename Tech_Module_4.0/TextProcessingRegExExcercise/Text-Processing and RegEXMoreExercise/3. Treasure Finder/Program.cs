using System;
using System.Linq;
using System.Text;

namespace _3._Treasure_Finder
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            string encryptedMessage = Console.ReadLine();
            StringBuilder decryptedMessage = new StringBuilder();
            string typeOfTreasurfe = string.Empty;
            string coordinates = string.Empty;


            while (encryptedMessage!="find")
            {
                for (int i = 0; i < encryptedMessage.Length; i++)
                {
                    //int indexOfNumbers = 0;
                    //if (i>=numbers.Length)
                    //{
                    //    indexOfNumbers = i - numbers.Length;
                    //}
                    if (numbers.Length-1<i)
                    {
                        decryptedMessage.Append(encryptedMessage[i] - numbers[i]);
                    }
                    
                    
                }
                encryptedMessage = Console.ReadLine();
            }
            
        }
    }
}
