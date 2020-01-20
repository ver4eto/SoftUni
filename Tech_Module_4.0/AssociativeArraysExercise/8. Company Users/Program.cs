using System;
using System.Linq;
using System.Collections.Generic;

namespace _8._Company_Users
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companies = new Dictionary<string, List<string>>();

            string command = Console.ReadLine();

            while (command!= "End")
            {
                string[] tokens = command.Split(" -> ").ToArray();
                string companyName = tokens[0];
                string employeeID = tokens[1];

                if (!companies.ContainsKey(companyName))
                {
                    companies.Add(companyName, new List<string>());
                    companies[companyName].Add(employeeID);
                }
                else
                {
                    if (companies[companyName].Contains(employeeID))
                    {
                        command = Console.ReadLine();
                        continue;
                    }
                    else
                    {
                        companies[companyName].Add(employeeID);
                    }
                }

                command = Console.ReadLine();
            }

            foreach (var company in companies.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{company.Key}");
                foreach (var item in company.Value)
                {
                    Console.WriteLine($"-- {item}");
                }
            }
        }
    }
}
