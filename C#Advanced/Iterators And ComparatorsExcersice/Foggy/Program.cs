using System;
using System.Linq;
using System.Collections.Generic;

namespace Foggy
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> stones = Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            Lake lake = new Lake(stones);
            Console.WriteLine(string.Join(", ", lake));
        }
    }
}
