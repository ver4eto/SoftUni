using System;
using System.Linq;
using System.Collections.Generic;

namespace _6._Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();
            string command = Console.ReadLine();

            while (command!="end")
            {
                string[] tokens = command.Split(" : ").ToArray();
                string courseName = tokens[0];
                string studentName = tokens[1];

                if (!courses.ContainsKey(courseName))
                {
                    courses.Add(courseName,new List<string>());
                   
                }
                courses[courseName].Add(studentName);
                command = Console.ReadLine();
            }


            foreach (var item in courses.OrderByDescending(x => x.Value.Count))
            {
                Console.WriteLine($"{item.Key}: {item.Value.Count}");
                foreach (var name in item.Value.OrderBy(x=>x))
                {
                    Console.WriteLine($"-- {name}");
                }
            }
        }
    }
}
