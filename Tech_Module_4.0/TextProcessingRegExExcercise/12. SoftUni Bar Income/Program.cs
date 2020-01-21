using System;
using System.Text.RegularExpressions;

namespace _12._SoftUni_Bar_Income
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"\%(?<name>[A-Z][a-z]+)\%[|$.%]*\<(?<product>\w*)\>[$%|.]*\|(?<count>[0-9]+)\|(?<price>[0-9]+.[0-9]*)\$";

            double totalIncome = 0.0;

            while (input != "end of shift")
            {
                //MatchCollection orders = Regex.Matches(input, pattern);

                //foreach (Match item in orders)
                //{
                //    Console.WriteLine($"{item.Groups["firstName"].Value}" +
                //        $"{item.Groups["product"].Value}" +
                //        $"{item.Groups["count"].Value}" +
                //        $"{item.Groups["price"].Value}");
                //}


                Regex order = new Regex(pattern);

                if (order.IsMatch(input))
                {
                    string firstName = order.Match(input).Groups["name"].Value;
                    //Console.WriteLine(firstName);
                    string product = order.Match(input).Groups["product"].Value;
                    //Console.WriteLine(product);
                    string toInt = order.Match(input).Groups["count"].Value;
                    //Console.WriteLine(toInt);
                    int count = int.Parse(toInt);
                    double price = double.Parse(order.Match(input).Groups["price"].Value);

                    double totalPrice = count * price;
                    totalIncome += totalPrice;
                    Console.WriteLine($"{firstName}: {product} - {totalPrice:f2}");
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Total income: {totalIncome:f2}");
        }
    }
}
