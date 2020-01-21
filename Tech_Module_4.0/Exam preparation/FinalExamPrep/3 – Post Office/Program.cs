using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _3___Post_Office
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split('|').ToArray();

            string first = input[0];
            string second = input[1];
            string third = input[2];
            string firstWord = string.Empty;
            List<string> final = new List<string>();

            string patternFirst = @"(?<before>[#$%*&]{1})(?<lettres>[A-Z]+)(?<after>[#$%*&]{1})";
            Regex firstRegex = new Regex(patternFirst);
            Match match = firstRegex.Match(first);
            if (match.Success)
            {
                string before = match.Groups["before"].Value;
                string after = match.Groups["after"].Value;
                if (before==after)
                {
                    firstWord = match.Groups["lettres"].Value;                   
                }
            }
            string patternSecond = @"(?<letterASCII>[0-9]{2}):(?<lenght>[0-9]{2})";            
            MatchCollection secondMatch = Regex.Matches(second,patternSecond);

            string[] finalWords = third.Split().ToArray();
            for (int i = 0; i < firstWord.Length; i++)
            {
                char currentCapLetter = firstWord[i];
                foreach (Match item in secondMatch)
                {
                    int lettreAscii = int.Parse(item.Groups["letterASCII"].Value);
                    int lenght = int.Parse(item.Groups["lenght"].Value);

                    for (int j = 0; j < finalWords.Length; j++)
                    {
                        string current = finalWords[j];
                        if (lenght + 1 == current.Length && current[0] == (char)lettreAscii && (char)lettreAscii==firstWord[i]&& !final.Contains(current))
                        {
                            final.Add(current);
                            continue;
                        }
                    }
                }
            }

            Console.WriteLine(string.Join("\n",final));          

        }
    }
}
