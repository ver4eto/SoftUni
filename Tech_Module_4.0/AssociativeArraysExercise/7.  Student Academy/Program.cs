using System;
using System.Linq;
using System.Collections.Generic;

namespace _7.__Student_Academy
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();
            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {

                string name = Console.ReadLine();

                double grade = double.Parse(Console.ReadLine());
               
                if (!students.ContainsKey(name))
                {
                    students.Add(name, new List<double>());
                }
                students[name].Add(grade);
            }
            
            foreach (var item in students.OrderByDescending(x => x.Value.Average()))
            {
                if (item.Value.Average() >= 4.5)
                {
                    Console.WriteLine($"{item.Key} -> {(item.Value.Average()):f2}");
                }
            }

        }
    }
}
