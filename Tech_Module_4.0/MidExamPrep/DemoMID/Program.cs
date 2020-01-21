using System;
using System.Linq;
using System.Collections.Generic;

namespace DemoMID
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            double sumCurrentBatch = 0;
            double sumTotal = 0;
            List<int> breads = command
                   .Split('#')
                   .Select(int.Parse)
                   .ToList();

            List<int> bestQuality =breads;


            while (command != "Bake It!")
            {
               breads = command
                    .Split('#')
                    .Select(int.Parse)
                    .ToList();
                
                sumCurrentBatch = breads.Sum();
               
                if (sumCurrentBatch > sumTotal)
                {
                    sumTotal = sumCurrentBatch;                   
                    bestQuality = breads;
                   
                }
                else if (sumCurrentBatch == sumTotal)
                {
                   
                        int countCurrent = breads.Count;
                        int countPrev = bestQuality.Count;
                        if (countCurrent < countPrev)
                        {
                        sumTotal = sumCurrentBatch;
                            bestQuality = breads;                          
                        }                       
                    
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Best Batch quality: {bestQuality.Sum()}");
            Console.WriteLine(string.Join(" ", bestQuality));
        }
    }
}
