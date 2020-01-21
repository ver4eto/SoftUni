using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models;
using WildFarm.Models.Foods;

namespace WildFarm.Core
{
    public class Engine
    {
        private List<Animal> animals;
        public Engine()
        {
            this.animals = new List<Animal>();
        }
        public void Run()
        {
            string command = Console.ReadLine();

            while (command != "End")
            {
                try
                {
                    Animal animal = GetAnimal(command);

                    string foodInfo = Console.ReadLine();
                    Food food = GetFood(foodInfo);

                    Console.WriteLine(animal.AskForFood());
                    animal.Feed(food);
                   
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
               
                command = Console.ReadLine();
            }
            foreach (Animal animal1 in animals)
            {
                Console.WriteLine(animal1.ToString());
            }
        }

        private Food GetFood(string foodInfo)
        {
            string[] foodData = foodInfo.Split();

            Food food;

            string type = foodData[0];

            int quantity = int.Parse(foodData[1]);
            switch (type)
            {
                case "Meat":
                    food = new Meat(quantity);
                    break;
                case "Vegetable":
                    food = new Vegetable(quantity);
                    break;
                case "Fruit":
                    food = new Fruit(quantity);
                    break;
                case "Seeds":
                    food = new Seeds(quantity);
                    break;
                default:
                    throw new InvalidOperationException();                    
            }
            return food;

        }

        private Animal GetAnimal(string command)
        {
            Animal animal;

            string[] animalData = command.Split();

            string animalType = animalData[0];

            string name = animalData[1];

            double weight = double.Parse(animalData[2]);

            if (animalType == "Hen")
            {
                double wingSize = double.Parse(animalData[3]);
                animal = new Hen(name, weight, wingSize);
            }
            else if (animalType == "Owl")
            {
                double wingSize = double.Parse(animalData[3]);
                animal = new Owl(name, weight, wingSize);
            }
            else if (animalType == "Mouse")
            {
                string livingRegion = animalData[3];
                animal = new Mouse(name, weight, livingRegion);
            }
            else if (animalType == "Dog")
            {
                string livingRegion = animalData[3];
                animal = new Dog(name, weight, livingRegion);
            }
            else if (animalType == "Cat")
            {
                string livingRegion = animalData[3];
                string breed = animalData[4];
                animal = new Cat(name, weight, livingRegion, breed);
            }
            else if (animalType == "Tiger")
            {
                string livingRegion = animalData[3];
                string breed = animalData[4];
                animal = new Tiger(name, weight, livingRegion, breed);
            }
            else
            {
                throw new InvalidOperationException();
            }
            this.animals.Add(animal);
            return animal;
        }

    }
}
