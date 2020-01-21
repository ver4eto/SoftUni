using System;
using Vehicles.Models;

namespace Vehicles
{
   public class StartUp
    {
        static void Main(string[] args)
        {

            string[] carInput = ReadInfoFromConsole();
            string[] truckInput = ReadInfoFromConsole();
            string[] busInput = ReadInfoFromConsole();

            Car car =(Car)CreateVehicle(carInput);                       
            Truck truck = (Truck)CreateVehicle(truckInput);            
            Bus bus = (Bus)CreateVehicle(busInput);

            int numberOfCommands = int.Parse(Console.ReadLine());

            while (numberOfCommands > 0)
            {
                try
                {
                    string[] commands = ReadInfoFromConsole();
                    string typeOfVehicle = commands[1];
                    string action = commands[0];
                    double number = double.Parse(commands[2]);

                    switch (typeOfVehicle)
                    {
                        case "Car":

                            if (action == "Drive")
                            {
                                car.Drive(number);
                            }
                            else if (action == "Refuel")
                            {
                                car.Refuel(number);
                            }
                            break;
                        case "Truck":
                            if (action == "Drive")
                            {
                                truck.Drive(number);
                            }
                            else if (action == "Refuel")
                            {
                                truck.Refuel(number);
                            }
                            break;
                        case "Bus":
                            if (action == "DriveEmpty")
                            {
                                bus.TypeOfBus = "empty";
                                bus.Drive(number);
                            }
                            else if (action == "Drive")
                            {
                                bus.Drive(number);
                            }
                            else if (action == "Refuel")
                            {
                                bus.Refuel(number);
                            }
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }

                numberOfCommands--;
            }

            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
            Console.WriteLine(bus.ToString());
        }

        private static Vehicle CreateVehicle(string[] inputInfo)
        {
            double fuelQuantity = double.Parse(inputInfo[1]);
            double fuelConsumption = double.Parse(inputInfo[2]);
            double tankCapacity = double.Parse(inputInfo[3]);

            string type = inputInfo[0];
            switch (type)
            {
                case "Car":
                   Car car = new Car(fuelQuantity, fuelConsumption, tankCapacity);
                    return car;
                case "Truck":
                    Truck truck = new Truck(fuelQuantity, fuelConsumption, tankCapacity);
                    return truck;
                case "Bus":
                    Bus bus = new Bus(fuelQuantity, fuelConsumption, tankCapacity);
                    return bus;
                default:
                    throw new Exception();
                  
            }
        }


        private static string[] ReadInfoFromConsole()
        {
            return Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
