using System;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace FinalExamTech
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
           
            bool nameIsValid = false;
            bool isValidLenght = false;
            bool isValidCode = false;

            //if (input=="Last note")
            //{
            //    Console.WriteLine("Nothing found!");
            //}
            while (input!= "Last note")
            {
                StringBuilder nameOfPeak = new StringBuilder();
                string geohashCode = string.Empty;
               
                string pattern = @"^(?<name>[a-zA-Z\d!@#$?]*)=(?<lenght>[0-9]+)<<(?<geohashCode>.+)$";
                MatchCollection matched = Regex.Matches(input,pattern);

                foreach (Match item in matched)
                {
                    string name = item.Groups["name"].Value;
                    for (int i = 0; i < name.Length; i++)
                    {
                        if (char.IsLetterOrDigit(name[i]))
                        {
                            nameOfPeak.Append(name[i]);
                        }
                    }
                    nameIsValid = true;
                    isValidLenght = true;
                    string lenghtString = item.Groups["lenght"].Value;
                    int lenght = int.Parse(lenghtString);
                    geohashCode = item.Groups["geohashCode"].Value;
                    if (geohashCode.Length==lenght)
                    {                       
                            isValidCode = true;                    
                        
                    }
                }

                if (isValidCode&&isValidLenght&&nameIsValid)
                {
                    //string finalName = string.Empty;
                    //for (int i = 0; i < nameOfPeak.Length; i++)
                    //{
                    //    if (Char.IsLetterOrDigit(nameOfPeak[i]))
                    //    {
                    //        finalName += nameOfPeak[i];
                    //    }
                    //}
                    Console.WriteLine($"Coordinates found! {nameOfPeak} -> {geohashCode}");
                }
                else
                {
                    Console.WriteLine("Nothing found!");
                }
                input = Console.ReadLine();
                isValidCode = false;
                isValidLenght = false;
                nameIsValid = false;
            }
        }
    }
}
