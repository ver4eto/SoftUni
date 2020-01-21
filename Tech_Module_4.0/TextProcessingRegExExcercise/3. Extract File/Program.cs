using System;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace _3._Extract_File
{
    class Program
    {
        static void Main(string[] args)
        {
         
            string input = Console.ReadLine();
            //string regex = @"\\(?<fileName>\w*)[.](?<typeOfFile>\w*)\b";

            //MatchCollection filesAndType = Regex.Matches(input, regex);


            //foreach (Match item in filesAndType)
            //{
            //    Console.WriteLine($"File name: {item.Groups["fileName"].Value}");
            //    Console.WriteLine($"File extension: {item.Groups["typeOfFile"].Value}");
            //}

            int startIndex = input.LastIndexOf('\\') + 1;
            string fileName = input.Substring(startIndex);
            int endIndex = fileName.LastIndexOf('.');
            string extension = fileName.Substring(endIndex + 1);
            fileName = fileName.Remove(endIndex);
         
            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {extension}");
        }
    }
}
