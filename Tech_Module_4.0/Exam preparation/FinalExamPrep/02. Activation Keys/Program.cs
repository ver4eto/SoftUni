using System;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace _02._Activation_Keys
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split('&')
                .ToArray();
            List<string> final = new List<string>();
            bool isValid = false;
            for (int i = 0; i < input.Length; i++)
            {
                string current = input[i];
                
                if (current.Length==16 || current.Length==25)
                {
                    isValid = true;
                    string pattern = @"^([a-zA-Z0-9]+)\z";
                    Regex regex = new Regex(pattern);
                    if (regex.IsMatch(current))
                    {
                        StringBuilder word = new StringBuilder();
                        if (current.Length==16)
                        {
                            for (int j = 0; j < current.Length; j+=4)
                            {
                                word.Append(current.Substring(j,4));
                                word.Append("-");
                            }
                        }
                        else
                        {
                            for (int j = 0; j < current.Length; j +=5)
                            {
                                word.Append(current.Substring(j, 5));
                                word.Append("-");
                            }
                        }
                     
                        for (int k = 0; k < word.Length; k++)
                        {
                          
                            if (Char.IsDigit(word[k]))
                            {
                                int currentChar =int.Parse( word[k].ToString());
                                int number =9-currentChar;
                                char numToChar = Convert.ToChar(number.ToString());
                               
                                word.Remove(k, 1);
                                word.Insert(k, numToChar);
                                //word.Replace(word[k],numToChar);
                            }
                        }
                        var upperWord = word.ToString().ToUpper();
                        final.Add(upperWord.TrimEnd('-'));
                    }
                }
               
               
            }
            Console.WriteLine(string.Join(", ", final));
        }
    }
}
