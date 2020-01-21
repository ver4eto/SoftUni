using System;
using System.Collections.Generic;
using System.Linq;

namespace _4___Iron_Girder
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, int> townAndPassengers = new Dictionary<string, int>();
            Dictionary<string, int> townAndTime = new Dictionary<string, int>();

            while (input!= "Slide rule")
            {
                string[] tokens = input
                    .Split(new string[] { ":","->" },StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                
                string town = tokens[0];
                string action = tokens[1];
                int passengers = int.Parse(tokens[2]);
                if (action== "ambush")
                {
                    if (townAndPassengers.ContainsKey(town))
                    {
                        townAndPassengers[town] -= passengers;
                        townAndTime[town] = 0;
                    }
                }
                else
                {
                    int time = int.Parse(action);
                    if (!townAndPassengers.ContainsKey(town))
                    {
                        townAndPassengers.Add(town, passengers);
                        townAndTime.Add(town,time);
                    }
                    else
                    {
                        if (time<townAndTime[town]&&townAndTime[town]>0)
                        {                           
                            townAndTime[town] = time;
                        }
                        else if (townAndTime[town]==0)
                        {
                            townAndTime[town] = time;
                        }
                        townAndPassengers[town] += passengers;
                    }
                }
                input = Console.ReadLine();
            }

            foreach (var town in townAndTime.OrderBy(x => x.Value).ThenBy(x=>x.Key))
            {
                foreach (var passenger in townAndPassengers.OrderByDescending(x=>x.Value))
                {
                    if (town.Key==passenger.Key)
                    {
                        if (town.Value!=0 &&passenger.Value!=0)
                        {
                             Console.WriteLine($"{town.Key} -> Time: {town.Value} -> Passengers: {passenger.Value}");
                        }
                      
                    }
                   
                }
            }
           
        }
    }
}
