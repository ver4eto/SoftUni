using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P01_RawData
{
    class Runner
    {      

        public void Run()
        {
            List<Car> cars = new List<Car>();
           
            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string model = parameters[0];
                int engineSpeed = int.Parse(parameters[1]);
                int enginePower = int.Parse(parameters[2]);
                int cargoWeight = int.Parse(parameters[3]);
                string cargoType = parameters[4];

                double FirstTirePressure = double.Parse(parameters[5]);
                int FirstTireAge = int.Parse(parameters[6]);
                Tire firstTire = new Tire(FirstTireAge, FirstTirePressure);
                
                
                double SecondTirePressure = double.Parse(parameters[7]);
                int SecondTireAge = int.Parse(parameters[8]);
                Tire secondTire = new Tire(SecondTireAge, SecondTirePressure);

                double ThirdTirePressure = double.Parse(parameters[9]);
                int ThirdTireAge = int.Parse(parameters[10]);
                Tire thirdTire = new Tire(ThirdTireAge, ThirdTirePressure);

               
                double FourthTirePressure = double.Parse(parameters[11]);
                int FourthTireAge = int.Parse(parameters[12]);
                Tire fourthTire = new Tire(FourthTireAge, FourthTirePressure);

                
                Car car = new Car(model, engineSpeed, enginePower, cargoWeight, cargoType,firstTire, secondTire, thirdTire, fourthTire
                    );

                cars.Add(car);
            }

            string command = Console.ReadLine();
            if (command == "fragile")
            {
                List<string> fragile = cars
                    .Where(x => x.Cargo.CargoType == "fragile" && x.Tires.Any(t => t.TirePressure < 1)
                    /*.Any(y => y.Key < 1)*/)
                    .Select(x => x.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, fragile));
            }
            else
            {
                List<string> flamable = cars
                    .Where(x => x.Cargo.CargoType == "flamable" && x.Engine.EnginePower > 250)
                    .Select(x => x.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, flamable));
            }
        }
    }
}
