using System;
using AnimalFarm.Models;

namespace AnimalFarm
{   
   public class StartUp
    {
        static void Main(string[] args)
        {            
            try
            {
                string name = Console.ReadLine();
                int age = int.Parse(Console.ReadLine());

                Chicken chicken = new Chicken(name, age);
                Console.WriteLine(chicken.ToString());
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
