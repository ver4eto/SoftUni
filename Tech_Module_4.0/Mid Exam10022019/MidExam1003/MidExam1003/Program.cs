using System;

namespace MidExam1003
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());
            int personsInGroup = int.Parse(Console.ReadLine());
            double fuelPerKm = double.Parse(Console.ReadLine());
            double foodPerPersonPerDay = double.Parse(Console.ReadLine());
            double hotelPerPersonPerNight = double.Parse(Console.ReadLine());

            double distanceTravelledPerDay = 0d;
           
            if (personsInGroup>10)
            {
                hotelPerPersonPerNight *= 0.75;
            }

            double fuelTotal = 0;
            double currentDayForAll = 0;

            for (int i = 1; i <= days; i++)
            {
                distanceTravelledPerDay = double.Parse(Console.ReadLine());
                double currentDayFuel = distanceTravelledPerDay * fuelPerKm;
                fuelTotal +=currentDayFuel ;
                currentDayForAll = currentDayFuel + days * personsInGroup*(foodPerPersonPerDay + hotelPerPersonPerNight);
               
            }
            if (budget>=total)
            {
                double moneyLeft = budget - total;
                Console.WriteLine($"You have reached the destination.You have { moneyLeft:f2}$ budget left.");
            }
            else
            {
                double moneyNeeded = total - budget;
                Console.WriteLine($"Not enough money to continue the trip. You need {moneyNeeded:f2}$ more.");
            }
        }
    }
}
