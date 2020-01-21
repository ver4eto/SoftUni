using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P02_CarsSalesman
{
    public class Runner
    {
        private List<Car> cars;
        private List<Engine> engines;

        public Runner()
        {
            this.cars = new List<Car>();
            this.engines = new List<Engine>();
        }

        public void Run()
        {

            int engineCount = int.Parse(Console.ReadLine());

            AddingEngines(engineCount);

            int carCount = int.Parse(Console.ReadLine());

            AddingCars(carCount);

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }

        private void AddingCars(int carCount)
        {
            for (int i = 0; i < carCount; i++)
            {
                string[] parameters = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                Car car = this.CreateCar(parameters);
                cars.Add(car);
               
            }
        }

        private Car CreateCar(string[] parameters)
        {
            Car currentCar = null;

            string model = parameters[0];

            string engineModel = parameters[1];

            Engine engine = engines.FirstOrDefault(x => x.Model == engineModel);

           
            if (parameters.Length == 3)
            {
                bool isWeight = int.TryParse(parameters[2], out int weight);
                if (isWeight)
                {
                    currentCar = new Car(model, engine, weight);
                }
                else
                {
                    string color = parameters[2];
                    currentCar = new Car(model, engine, color);
                } 
            }
          
            else if (parameters.Length == 4)
            {
                string color = parameters[3];
                int weight = int.Parse(parameters[2]);

               currentCar = new Car(model, engine, weight, color);
               
            }
            else
            {
                currentCar = new Car(model, engine);               
            }
            return currentCar;
        }

        private void AddingEngines(int engineCount)
        {
            for (int i = 0; i < engineCount; i++)
            {
                string[] parameters = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                Engine engine = this.CreateEngine(parameters);

                engines.Add(engine);
            }
        }

        private Engine CreateEngine(string[] parameters)
        {
            Engine currentEngine = null;

            string model = parameters[0];

            int power = int.Parse(parameters[1]);
                     
            if (parameters.Length == 3 )
            {
                bool isDisplacemnet = int.TryParse(parameters[2], out int displacement);

                if (isDisplacemnet)
                {
                    currentEngine = new Engine(model, power, displacement);
                }
                else 
                {
                    string efficiency = parameters[2];
                    currentEngine = new Engine(model, power, efficiency);
                }
            }       
            else if (parameters.Length == 4)
            {
                string efficiency = parameters[3];
              int  displacement = int.Parse(parameters[2]);
                currentEngine = new Engine(model, power, displacement, efficiency);

            }
            else
            {
               currentEngine = new Engine(model, power);               
            }

            return currentEngine;
        }
    }
}
