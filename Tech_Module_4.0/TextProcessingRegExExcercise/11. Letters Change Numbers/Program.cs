using System;
using System.Text;
using System.Linq;
using System.Numerics;

namespace _11._Letters_Change_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] whitespace = new char[] { ' ', '\t','\n'};
            string[] input = Console.ReadLine()
                .Split(whitespace, StringSplitOptions.RemoveEmptyEntries)
                  .ToArray();
            double result =0;

            for (int i = 0; i < input.Length; i++)
            {
                string current = input[i];
                for (int j = 0; j < current.Length; j++)
                {
                    string subCurrent = current.Substring(1, current.Length - 2);
                    double number = double.Parse(subCurrent);
                    double currentSum = 0;
                    //Console.WriteLine(number);
                    if (j==0)
                    {
                        if (char.IsUpper(current[j]))
                        {

                            currentSum += number / ((int)current[j] - 64);
                        }
                        else if (char.IsLower(current[j]))
                        {
                            currentSum += number* ((int)current[j] - 96);
                        }

                        result += currentSum;
                       
                    }


                    else if(j==current.Length-1)
                    {
                        if (char.IsLower(current[j]))
                        {
                            currentSum += ((int)current[j] - 96);
                        }
                        else if (char.IsUpper(current[j]))
                        {
                            currentSum -= ((int)current[j] - 64);
                        }
                        result += currentSum;
                        currentSum = 0;

                    }
                   
                }

            }
            Console.WriteLine($"{result:f2}");
        }
    }
}
