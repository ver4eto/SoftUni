using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //  int count = int.Parse(Console.ReadLine());

            //  Family family = new Family();

            //  for (int i = 0; i < count; i++)
            //  {
            //      string[] input = Console.ReadLine().Split();

            //      string memberName = input[0];
            //      int age = int.Parse(input[1]);

            //      Person member = new Person(memberName, age);
            //      family.AddMember(member);
            //  }

            //Person oldestMember= family.GetOldestMember();
            //  Console.WriteLine($"{oldestMember.Name} {oldestMember.Age}");

            int n = int.Parse(Console.ReadLine());

         
            List<Person> allPersons = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                string name = input[0];
                int age = int.Parse(input[1]);

                Person person = new Person();
                person.Age = age;
                person.Name = name;

                if (!allPersons.Contains(person))
                {
                    if (person.Age>30)
                    {
                        allPersons.Add(person);
                    }
                }

            }

            foreach (var name in allPersons.OrderBy(x => x.Name))
            {
                Console.WriteLine($"{name.Name} - {name.Age}");
            }
        }
    }
}
