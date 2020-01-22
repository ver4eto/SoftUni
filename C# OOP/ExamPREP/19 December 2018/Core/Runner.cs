using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniRestaurant.Core
{
public   class Runner
    {
        private RestaurantController restaurantcontroller;
        public Runner()
        {
            this.restaurantcontroller = new RestaurantController();
        }
        public void Run()
        {

            string command = Console.ReadLine();

            while (command != "END")
            {
                try
                {
                    string[] args = command.Split().ToArray();

                    string currentCommand = args[0];



                    if (currentCommand == "AddFood")
                    {
                        string typeOfFood = args[1];
                        string nameOfFood = args[2];
                        AddFood(args, typeOfFood, nameOfFood);
                    }
                    else if (currentCommand == "AddDrink")
                    {
                        string typeOfFood = args[1];
                        string nameOfFood = args[2];
                        AddDrink(args, typeOfFood, nameOfFood);
                    }
                    else if (currentCommand == "AddTable")
                    {
                        string type = args[1];
                        AddTable(args, type);
                    }
                    else if (currentCommand == "ReserveTable")
                    {
                        ReserveTable(args);
                    }
                    else if (currentCommand == "OrderFood")
                    {
                        OrderFood(args);
                    }
                    else if (currentCommand == "OrderDrink")
                    {
                        OrderDrink(args);
                    }
                    else if (currentCommand == "LeaveTable")
                    {
                        LeaveTable(args);
                    }
                    else if (currentCommand == "GetFreeTablesInfo")
                    {
                        Console.WriteLine(this.restaurantcontroller.GetFreeTablesInfo());
                    }
                    else
                    {
                        Console.WriteLine(this.restaurantcontroller.GetOccupiedTablesInfo());
                    }
                }
                catch (Exception EX)
                {

                    Console.WriteLine(EX.Message);
                }

                command = Console.ReadLine();
            }
            Console.WriteLine(this.restaurantcontroller.GetSummary());
        }

        private void LeaveTable(string[] args)
        {
            int tableNumber = int.Parse(args[1]);

            Console.WriteLine(this.restaurantcontroller.LeaveTable(tableNumber));
        }

        private void OrderDrink(string[] args)
        {
            int tableNumber = int.Parse(args[1]);
            string drinkName = args[2];
            string drinkBrand = args[3];

            Console.WriteLine(this.restaurantcontroller.OrderDrink(tableNumber, drinkName, drinkBrand));
        }

        private void OrderFood(string[] args)
        {
            int tableNumber = int.Parse(args[1]);
            string foodType = args[2];

            Console.WriteLine(this.restaurantcontroller.OrderFood(tableNumber, foodType));
        }

        private void ReserveTable(string[] args)
        {
            int numberOfPeople = int.Parse(args[1]);
            Console.WriteLine(this.restaurantcontroller.ReserveTable(numberOfPeople));
        }

        private void AddTable(string[] args, string typeOfFood)
        {
            int tableNumber = int.Parse(args[2]);
            int tableCapacity = int.Parse(args[3]);

            Console.WriteLine(this.restaurantcontroller.AddTable(typeOfFood, tableNumber, tableCapacity));
        }

        private void AddDrink(string[] args, string typeOfFood, string nameOfFood)
        {
            int servingSize = int.Parse(args[3]);
            string brand = args[4];
            Console.WriteLine(this.restaurantcontroller.AddDrink(typeOfFood, nameOfFood, servingSize, brand));
        }

        private void AddFood(string[] args, string typeOfFood, string nameOfFood)
        {
            decimal priceOfFood = decimal.Parse(args[3]);
            Console.WriteLine(this.restaurantcontroller.AddFood(typeOfFood, nameOfFood, priceOfFood));
        }
    }
}

