using System;

namespace Spring_Vacation_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());
            int people = int.Parse(Console.ReadLine());
            double fuelConsumption = double.Parse(Console.ReadLine());
            double foodPerPersonPerDay = double.Parse(Console.ReadLine());
            double hotelPerPersonPerDay = double.Parse(Console.ReadLine());

            double totalHotel = days * people * hotelPerPersonPerDay;
            if (people>10)
            {
                totalHotel *= 0.75;
            }
            double foodTotal = days * people * foodPerPersonPerDay;
            double currentExpences = foodTotal + totalHotel;

            double travelledDistance = 0;
            double fuelTotal = 0;
            double currentFuel = 0;

            double additionalExpences = 0;
            double total = currentExpences;
          

            for (int i = 1; i <= days; i++)
            {
                travelledDistance = double.Parse(Console.ReadLine());
                currentFuel= travelledDistance * fuelConsumption;
                total += currentFuel;
                if (i%3==0 ||i%5==0)
                {
                    additionalExpences = total * 0.4;
                    currentExpences += additionalExpences;
                    total += additionalExpences;
                }
             
            
                if (i%7==0)
                {
                    double receivedMoney = total / people;
                   total -= receivedMoney;
                }
                             
                if (total>=budget)
                {
                   
                    break;
                }
            }

            if (total>budget)
            {
                double needed = total - budget;
                Console.WriteLine($"Not enough money to continue the trip. You need {needed:f2}$ more.");
            }
            else
            {
                double left = budget - total;
                Console.WriteLine($"You have reached the destination. You have {left:f2}$ budget left.");
            }
        }
    }
}
