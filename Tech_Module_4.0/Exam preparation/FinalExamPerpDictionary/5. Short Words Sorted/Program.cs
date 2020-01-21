using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Short_Words_Sorted
{
    class Program
    {
        static void Main(string[] args)
        {
            //char[] separators =  { '.', ',', ':', ';', '(', ')', '[', ']', '"', '\'', '\\', '/', '!', ' ' };

            List<string> words = Console.ReadLine()
                 .Split(new char[] { '.', ',', ':', ';', '(', ')', '[', ']', '"', '\'', '\\', '/', '!', ' ' },StringSplitOptions.RemoveEmptyEntries)
                 .ToList();

            var reduced = words.Where(x => x.Length < 5).OrderBy(x => x).Distinct(StringComparer.OrdinalIgnoreCase);
            Console.WriteLine(string.Join(", ",reduced).ToLower());
        }
    }
}
