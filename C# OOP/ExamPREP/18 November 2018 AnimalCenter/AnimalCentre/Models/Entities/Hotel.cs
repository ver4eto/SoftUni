using AnimalCentre.Exception;
using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalCentre.Models.Entities
{
    public class Hotel : IHotel
    {
        private Dictionary<string, IAnimal> animals;
        private  int capacity;

        public Hotel()
        {
            animals = new Dictionary<string, IAnimal>();
            this.capacity = 10;
        }

        public IReadOnlyDictionary<string, IAnimal> Animals { get => this.animals; }

        

        public void Accommodate(IAnimal animal)
        {
            if (animals.Count == 10)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacityException);
            }
            else if (animals.ContainsKey(animal.Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.AlreadyExistingAnimalException, animal.Name));
            }
            else
            {
                animals.Add(animal.Name, animal);
            }
        }

        public void Adopt(string animalName, string owner)
        {
            if (!animals.ContainsKey(animalName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistinhAnimalException, animalName));
            }
            else
            {
                IAnimal animal = animals.GetValueOrDefault(animalName);
                animal.IsAdopt = true;
                animal.Owner = owner;
                animals.Remove(animalName);
            }
        }
    }
}
