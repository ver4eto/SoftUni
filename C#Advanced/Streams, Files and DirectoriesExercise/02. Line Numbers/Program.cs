using System;
using System.IO;
using System.Linq;

namespace _02._Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string textPath = @"text.txt";
            string outputPath = @"output.txt";

            string [] allTextLines = File.ReadAllLines(textPath);


            int lineCounter = 1;

            foreach (var currentLine in allTextLines)
            {
                int lettersCount = currentLine.Count( char.IsLetter);
                int punctuationCount = currentLine.Count(char.IsPunctuation);

            
                File.AppendAllText(outputPath, $"Line {lineCounter}: {currentLine} ({lettersCount})({punctuationCount}) {Environment.NewLine}");
                lineCounter++;
              
            }

        }
    }
}
