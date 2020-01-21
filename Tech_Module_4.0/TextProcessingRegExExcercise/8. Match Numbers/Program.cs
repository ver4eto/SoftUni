using System;
using System.Text.RegularExpressions;

namespace _8._Match_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"(^|(?<=\s))-?\d+(\.\d+)?($|(?=\s))";
                            //(^| (?<=\s))-?\d + (\.\d +)?(?| (?=\s))

            MatchCollection numbers = Regex.Matches(input, pattern);

            foreach (Match match in numbers)
            {
                Console.Write(match.Value + " ");
            }
            Console.WriteLine();

            //Regex match = new Regex(pattern);

            //if (match.IsMatch(input))
            //{
            //    Console.WriteLine(match.Match(input).Value);
            //}
        }
    }
}
