using System;

namespace Workshop
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new CustomList();
            var list2 = new CustomList(50);

            list.Add(7);
            list.Add(12);
            list.Add(23);

            list.AddRange(new int[] { 7, 34, 56, 12, 89, 65, 34, 2});
            list.RemoveAt(3);
            list.InsertAt(1456, 90);
            list.InsertAt(4, 8);
            list.Swap(0, 8);

            list.ForEach(Console.Write);

        }
    }
}
