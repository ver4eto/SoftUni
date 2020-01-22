using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalCentre.Core
{
   public class Engine
    {
        private AnimalCentre animalCentre;
        private Dictionary<string, List<string>> adoptedAnimals;
        public Engine()
        {
            this.animalCentre = new AnimalCentre();
            this.adoptedAnimals = new Dictionary<string, List<string>>();
        }
        public void Run()
        {
            string command = Console.ReadLine();
            while (command!="End")
            {
                try
                {
                    string[] args = command.Split().ToArray();
                    string action = args[0];

                    switch (action)
                    {
                        case "RegisterAnimal":
                            RegisterAnimal(args);
                            break;
                        case "Chip":
                            Chip(args);
                            break;
                        case "Vaccinate":
                            Vaccinate(args);
                            break;
                        case "Fitness":
                            Fitness(args);
                            break;
                        case "Play":
                            Play(args);
                            break;
                        case "DentalCare":
                            DentalCare(args);
                            break;
                        case "NailTrim":
                            NailTrim(args);
                            break;
                        case "Adopt":
                            Adopt(args);

                            break;
                        case "History":
                            History(args);
                            break;
                        default:
                            break;
                    }

                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine($"InvalidOperationException: {ioe.Message}");
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine($"ArgumentException: {ae.Message}");
                }         
                command = Console.ReadLine();
            }


            foreach (var owner in adoptedAnimals.OrderBy(k => k.Key))
            {
                Console.WriteLine($"--Owner: {owner.Key}");
                Console.Write("    - Adopted animals: ");
                //foreach (var animal in owner.Value.OrderBy(a=>a))
                //{
                Console.WriteLine($"{string.Join(" ", owner.Value)}");
                //}
            }
        }

        private void History(string[] args)
        {
            string procedureType = args[1];
            Console.WriteLine(animalCentre.History(procedureType));
        }

        private void Adopt(string[] args)
        {
            string animalName = args[1];
            string owner = args[2];
            string result;
            result = animalCentre.Adopt(animalName, owner);
            if (adoptedAnimals.ContainsKey(owner))
            {
                adoptedAnimals[owner].Add(animalName);
            }
            else
            {
                adoptedAnimals.Add(owner, new List<string>());
                adoptedAnimals[owner].Add(animalName);
            }
          
            Console.WriteLine(result);
        }

        private void NailTrim(string[] args)
        {
            string name = args[1];
            int procedureTime = int.Parse(args[2]);
            Console.WriteLine(animalCentre.NailTrim(name, procedureTime));
        }

        private void DentalCare(string[] args)
        {
            string name = args[1];
            int procedureTime = int.Parse(args[2]);
            Console.WriteLine(animalCentre.DentalCare(name, procedureTime));
        }

        private void Play(string[] args)
        {
            string name = args[1];
            int procedureTime = int.Parse(args[2]);
            Console.WriteLine(animalCentre.Play(name, procedureTime));
        }

        private void Fitness(string[] args)
        {
            string name = args[1];
            int procedureTime = int.Parse(args[2]);
            Console.WriteLine(animalCentre.Fitness(name, procedureTime));
        }

        private void Vaccinate(string[] args)
        {
            string name = args[1];
            int procedureTime = int.Parse(args[2]);
            Console.WriteLine(animalCentre.Vaccinate(name, procedureTime));
        }

        private void Chip(string[] args)
        {
            string name = args[1];
            int procedureTime = int.Parse(args[2]);
            Console.WriteLine(animalCentre.Chip(name, procedureTime));
        }

        private void RegisterAnimal(string[] args)
        {
            string type = args[1];
            string name = args[2];
            int energy = int.Parse(args[3]);
            int happines = int.Parse(args[4]);
            int procedureTime = int.Parse(args[5]);

            Console.WriteLine(animalCentre.RegisterAnimal(type, name, energy, happines, procedureTime));
        }
    }
}
