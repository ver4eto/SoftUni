using System;
using ExplicitInterfaces.Interfaces;
using ExplicitInterfaces.Models;

namespace ExplicitInterfaces
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string[] tokens = Console.ReadLine().Split();
                if (tokens[0]=="End")
                {
                    break;
                }
                Citizen citizen = new Citizen(tokens[0]);

                IPerson person = citizen;
                IResident resident = citizen;

                person.GetName();
                resident.GetName();
            }
           

        }
    }
}
