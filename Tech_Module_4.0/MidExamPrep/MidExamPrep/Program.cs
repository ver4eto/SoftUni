using System;

namespace MidExamPrep
{
    class Program
    {
        static void Main(string[] args)
        {
            int partySize = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());

                        
            int coinsReceivedTotal = 0;
            int motivationalPartyMoney = 0;
            int foodMoney = 0;

            for (int i = 1; i <= days; i++)
            {
                if (i%10==0)
                {
                    partySize -= 2;
                }
                if (i%15==0)
                {
                    partySize += 5;
                }
                coinsReceivedTotal += 50;
                foodMoney += (partySize * 2);

                if (i%3==0)
                {
                    motivationalPartyMoney += 3 * partySize;
                }
                if (i%5==0)
                {
                    coinsReceivedTotal += 20 * partySize;
                    if (i%3==0)
                    {
                        motivationalPartyMoney += 2 * partySize;
                    }
                }                
            }

            int totalCoinsLeft = coinsReceivedTotal - motivationalPartyMoney - foodMoney;
            int moneyByOneCompanion = totalCoinsLeft / partySize;

            Console.WriteLine($"{partySize} companions received {moneyByOneCompanion} coins each.");
        }
    }
}
