using System;
using System.Collections.Generic;
using System.Linq;

namespace _9._Star_EnigmaNoREGEX
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
            bool isValid = false;
            bool hasName = false;
            bool hasAttackType = false;
            bool hasPopulation = false;
            bool hasSoldierCount = false;
            string type = string.Empty;

            while (countsOfCommands > 0)
            {
                input = Console.ReadLine();
                int countOfLetters = 0;
                for (int i = 0; i < input.Length; i++)
                {
                    var current = input[i].ToString().ToLower();
                    if (current == "s" || current == "t" || current == "a" || current == "r")
                    {
                        countOfLetters++;
                    }
                }
                for (int i = 0; i < input.Length; i++)
                {
                    afterDecryption += (char)(input[i] - countOfLetters);
                }
                hasName = false;
                hasPopulation = false;
                hasSoldierCount = false;
                hasAttackType = false;
                isValid = false;

                string planetName = string.Empty;

                for (int i = 0; i < afterDecryption.Length; i++)
                {
                    if (afterDecryption[i]=='@')
                    {
                        if (!char.IsLetter(afterDecryption[i+1]))
                        {
                            hasName = false;
                        }
                        else
                        {
                            for (int j = i + 1; j < afterDecryption.Length; j++)
                            {
                                if (char.IsLetter(afterDecryption[j]))
                                {
                                    planetName += afterDecryption[j];
                                    hasName = true;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                                          
                    }
                    
                    if (afterDecryption[i]==':')
                    {
                        if (char.IsDigit(afterDecryption[i+1]))
                        {
                            hasPopulation = true;
                        }
                       
                    }
                    if (afterDecryption[i]=='!'&&afterDecryption[i+2]=='!')
                    {
                        hasAttackType = true;
                        if (afterDecryption[i+1]=='A')
                        {
                            type = "A";
                        }
                        else if (afterDecryption[i+1]=='D')
                        {
                            type = "D";
                        }
                        i += 2;
                    }
                    if (afterDecryption[i]=='-'&&afterDecryption[i+1]=='>'&&char.IsDigit(afterDecryption[i+2]))
                    {
                        hasSoldierCount = true;
                    }

                }
                if (hasName&&hasPopulation&&hasAttackType&&hasSoldierCount)
                {
                    isValid = true;
                    if (type=="A")
                    {
                        attackedPlanets.Add(planetName);
                    }
                    else if (type=="D")
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

