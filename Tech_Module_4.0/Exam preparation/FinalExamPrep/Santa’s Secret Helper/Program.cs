using System;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace Santa_s_Secret_Helper
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            while (input !="end")
            {
                StringBuilder decryptedMessage = new StringBuilder();

                for (int i = 0; i < input.Length; i++)
                {
                    char current = input[i];
                    int decrptedChar = (int)current - key;
                    decryptedMessage.Append((char)decrptedChar);
                }

                string pattern = @"@(?<name>[A-Za-z]+)[^@\-!:>]+(!(?<beh>[GN])!)";

                MatchCollection matches = Regex.Matches(decryptedMessage.ToString(), pattern);
                foreach (Match item in matches)
                {
                    string name = item.Groups["name"].Value;
                    string behaviour = item.Groups["beh"].Value;

                    if (behaviour=="G")
                    {
                        Console.WriteLine(name);
                    }
                }
                                             
                input = Console.ReadLine();
            }
        }
    }
}
