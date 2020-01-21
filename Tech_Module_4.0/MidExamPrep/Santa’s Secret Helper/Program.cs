using System;
using System.Collections.Generic;

namespace Santa_s_Secret_Helper
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            List<char> decrypted = new List<char>();
            string currentName = string.Empty;
            List<string> goods = new List<string>();

            while (command != "end")
            {
                char[] input = command.ToCharArray();
                foreach (var item in input)
                {
                    int current = item - key;
                    decrypted.Add((char)(current));
                }

                int startIndex = decrypted.IndexOf('@');
                for (int i = startIndex + 1; i < decrypted.Count; i++)
                {
                    if (decrypted[i] >= 65 && decrypted[i] <= 90 || decrypted[i]>=97 && decrypted[i]<=122)
                    {
                        currentName += (char)(decrypted[i]);
                    }
                    else
                    {
                        break;
                    }

                }
                string good = "!G!";
                string goodOrBad = string.Join("", decrypted);
                                
                if (goodOrBad.Contains(good))
                {
                    goods.Add(currentName);
                }
                command = Console.ReadLine();
                currentName = string.Empty;
                decrypted = new List<char>();
            }

            foreach (var item in goods)
            {
                Console.WriteLine(item);
            }
        }
    }
}
