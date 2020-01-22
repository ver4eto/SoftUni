using SpaceStation.Core.Contracts;
using SpaceStation.IO;
using SpaceStation.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    public class Engine : IEngine
    {
        private Controller controller;

        public Engine()
        {
            this.controller = new Controller();
        }
        public void Run()
        {
            while (true)
            {
                var input = Console.ReadLine().Split();
                if (input[0] == "Exit")
                {
                    Environment.Exit(0);
                }
                try
                {
                    if (input[0] == "AddAstronaut")
                    {
                        string type = input[1];
                        string name = input[2];

                        Console.WriteLine(controller.AddAstronaut(type, name));    
                    }
                    else if (input[0] == "AddPlanet")
                    {
                        string planetName = input[1];

                        string[] items = input.Skip(2).ToArray();
                        //List<string> items = new List<string>();

                        //for (int i = 2; i < input.Length; i++)
                        //{
                        //    items.Add(input[i]);
                        //}

                        Console.WriteLine(controller.AddPlanet(planetName,items/*.ToString())*/));
                    }
                    else if (input[0] == "RetireAstronaut")
                    {
                        string name = input[1];

                        Console.WriteLine(controller.RetireAstronaut(name));
                    }
                    else if (input[0] == "ExplorePlanet")
                    {
                        string planetName = input[1];

                        Console.WriteLine(controller.ExplorePlanet(planetName));
                    }
                    else if(input[0] == "Report")
                    {
                        Console.WriteLine(controller.Report());
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
