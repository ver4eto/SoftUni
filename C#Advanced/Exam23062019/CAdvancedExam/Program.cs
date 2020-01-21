using System;
using System.Collections.Generic;
using System.Linq;

namespace CAdvancedExam
{
    class Program
    {
        static void Main(string[] args)
        {

            //            Glass   25
            //Aluminium   50
            //Lithium 75
            //Carbon fiber    100


            int glass = 25;
            int glassCount = 0;
            int aluminum = 50;
            int aluminumCount = 0;

            int lithium = 75;
            int lithiumCount = 0;

            int carbonFiber = 100;
            int carbonCount = 0;

            int[] inputChemicals = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] phisicalItemsInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> chemicalLiquids = new Queue<int>(inputChemicals);
            Stack<int> phisicalItem = new Stack<int>(phisicalItemsInput);
            List<string> allBuildProducts = new List<string>();

            while (chemicalLiquids.Count>0 && phisicalItem.Count>0)
            {
                int currentChemical = chemicalLiquids.Peek();
                int currentPhisical = phisicalItem.Peek();

                int bothSum = currentChemical + currentPhisical;


                if (bothSum==glass || bothSum==aluminum || bothSum==lithium || bothSum==carbonFiber)
                {
                    chemicalLiquids.Dequeue();
                    phisicalItem.Pop();
                    if (bothSum==glass)
                    {
                        glassCount++;
                        allBuildProducts.Add("glass");
                    }
                    else if (bothSum==aluminum)
                    {
                        aluminumCount++;
                        allBuildProducts.Add("aluminium");
                    }
                    else if (bothSum==lithium)
                    {
                        lithiumCount++;
                        allBuildProducts.Add("lithium");
                    }
                    else if (bothSum==carbonFiber)
                    {
                        carbonCount++;
                        allBuildProducts.Add("carbon");
                    }
                }
                else
                {
                    chemicalLiquids.Dequeue();
                    currentPhisical += 3;
                    phisicalItem.Pop();
                    phisicalItem.Push(currentPhisical);
                }
            }

            if (allBuildProducts.Contains("glass") && allBuildProducts.Contains("aluminium")
                && allBuildProducts.Contains("lithium")&& allBuildProducts.Contains("carbon"))
            {
                Console.WriteLine( "Wohoo! You succeeded in building the spaceship!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to build the spaceship.");
            }
            if (chemicalLiquids.Count==0)
            {
                Console.WriteLine("Liquids left: none");
            }
            else
            {
                Console.WriteLine($"Liquids left: {string.Join(", ",chemicalLiquids)}");
            }
            if (phisicalItem.Count==0)
            {
                Console.WriteLine("Physical items left: none");
            }
            else
            {
                Console.WriteLine($"Physical items left: {string.Join(", ",phisicalItem)}");
            }

            //Dictionary<string, int> materials = new Dictionary<string, int>();
            //materials.Add("");

            Console.WriteLine($"Aluminium: {aluminumCount}");
            Console.WriteLine($"Carbon fiber: {carbonCount}");
            Console.WriteLine($"Glass: {glassCount}");
            Console.WriteLine($"Lithium: {lithiumCount}");
        }
    }
}
