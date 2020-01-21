using System;

namespace _1
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
            double distanceCurrDay = 0;
            double fuelCurrDay = 0;
            double expencesCurrDay = 0;
            double totalExpences = 0;
            double additionalExpnecs = 0;

            if (personsInGroup>10)
            {
                hotelPerPersonPerNight *= 0.75;
            }
            double allExp = 0;

            for (int i = 1; i <= days; i++)
            {
                distanceCurrDay = double.Parse(Console.ReadLine());
                fuelCurrDay = distanceCurrDay * fuelPerKm;

                expencesCurrDay = (foodPerPersonPerDay + hotelPerPersonPerNight) * personsInGroup + fuelCurrDay;
                totalExpences += expencesCurrDay;

                if (i%3==0)
                {
                    additionalExpnecs+= totalExpences * 0.4;

                }
                if (i%5==0)
                {
                    additionalExpnecs+= totalExpences * 0.4;
                }
                if (i%7==0)
                {
                    double received = totalExpences / personsInGroup;
                    totalExpences -= received;                         
                }
                allExp += totalExpences + additionalExpnecs;
                if (allExp>budget)
                {
                    Console.WriteLine("Not enough money to continue the trip");
                    break;
                }
                
            }
            if (budget>=allExp)
            {
                double moneyLeft = budget - allExp;
                Console.WriteLine($"You have reached the destination. You have {moneyLeft:f2}$ budget left.");

            }
            else
            {
                double moneyNeeded = allExp - budget;
                Console.WriteLine($"Not enough money to continue the trip. You need {moneyNeeded:f2}$ more.");
            }
        }
    }
}
