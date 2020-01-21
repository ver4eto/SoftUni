using System;
using System.Collections.Generic;

namespace _5._HTML
{
    class Program
    {
        static void Main(string[] args)
        {
            string title = Console.ReadLine();
            string article = Console.ReadLine();
            List<string> comments = new List<string>();
            string input = Console.ReadLine();
            while (input!= "end of comments")
            {
                comments.Add(input);
                input = Console.ReadLine();
            }
            Console.WriteLine("<h1>");
            Console.WriteLine($"    {title}");
            Console.WriteLine("</h1>");
            Console.WriteLine("<article>");
            Console.WriteLine($"    {article}");
            Console.WriteLine("</article>");

            for (int i = 0; i < comments.Count; i++)
            {
                Console.WriteLine("<div>");
                Console.WriteLine($"    {comments[i]}");
                Console.WriteLine("</div>");
            }
        }
    }
}
