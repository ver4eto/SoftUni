using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _6._Winning_Ticket
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] separators = new [] {'\n','\t',',',' ' };
            string[] tickets = Console.ReadLine()
                .Split(separators, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            
            for (int i = 0; i < tickets.Length; i++)
            {
                string current = tickets[i];
                if (current.Length==20)
                {                    
                    string leftCurrent = current.Substring(0, 10);
                    string rightCurrent = current.Substring(10, 10);

                    string leftSubstring = string.Empty;
                    string rightSUbstring = string.Empty;
                    ////StringBuilder left = new StringBuilder();
                    ////StringBuilder right = new StringBuilder();
                    //int startIndex = 0;
                    //int endIndex = 0;
                    //if (leftCurrent.Contains('#')||leftCurrent.Contains('$')||leftCurrent.Contains('^')||leftCurrent.Contains('@'))
                    //{
                    //    startIndex=leftCurrent.IndexOf('')
                    //}

                    string pattern = @"(?<symbols>\@{6,}|\${6,}|\^{6,}|\#{6,})";
                    Match left = Regex.Match(leftCurrent, pattern);
                    Match right = Regex.Match(rightCurrent, pattern);
                    if (left.Success && right.Success)
                    {
                        if (left.Length == 10 && right.Length == 10)
                        {
                            if (left.Groups["symbols"].Value == right.Groups["symbols"].Value)
                            {
                                string type = left.Groups["symbols"].Value;
                                Console.WriteLine($"ticket \"{current}\" - {left.Length}{type[0]} Jackpot!");
                            }
                            else
                            {
                                Console.WriteLine($"ticket \"{current}\" - no match");
                            }

                        }
                        else
                        {
                            if (left.Groups["symbols"].Value == right.Groups["symbols"].Value)
                            {
                                string type = left.Groups["symbols"].Value;
                                Console.WriteLine($"ticket \"{current}\" - {left.Length}{type[0]}");
                            }
                            else
                            {
                                Console.WriteLine($"ticket \"{current}\" - no match");
                            }

                        }
                    }
                else
                    {
                        Console.WriteLine($"ticket \"{current}\" - no match");
                    }

                }
                else
                {
                    Console.WriteLine($"invalid ticket");
                }

            }
        }
    }
}
