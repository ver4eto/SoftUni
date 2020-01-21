using System;
using System.Collections.Generic;
using System.Linq;
using ShoppingSpree.Models;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] persons = Console.ReadLine()
                            .Split(new char[] { ';', '='},StringSplitOptions.RemoveEmptyEntries);

            string[] products = Console.ReadLine()
                .Split(new char[] { ';', '='},StringSplitOptions.RemoveEmptyEntries);

            List<Person> allPersons = new List<Person>();

            List<Product> allProducts = new List<Product>();

            try
            {
                for (int i = 0; i < persons.Length; i += 2)
                {

                    string name = persons[i];
                    double money = double.Parse(persons[i + 1]);

                    allPersons.Add(new Person(name, money));
                }

                for (int i = 0; i < products.Length; i += 2)
                {
                    string name = products[i];
                    double cost = double.Parse(products[i + 1]);

                    allProducts.Add(new Product(name, cost));
                }

                string command = Console.ReadLine();

                while (command != "END")
                {
                    string[] tokens = command.Split(' ');
                    string currentName = tokens[0];
                    string product = tokens[1];

                    Person currentPerson = allPersons.FirstOrDefault(x => x.Name == currentName);

                    Product currentProduct = allProducts.FirstOrDefault(p => p.Name == product);

                    currentPerson.BuyProduct(currentProduct);

                    command = Console.ReadLine();
                }

                foreach (Person person in allPersons)
                {
                    Console.WriteLine(person.ToString());
                }
            }
            catch (Exception ae)
            {
                Console.WriteLine(ae.Message);
            }

        }
    }
}
