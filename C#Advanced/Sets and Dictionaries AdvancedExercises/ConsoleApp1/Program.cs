using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> myDic = new Dictionary<string, Dictionary<string, int>>();

            string[] input = Console.ReadLine()
                .Split()
                .ToArray();
            string follower = input[0];
            string action = input[1];
            string personWhoIsFolled = input[2];

            if (myDic.ContainsKey(follower) 
                && myDic.ContainsKey(personWhoIsFolled)
                && follower != personWhoIsFolled)
            {
                myDic.Add(personWhoIsFolled,new Dictionary<string, int>());
                myDic[personWhoIsFolled].Add(follower,0);
                myDic[follower].
            }
        }
    }
}
