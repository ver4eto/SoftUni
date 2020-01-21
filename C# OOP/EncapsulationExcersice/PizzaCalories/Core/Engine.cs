using PizzaCalories.Models;
using System;

namespace PizzaCalories.Core
{
   public class Engine
    {
        public Engine()
        {

        }

        public void Run()
        {

            try
            {
                string[] pizzaData = Console.ReadLine().Split();

                string name = pizzaData[1];

                string[] doughData = Console.ReadLine().Split();


                string type = doughData[1];
                string bakingTechnique = doughData[2];
                int weight = int.Parse(doughData[3]);

                Dough dough = new Dough(type, bakingTechnique, weight);
                Pizza pizza = new Pizza(name, dough);

                string command = Console.ReadLine();

                while (command != "END")
                {
                    string[] toppingData = command.Split();
                    string toppingType = toppingData[1];
                    int toppingWeight = int.Parse(toppingData[2]);

                    Topping currentTopping = new Topping(toppingType, toppingWeight);

                    pizza.AddTopping(currentTopping);

                    command = Console.ReadLine();
                }

                Console.WriteLine(pizza.ToString());
            }
            catch (ArgumentException ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
