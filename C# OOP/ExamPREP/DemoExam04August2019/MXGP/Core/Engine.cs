using MXGP.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Core
{
    public class Engine : IEngine
    {
        private ChampionshipController controller;
        public Engine()
        {
            this.controller = new ChampionshipController();
        }

        public void Run()
        {
            while (true)
            {
                
                try
                {
                    string[] input = Console.ReadLine().Split().ToArray();
                    string command = input[0];

                    if (command == "End")
                    {
                        this.controller.End();
                        break;
                    }

                    switch (command)
                    {
                        case "CreateRider":
                            string name = input[1];
                            Console.WriteLine(this.controller.CreateRider(name)); 
                            break;
                        case "CreateMotorcycle":
                            string motorcycleType = input[1];
                            string model = input[2];
                            int horsePower = int.Parse(input[3]);
                            Console.WriteLine(this.controller.CreateMotorcycle(motorcycleType, model, horsePower)); 
                            break;
                        case "AddMotorcycleToRider":
                            string riderName = input[1];
                            string motorcycleName = input[2];
                            Console.WriteLine(this.controller.AddMotorcycleToRider(riderName, motorcycleName));  
                            break;
                        case "AddRiderToRace":
                            string raceName = input[1];
                            string rider = input[2];
                            Console.WriteLine(this.controller.AddRiderToRace(raceName, rider)); 
                            break;
                        case "CreateRace":
                            string race = input[1];
                            int laps = int.Parse(input[2]);
                            Console.WriteLine(this.controller.CreateRace(race, laps)); 
                            break;
                        case "StartRace":
                            string startRaceName = input[1];
                            Console.WriteLine(this.controller.StartRace(startRaceName));
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
               
            }
            


        }
    }
}
