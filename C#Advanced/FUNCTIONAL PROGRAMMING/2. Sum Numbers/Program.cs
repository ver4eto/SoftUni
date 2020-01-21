using System;
using System.Linq;

namespace _2._Sum_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(ParseMY)
                .ToArray();

            int count = numbers.Count();
            Console.WriteLine(count);
            int sum = numbers.Sum();
            Console.WriteLine(sum);
        }

       public static Func<string, int> ParseMY = n =>
       {
           int result = 0;

           if (Int32.TryParse(n, out result))
           {
               return result;
           }

           return 0;
       };
    }
}
