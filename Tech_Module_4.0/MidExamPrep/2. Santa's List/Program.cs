using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Santa_s_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> kids = Console.ReadLine()
                .Split('&')
                .ToList();

            string command = Console.ReadLine();

            while (command!= "Finished!")
            {
                string[] tokens = command.Split().ToArray();
                string action = tokens[0];
                string kidsName = tokens[1];
                switch (action)
                {
                    case "Bad":
                        if (!kids.Contains(kidsName))
                        {
                            kids.Insert(0, kidsName);
                        }
                        break;
                    case "Good":
                        if (kids.Contains(kidsName))
                        {
                            kids.Remove(kidsName);
                        }
                        break;
                    case "Rename":
                        string kidsNewName = tokens[2];
                        if (kids.Contains(kidsName))
                        {
                            int indexOldName = kids.IndexOf(kidsName);
                            kids.Insert(indexOldName, kidsNewName);
                            kids.Remove(kidsName);
                        }
                        break;
                    case "Rearrange":
                        if (kids.Contains(kidsName))
                        {
                            kids.Remove(kidsName);
                            kids.Add(kidsName);
                        }
                        break;
                    default:
                        break;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(", ",kids));
        }
    }
}
