using System;
using CollectionHierarchy.Models;
using CollectionHierarchy.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CollectionHierarchy
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<string> myList = Console.ReadLine().Split().ToList();

            int countOfRemoves = int.Parse(Console.ReadLine());

            AddCollection collection = new AddCollection();
            collection.CollectedData = myList;
          
        }
    }
}
