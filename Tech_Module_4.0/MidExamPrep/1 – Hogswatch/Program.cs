using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1___Hogswatch
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberHomesForVisit = int.Parse(Console.ReadLine());
            int initialPresents = int.Parse(Console.ReadLine());

            int currentHousePresentNeeded = 0;
            int homesVisited = 0;
            int additinalPresentsNeededCurrentHouse = 0;
            int additinalTotalPresens = 0;
            int availablePresents = initialPresents;
            int remainingHomes = numberHomesForVisit;
            int countOfReturn = 0;

            for (int i =1; i <= numberHomesForVisit; i++)
            {
                currentHousePresentNeeded = int.Parse(Console.ReadLine());
                homesVisited++;
                remainingHomes--;
                if (currentHousePresentNeeded<=availablePresents)
                {
                    availablePresents -= currentHousePresentNeeded;
                   
                }
                else
                {
                    additinalPresentsNeededCurrentHouse = currentHousePresentNeeded - availablePresents;
                    availablePresents = (initialPresents / homesVisited)
                        * (remainingHomes) + additinalPresentsNeededCurrentHouse;
                    additinalTotalPresens += availablePresents;
                    //availablePresents = additinalPresentsNeededCurrentHouse;
                    availablePresents -= additinalPresentsNeededCurrentHouse;
                    countOfReturn++;
                                     
                }
            }

            if (countOfReturn==0)
            {
                Console.WriteLine(availablePresents);
            }
            else
            {
                Console.WriteLine(countOfReturn);
                Console.WriteLine(additinalTotalPresens);
            }
        }
    }
}
