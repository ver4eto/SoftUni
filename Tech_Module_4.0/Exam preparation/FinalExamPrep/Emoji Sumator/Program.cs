using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace Emoji_Sumator
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            string input = Console.ReadLine();
            string pattern = @"(?<= )(?<emoji>:[a-z]{4,}:)(?= |,|\.|!|\?)";
            List<string> emojies = new List<string>();
            bool isCorresponding = false;

            int[] charInput = Console.ReadLine().Split(':').Select(int.Parse).ToArray();
            StringBuilder emojiFromNumbers = new StringBuilder();

            for (int i = 0; i < charInput.Length; i++)
            {
                emojiFromNumbers.Append((char)charInput[i]);
            }
            //Console.WriteLine(emojiFromNumbers);

            MatchCollection matches = Regex.Matches(input,pattern);

            foreach (Match match in matches)
            {
                string currentEmoji = match.Groups["emoji"].Value;
                emojies.Add(currentEmoji);
                string isMatchingEmojiNum = string.Empty;
                for (int i = 1; i < currentEmoji.Length-1; i++)
                {
                    sum += currentEmoji[i];
                    isMatchingEmojiNum += currentEmoji[i];
                }
                if (isMatchingEmojiNum==emojiFromNumbers.ToString())
                {
                    isCorresponding = true;
                }
            }
            
            if (isCorresponding)
            {
                sum *= 2;
            }

            if (emojies.Count>0)
            {
                Console.WriteLine($"Emojis found: {string.Join(", ", emojies)}");
            }
           
            Console.WriteLine($"Total Emoji Power: {sum}");
        }
    }
}
