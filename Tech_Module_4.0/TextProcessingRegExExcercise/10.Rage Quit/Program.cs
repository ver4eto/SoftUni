using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;

namespace _10.Rage_Quit
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder finalList = new StringBuilder(); ;
            //string pattern = @"(?<forPrint>[^\d]+)(?<count>\d+)";

            //MatchCollection forPrint = Regex.Matches(input, pattern);



            //foreach (Match item in forPrint)
            //{
            //    string word = item.Groups["forPrint"].Value;
            //    int count =int.Parse( item.Groups["count"].Value);

            //    for (int i = 1; i <= count; i++)
            //    {
            //        finalList.Append(word.ToUpper());
            //    }
            //}

            StringBuilder current = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                if (!char.IsDigit(input[i]))
                {
                    current.Append(input[i]);
                    
                }
                else
                {
                    int count = 0;
                    if (i==input.Length-1)
                    {
                        count = int.Parse(input[i].ToString());
                    }
                    else if (i!=input.Length-1&&!char.IsDigit(input[i+1]))
                    {
                        count = int.Parse(input[i].ToString());
                        
                    }
                    else
                    {
                        count = int.Parse(input[i].ToString() + input[i + 1].ToString());
                    }
                    for (int j = 1; j <= count; j++)
                    {
                        finalList.Append(current.ToString().ToUpper());
                    }
                    current = new StringBuilder();
                }
            }
            int countFinal = finalList.ToString().Distinct().Count();

            Console.WriteLine($"Unique symbols used: {countFinal}");
            Console.WriteLine(finalList);
        }
    }
}
