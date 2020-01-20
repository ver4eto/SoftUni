using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;


namespace arraysExcercise
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            GradeInWOrds(number);

        }

        static void GradeInWOrds(double grade)
        {
            if (grade<=2.99)
            {
                Console.WriteLine("Fail");
            }
            else if (grade>2.99&&grade   <=3.49)
            {
                Console.WriteLine("Poor");
            }
            else if(grade>=3.50&&grade<=4.49)
            {
                Console.WriteLine("Good");
            }
            else if (grade>=4.50&&grade<=5.49)
            {
                Console.WriteLine("Very good");
            }
            else if (grade>=5.50)
            {
                Console.WriteLine("Excellent");
            }
        }
    }
}




