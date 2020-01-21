using System;

namespace _2._Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {

            Action<string[]> updatedNames = names =>
            Console.WriteLine("Sir "+Environment.NewLine,names);

            string[] inputNames = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            updatedNames(inputNames);
        }
    }
}
