using System;
using System.Linq;
using System.Collections.Generic;

namespace MeTube_Statistics
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> videosViews = new Dictionary<string, int>();
            Dictionary<string, int> likeVideos = new Dictionary<string, int>();
            string input = Console.ReadLine();

            while (input != "stats time")
            {
                string[] tokens = input
               .Split(new char[] { ':', '-' })
               .ToArray();

                string firstWord = tokens[0];

                switch (firstWord)
                {                    
                    case "like":
                        string videoForLike = tokens[1];
                        if (videosViews.ContainsKey(videoForLike))
                        {
                                likeVideos[videoForLike]++;
                            
                        }
                        break;
                    case "dislike":
                        string videoForDislike = tokens[1];
                        if (videosViews.ContainsKey(videoForDislike))
                        {
                           
                                likeVideos[videoForDislike]--;
                            
                        }
                        break;
                    default:
                        int views = int.Parse(tokens[1]);
                        if (!videosViews.ContainsKey(firstWord))
                        {
                            videosViews.Add(firstWord,views);
                            likeVideos.Add(firstWord,0);
                        }
                        else
                        {
                            videosViews[firstWord] += views;
                        }
                        break;
                }
                input = Console.ReadLine();
            }
            string command = Console.ReadLine();

            if (command== "by views")
            {
                foreach (var kvp in videosViews.OrderByDescending(x=>x.Value))
                {
                    foreach (var likes in likeVideos)
                    {
                        if (likes.Key==kvp.Key)
                        {
                            Console.WriteLine($"{kvp.Key} - {kvp.Value} views - {likes.Value} likes");
                        }
                    }
                }
            }
            else
            {
                foreach (var like in likeVideos.OrderByDescending(x=>x.Value))
                {
                    foreach (var kvp in videosViews)
                    {
                        if (kvp.Key==like.Key)
                        {
                            Console.WriteLine($"{kvp.Key} - {kvp.Value} views - {like.Value} likes");
                        }
                    }
                }
            }
           
        }
    }
}
