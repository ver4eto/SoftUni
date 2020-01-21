using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                  .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            HashSet<string> parkingLot = new HashSet<string>();

            while (input[0] !="END")
            {
                string direction = input[0];
                string carPlateNumber = input[1];

                switch (direction)
                {
                    case "IN":
                        parkingLot.Add(carPlateNumber);
                        break;
                    case "OUT":
                        if (parkingLot.Count>0 && parkingLot.Contains(carPlateNumber))
                        {
                            parkingLot.Remove(carPlateNumber);
                        }
                        break;
                    default:
                        break;
                }

                input = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);
            }

            if (parkingLot.Count>0)
            {
                foreach (var car in parkingLot)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
