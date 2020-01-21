using System;
using System.Linq;
using System.Collections.Generic;

namespace International_SoftUniada
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, List<string>> countryTotal = new Dictionary<string, List<string>>();
            Dictionary<string, int> contestantPoints = new Dictionary<string, int>();

            while (input != "END")
            {
                string[] tokens = input.Split(" -> ").ToArray();
                string country = tokens[0];
                string contestantName = tokens[1];
                int points = int.Parse(tokens[2]);

                if (!countryTotal.ContainsKey(country))
                {
                    countryTotal.Add(country, new List<string> { contestantName });
                    contestantPoints.Add(contestantName, points);
                }
                else
                {
                    if (!countryTotal[country].Contains(contestantName))
                    {
                        countryTotal[country].Add(contestantName);
                    }
                    if (!contestantPoints.ContainsKey(contestantName))
                    {
                        contestantPoints.Add(contestantName, points);
                    }
                    else
                    {
                        contestantPoints[contestantName] += points;
                    }

                }
                input = Console.ReadLine();
            }

            Dictionary<string, int> finalPointsCountries = new Dictionary<string, int>();

            foreach (KeyValuePair<string, List<string>> kvp in countryTotal)
            {
                finalPointsCountries.Add(kvp.Key, 0);
                foreach (var name in kvp.Value)
                {
                    foreach (var nameStudent in contestantPoints)
                    {
                        if (nameStudent.Key == name)
                        {
                            finalPointsCountries[kvp.Key] += nameStudent.Value;
                        }
                    }
                }

            }


            foreach (var countryPoint in finalPointsCountries.OrderByDescending(x=>x.Value))
            {
                Console.WriteLine($"{countryPoint.Key}: {countryPoint.Value}");

                foreach (var country in countryTotal)
                {
                    if (countryPoint.Key==country.Key)
                    {
                        foreach (var name in country.Value)
                        {
                            foreach (var item in contestantPoints.Where(x => x.Key == name))
                            {
                                Console.WriteLine($"-- { item.Key} -> { item.Value}");
                            }
                        }
                    }
                    
                }
            }
            
        }
    }
}
