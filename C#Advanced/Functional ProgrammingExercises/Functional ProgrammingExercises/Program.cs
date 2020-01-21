using System;


namespace Functional_ProgrammingExercises
{
    class Program
    {
        static void Main(string[] args)
        {

            Action<string []> printNames = names =>
            Console.WriteLine(string.Join(Environment.NewLine,names));

            string[] inputNames = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            printNames(inputNames);

        }

        
    }
}
