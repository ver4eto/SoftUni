using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _3._Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string wordsFilePath = @"words.txt";

            string textFilePath = @"text.txt";

            string[] words = File.ReadAllLines(wordsFilePath);
            string [] wordsFromTextFile = File.ReadAllLines(textFilePath);
            Dictionary<string, int> wordsCount = new Dictionary<string, int>();


            foreach (var item in words)
            {
                string itemLower = item.ToLower();
                if (!wordsCount.ContainsKey(itemLower))
                {
                    wordsCount.Add(itemLower, 0);
                }              
            }
            
            foreach (var currentLine in wordsFromTextFile)
            {
                string[] wordsInCurrLine = currentLine
                    .Split(new char[] { ',', ' ', '-', '?', '!', '.', '\\', ':', ';' });

                foreach (var currentWord in wordsInCurrLine)
                {
                    string currentWordToLower = currentWord.ToLower();
                    if (wordsCount.ContainsKey(currentWordToLower))
                    {
                        wordsCount[currentWordToLower]++;
                    }
                }
                  
            }

            string actualResultPath = @"actualResult.txt";

            foreach (var word in wordsCount)
            {
                File.AppendAllText(actualResultPath,($"{word.Key} - {word.Value}{ Environment.NewLine}" ));
            }

            string expectedlResultPath = @"expectedResult.txt";

            foreach (var word in wordsCount.OrderByDescending(x=>x.Value))
            {
                File.AppendAllText(expectedlResultPath, ($"{word.Key} - {word.Value}{ Environment.NewLine}"));
            }

        }
    }
}
