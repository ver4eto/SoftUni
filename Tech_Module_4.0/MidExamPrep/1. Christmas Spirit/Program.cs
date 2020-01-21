using System;

namespace _1._Christmas_Spirit
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int ornamentSetPricePerPiece = 2;
            int treeSkirtPricePerPiece = 5;
            int treeGarlandsPricePerPiece = 3;
            int treeLightsPricePerPiece = 15;

            int allowedQualityOfType = int.Parse(Console.ReadLine());
            int daysLeft = int.Parse(Console.ReadLine());

            int totalSpirit = 0;
            int totalExpences = 0;

            for (int i = 1; i <= daysLeft; i++)
            {
                if (i % 11 == 0)
                {
                   allowedQualityOfType +=2;
                }
                if (i%2==0)
                {
                    totalExpences += allowedQualityOfType * ornamentSetPricePerPiece;
                    totalSpirit += 5;
                }
                if (i%3==0)
                {
                    totalExpences += (treeSkirtPricePerPiece + treeGarlandsPricePerPiece) * allowedQualityOfType;
                    totalSpirit += 13;
                }
                if (i%5==0)
                {
                    totalExpences += allowedQualityOfType * treeLightsPricePerPiece;
                    totalSpirit += 17;
                    if (i%3==0)
                    {
                        totalSpirit += 30;
                    }
                }
                if (i%10==0)
                {
                    totalSpirit -= 20;
                    totalExpences += treeSkirtPricePerPiece + treeGarlandsPricePerPiece + treeLightsPricePerPiece;
                    if (i == daysLeft)
                    {
                        totalSpirit -= 30;
                    }
                }
                
               
            }

           
            Console.WriteLine($"Total cost: {totalExpences}");
            Console.WriteLine($"Total spirit: {totalSpirit}");
        }
    }
}
