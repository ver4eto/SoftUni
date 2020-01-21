using System;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;


namespace _2._Deciphering
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputToDecrypt = Console.ReadLine();
            string[] wordsForreplacement = Console.ReadLine().Split(" ").ToArray();

            StringBuilder decrypted = new StringBuilder();
            //string pattern = @"^[d-z#|{}]+";
            //Regex regex = new Regex(pattern);
            bool isValid = true;

            for (int i = 0; i < inputToDecrypt.Length; i++)
            {
                char current = inputToDecrypt[i];
                if (current >= 100 && current <= 122 || current == '{'|| current == '}' || current == '#' || current == '|')
                {
                    isValid = true;                   

                }
                else
                {
                    isValid = false;
                    break;
                }
               
            }
            if (isValid)
            {
                for (int i = 0; i < inputToDecrypt.Length; i++)
                {
                    int current = inputToDecrypt[i];
                    int final = current - 3;
                    decrypted.Append((char)final);
                }
              
                string toFind = wordsForreplacement[0];
                string toReplace = wordsForreplacement[1];

                decrypted.Replace(toFind, toReplace);
                Console.WriteLine(decrypted);
            }
            else
            {
                Console.WriteLine("This is not the book you are looking for.");
            }
           
        }
    }
}
