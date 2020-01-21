using System;
using System.Linq;
using System.Collections.Generic;

namespace _6.__Auto_Repair_and_Service
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split()
                .ToArray();

            Queue<string> carsForService = new Queue<string>(input);
            Stack<string> servicedCars = new Stack<string>();

            while (input[0] !="End")
            {
                string command = input[0];
                switch (command)
                {
                    case "Service":
                        if (carsForService.Count>0)
                        {
                            string vehicle = carsForService.Dequeue();
                            Console.WriteLine($"Vehicle {vehicle} got served.");
                            servicedCars.Push(vehicle);
                        }
                       
                        break;
                    case "CarInfo":
                        string model = input[1];
                        if (carsForService.Contains(model))
                        {
                            Console.WriteLine("Still waiting for service.");
                        }
                        else
                        {
                            Console.WriteLine("Served.");
                        }
                        break;
                    case "History":
                        Console.WriteLine(string.Join(", ",servicedCars));
                        break;
                    default:
                        break;
                }

                input = Console.ReadLine()
                .Split("-")
                .ToArray();
            }
            if (carsForService.Count>0)
            {
                Console.WriteLine($"Vehicles for service: {string.Join(", ", carsForService)}");
            }
            Console.WriteLine($"Served vehicles: {string.Join(", ", servicedCars)}");
        }
    }
}
