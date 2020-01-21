using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<List<int>, List<int>> add = x => x.Select(y => y + 1).ToList();
         
            Func<List<int>, List<int>> multiply = x => x.Select(y=>y*2).ToList();
            Func<List<int>, List<int>> substract = x => x.Select(y => y - 1).ToList(); 

            Action<List<int>> printNumbers= x=>
            Console.WriteLine(string.Join(" ",x));

            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
              .ToList();

            string action = Console.ReadLine();

            while (action !="end")
            {
                switch (action)
                {
                    case "add":
                      numbers= add(numbers);
                        break;
                    case "subtract":
                       numbers= substract(numbers);
                        break;
                    case "multiply":
                      numbers=  multiply(numbers);
                        break;
                    case "print":
                        printNumbers(numbers);
                        break;                            
                    default:
                        break;
                }


                action = Console.ReadLine();
            }
            

        }
    }
}
