using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    class Program
    {
        static void Main(string[] args)
        {

            int number = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();


            for (int i = 0; i < number; i++)
            {
                string[] input = Console.ReadLine().Split();
                //"{model} {engineSpeed} {enginePower} {cargoWeight} {cargoType} {tire1Pressure} " +
                //    "{tire1Age} {tire2Pressure} {tire2Age} {tire3Pressure} {tire3Age} {tire4Pressure} {tire4Age}"
                string model = input[0];
                int engineSpeed = int.Parse(input[1]);
                int endginePower = int.Parse(input[2]);
                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];
                double firstTirePressure = double.Parse(input[5]);
                int firstTireAge = int.Parse(input[6]);
                double secondTirePressure = double.Parse(input[7]);
                int secondTireAge = int.Parse(input[8]);
                double thirdTirePressure = double.Parse(input[9]);
                int thirdTireAge = int.Parse(input[10]);
                double fourTirePressure = double.Parse(input[11]);
                int fourTireAge = int.Parse(input[12]);

                Car car = new Car(model,engineSpeed,endginePower,cargoWeight, cargoType, firstTirePressure, firstTireAge, secondTirePressure, secondTireAge,
                    thirdTirePressure, thirdTireAge, fourTirePressure, fourTireAge);

                cars.Add(car);
          
            }

            
            string filter = Console.ReadLine();
            if (filter== "fragile")
            {
                cars=cars.OrderBy(x=>x.Tires.)
            }
         
          
        }
    }
}
