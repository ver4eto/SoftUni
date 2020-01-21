using System;
using System.Linq;

namespace Santa_s_Cookies
{
    class Program
    {
        static void Main(string[] args)
        {
            int batchesForBaking = int.Parse(Console.ReadLine());

            int flour = 0;
            int sugar = 0;
            int cocoa = 0;
            
            int singleCookie = 25;
            int cup = 140;
            int smallSpoon = 10;
            int bigSpoon = 20;
            int cookiesPerBox = 5;
            
            int flourCups = flour / cup;
            int sugarSpoons = sugar / bigSpoon;
            int cocoaSpoon = cocoa / smallSpoon;

            
            int totalBoxes = 0;

            while (batchesForBaking>0)
            {
                flour = int.Parse(Console.ReadLine());
                sugar = int.Parse(Console.ReadLine());
                cocoa = int.Parse(Console.ReadLine());

                 flourCups = flour / cup;
                 sugarSpoons = sugar / bigSpoon;
                 cocoaSpoon = cocoa / smallSpoon;

                if (flourCups<=0 || sugarSpoons<=0 || cocoaSpoon<=0)
                {
                    Console.WriteLine("Ingredients are not enough for a box of cookies.");
                }
                else
                {
                    int[] product = { flourCups, sugarSpoons, cocoaSpoon };

                    int totalCookiePerBake = (cup + smallSpoon + bigSpoon) * product.Min() / singleCookie;
                    int boxesOfCookiesPerBatch = totalCookiePerBake / cookiesPerBox;
                   
                    

                    Console.WriteLine($"Boxes of cookies: {boxesOfCookiesPerBatch}");
                    totalBoxes += boxesOfCookiesPerBatch;
                }
                batchesForBaking--;
            }
            Console.WriteLine($"Total boxes: {totalBoxes}");
        }
    }
}
