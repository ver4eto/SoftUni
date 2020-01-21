using System;

namespace Date_Modifier
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();

            DateModifier dateModifier = new DateModifier();
            Console.WriteLine(dateModifier.DifferenceBetweenTwoDates(firstDate,secondDate));
        }
    }
}
