using System;
using System.Linq;
using System.Collections.Generic;

namespace DemoFinal
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> allWords = new Dictionary<string, List<string>>();
            string input = Console.ReadLine();

                string[] tokens = input
                    .Split(" | ")
                    .ToArray();
                for (int i = 0; i < tokens.Length; i++)
                {
                    string current = tokens[i];
                    string[] currentWordDef = current.Split(": ").ToArray();
                    string word = currentWordDef[0];
                    string definition = currentWordDef[1];

                    if (!allWords.ContainsKey(word))
                    {
                        allWords.Add(word, new List<string>());
                        allWords[word].Add(definition);
                    }
                    else
                    {
                        allWords[word].Add(definition);
                    }
                    
                }

                string[] wordsForPrint = Console.ReadLine()
                  .Split(" | ")
                  .ToArray();

                for (int i = 0; i < wordsForPrint.Length; i++)
                {
                    string currentWord = wordsForPrint[i];
                                       
                        foreach (var item in allWords.Where(x => x.Key.Equals(currentWord)))
                        {
                            Console.WriteLine($"{ item.Key}");
                            foreach (var def in item.Value.OrderByDescending(x => x.Length))
                            {
                                Console.WriteLine($" -{def}");
                            }
                        }
                    
                }
            string finalAction = Console.ReadLine();
            if (finalAction== "List")
            {
                foreach (var word in allWords.OrderBy(x=>x.Key))
                {
                    Console.Write($"{word.Key} ");
                }
                Console.WriteLine();
            }
            }          

    }
}
