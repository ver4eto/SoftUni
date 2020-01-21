using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Google_Seaches
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalDays = int.Parse(Console.ReadLine());
            int numberOfUsers = int.Parse(Console.ReadLine());
            double moneyPerSearch = double.Parse(Console.ReadLine());

            double currentUserSum = 0;
            double totalSum = 0;
            int wordsInSearch = 0;
            int currentUserCount = 1;

            while (currentUserCount<=numberOfUsers)
            {
                wordsInSearch = int.Parse(Console.ReadLine());
                if (wordsInSearch==1)
                {
                    currentUserSum = moneyPerSearch * 2;                    
                }
              else  if (wordsInSearch>1&&wordsInSearch<=5)
                {
                    currentUserSum = moneyPerSearch ;
                }
                if (currentUserCount%3==0)
                {
                    currentUserSum *= 3;
                }
                totalSum += currentUserSum;
                currentUserCount++;
                currentUserSum = 0;
            }
            totalSum *= totalDays;
            Console.WriteLine($"Total money earned for {totalDays} days: {totalSum:f2}");
        }
    }
}
