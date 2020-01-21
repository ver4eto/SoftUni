using System;
using System.Collections.Generic;
using System.Linq;

namespace Party_Reservation_Filter_Module
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                 .Split()
                 .ToArray();

            List<string> filters = new List<string>();

            string filter = Console.ReadLine();
            while (filter !="Print")
            {
                string[] fileInfo = filter.Split(';');

                string action = fileInfo[0];

                if (action=="Add filter")
                {
                    filters.Add($"{fileInfo[1]}:{fileInfo[2]}");
                }
                else if (action=="Remove filter")
                {
                    filters.Remove($"{fileInfo[1]}:{fileInfo[2]}");
                }
                filter = Console.ReadLine();
            }


            Func<string, int, bool> lenghtFilter = (name, lenght) => name.Length == lenght;

            Func<string, string, bool> startsWith = (name, param) =>  name.StartsWith(param);

            Func<string, string, bool> endsWith = (name, param) => name.EndsWith(param);

            Func<string, string, bool> containsFilter = (name, param) => name.Contains(param);


            foreach (var currentFiler in filters)
            {
                string[] currentFilterInfo = currentFiler.Split(';');

                string action=currentFilterInfo[0];
                string param = currentFilterInfo[1];

                if (action=="Starts with")
                {
                    names=names.Where(name=>!startsWith(name,param)).ToArray();
                }
                else if (action == "Ends with")
                {
                    names = names.Where(name => !endsWith(name, param)).ToArray();
                }
                else if (action == "Contains")
                {
                    names = names.Where(name => !containsFilter(name, param)).ToArray();
                }
                else if (action == "Length")
                {
                    int lenght = int.Parse(param);
                    names = names.Where(name => !lenghtFilter(name,lenght)).ToArray();
                }

            }

            Console.WriteLine(string.Join(" ",names));
        }
    }
}
