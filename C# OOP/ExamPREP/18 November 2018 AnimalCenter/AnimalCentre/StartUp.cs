using AnimalCentre.Core;
using AnimalCentre.Models.Entities.Procedures;
using System;

namespace AnimalCentre
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            Engine engine = new Engine();
            engine.Run();
           
        }
    }
}
