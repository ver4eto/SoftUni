using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _9._Star_Enigma
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            int countsOfCommands = int.Parse(Console.ReadLine());
            string afterDecryption = string.Empty;
            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();

            while (countsOfCommands>0)
            {
                input = Console.ReadLine();
                int countOfLetters = 0;
                for (int i = 0; i < input.Length; i++)
                {
                  var current=input[i].ToString().ToLower();
                    if (current=="s"|| current == "t"|| current == "a"|| current == "r")
                    {
                        countOfLetters++;
                    }
                }
                for (int i = 0; i < input.Length; i++)
                {
                    afterDecryption+=(char)(input[i] - countOfLetters);
                }
                string pattern = @".*?@(?<planetName>[a-zA-Z]+)[^@\-!>]*:(?<population>\d+)[^@\-!>]*!(?<attackType>[AD])![^@\-!>]*->(?<soldierCount>\d+)";
                MatchCollection planets = Regex.Matches(afterDecryption,pattern);

                foreach (Match planet in planets)
                {
                    string planetName = planet.Groups["planetName"].Value;
                    string typeOfAttack = planet.Groups["attackType"].Value;
                    if (typeOfAttack=="A")
                    {
                        attackedPlanets.Add(planetName);
                    }
                    else if(typeOfAttack=="D")
                    {
                        destroyedPlanets.Add(planetName);
                    }
                }
                countsOfCommands--;
                afterDecryption = string.Empty;
            }

            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");

            attackedPlanets.Sort();
            foreach (var item in attackedPlanets)
            {
                Console.WriteLine($"-> {item}");
            }
            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
            destroyedPlanets.Sort();
            foreach (var planet in destroyedPlanets)
            {
                Console.WriteLine($"-> {planet}");
            }

        }
    }
}
