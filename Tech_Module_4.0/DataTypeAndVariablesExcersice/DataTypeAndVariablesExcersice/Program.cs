using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;

namespace DataTypeAndVariablesExcersice
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            int valueInt;
            float valueFloat;
            char valueChar;
            bool vaalueBool;

            while (input != "END")
            {
                if (int.TryParse(input,out valueInt))
                {
                    Console.WriteLine($"{input} is integer type");
                }
                else if(float.TryParse(input,out valueFloat))
                {
                    Console.WriteLine($"{input} is floating point type");
                }
                else if (char.TryParse(input,out valueChar))
                {
                    Console.WriteLine($"{input} is character type");
                }
                else if (bool.TryParse(input, out vaalueBool))
                {
                    Console.WriteLine($"{input} is boolean type");
                }
                else
                {
                    Console.WriteLine($"{input} is string type");
                }
                
                input = Console.ReadLine();
            }
            

        }
    }
}
