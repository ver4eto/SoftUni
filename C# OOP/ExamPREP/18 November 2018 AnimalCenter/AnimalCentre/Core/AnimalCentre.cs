using AnimalCentre.Exception;
using AnimalCentre.Models.Contracts;
using AnimalCentre.Models.Entities;
using AnimalCentre.Models.Entities.Animals;
using AnimalCentre.Models.Entities.Procedures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalCentre.Core
{
    public class AnimalCentre : IAnimalCenter
    {

        public Hotel hotel;

        private Dictionary<string, IProcedure> procedures;
        public AnimalCentre()
        {
            this.hotel = new Hotel();
            this.procedures = new Dictionary<string, IProcedure>();
            AddProcedures();
        }

        private void AddProcedures()
        {
            procedures.Add("Chip", new Chip());
            procedures.Add("DentalCare", new DentalCare());
            procedures.Add("Fitness", new Fitness());
            procedures.Add("NailTrim", new NailTrim());
            procedures.Add("Play", new Play());
            procedures.Add("Vaccinate", new Vaccinate());

        }
        public string RegisterAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            IAnimal animal;
            if (type == "Cat")
            {
                animal = new Cat(name, energy, happiness, procedureTime);
            }
            else if (type == "Dog")
            {
                animal = new Dog(name, energy, happiness, procedureTime);
            }
            else if (type == "Lion")
            {
                animal = new Lion(name, energy, happiness, procedureTime);
            }
            else
            {
                animal = new Pig(name, energy, happiness, procedureTime);
            }

            hotel.Accommodate(animal);

            return $"Animal {animal.Name} registered successfully";

        }

        public string Chip(string name, int procedureTime)
        {
            var animals = hotel.Animals;
            var currentAnimal = animals[name];

            this.CheckIfAnimalExists(currentAnimal, name);

            procedures["Chip"].DoService(currentAnimal, procedureTime);

            return $"{currentAnimal.Name} had chip procedure";

        }

        private void CheckIfAnimalExists(IAnimal currentAnimal, string animalName)
        {
            if (currentAnimal == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistinhAnimalException, animalName));
            }
        }

        public string Vaccinate(string name, int procedureTime)
        {
            var animals = hotel.Animals;
            var currentAnimal = animals[name];

            this.CheckIfAnimalExists(currentAnimal, name);

            procedures["Vaccinate"].DoService(currentAnimal, procedureTime);

            return $"{currentAnimal.Name} had vaccination procedure";
        }

        public string Fitness(string name, int procedureTime)
        {
            var animals = hotel.Animals;
            var currentAnimal = animals[name];

            this.CheckIfAnimalExists(currentAnimal, name);

            procedures["Fitness"].DoService(currentAnimal, procedureTime);

            return $"{currentAnimal.Name} had fitness procedure";
        }

        public string Play(string name, int procedureTime)
        {
            var animals = hotel.Animals;
            var currentAnimal = animals[name];

            this.CheckIfAnimalExists(currentAnimal, name);

            procedures["Play"].DoService(currentAnimal, procedureTime);

            return $"{currentAnimal.Name} was playing for {procedureTime} hours";
        }

        public string DentalCare(string name, int procedureTime)
        {
            var animals = hotel.Animals;
            var currentAnimal = animals[name];

            this.CheckIfAnimalExists(currentAnimal, name);

            procedures["DentalCare"].DoService(currentAnimal, procedureTime);

            return $"{currentAnimal.Name} had denntal care procedure";
        }

        public string NailTrim(string name, int procedureTime)
        {
            var animals = hotel.Animals;
            var currentAnimal = animals[name];

            this.CheckIfAnimalExists(currentAnimal, name);

            procedures["NailTrim"].DoService(currentAnimal, procedureTime);

            return $"{currentAnimal.Name} had nail trim procedure";
        }

        public string Adopt(string animalName, string owner)
        {
            string result;
            var animals = hotel.Animals;
            if (!animals.ContainsKey(animalName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistinhAnimalException, animalName));
            }
            else
            {
                var currentAnimal = animals[animalName];
                this.CheckIfAnimalExists(currentAnimal, animalName);

                if (currentAnimal.IsChipped)
                {
                    result = $"{owner} adopted animal with chip";
                }
                else
                {
                    result = $"{owner} adopted animal without chip";
                }
                hotel.Adopt(animalName, owner);
            }
           

            return result;
        }

        public string History(string type)
        {
            StringBuilder sb = new StringBuilder();

           
            foreach (var item in procedures.Where(p=>p.Key==type))
            {
                //sb.AppendLine($"{item.Value.GetType().Name}");
                sb.AppendLine($"{item.Value.History()}");
                
            }

            return sb.ToString().TrimEnd();
        }

    }
}
