using System;
using System.Collections.Generic;
using System.Linq;

namespace _8._Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCarsPassingGreen = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();
            int passedCars = 0;
            Queue<string> cars = new Queue<string>();

            while (input !="end")
            {
                if (input=="green")
                {
                    for (int i = 0; i < numberOfCarsPassingGreen; i++)
                    {
                        if (cars.Count>0)
                        {
                            string currentCar = cars.Peek();
                            cars.Dequeue();
                            passedCars++;
                            Console.WriteLine($"{currentCar} passed!");
                        }
                        
                    }
                }
                else
                {
                    cars.Enqueue(input);
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"{passedCars} cars passed the crossroads.");
        }
    }
}
