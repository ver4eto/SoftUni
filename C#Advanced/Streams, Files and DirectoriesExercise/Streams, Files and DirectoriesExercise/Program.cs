using System;
namespace Streams__Files_and_DirectoriesExercise
{
    using System.IO;
    using System.Linq;
    using System.Text;

    class Program
    {
        static void Main(string[] args)
        {
            string textFilePath = @"text.txt";

            int counter = 0;
            using (StreamReader myStreamReader = new StreamReader(textFilePath))
            {
                while (true)
                {
                    string currentLine = myStreamReader.ReadLine();

                    if (counter %2==0)
                    {
                        string replaceSymbols = ReplaceSymbols(currentLine);
                        string reverseWord = ReverseWord(replaceSymbols);
                        Console.WriteLine(reverseWord);
                    }
                                       
                    counter++;

                    if (currentLine == null)
                    {
                        break;
                    }
                }
            }
            

        }

        private static string ReverseWord(string replacedSymbols)
        {

            return string.Join(" ", replacedSymbols.Split().Reverse());
           
        }

        private static string ReplaceSymbols(string currentLine)
        {
            return currentLine.Replace(oldValue: "-", newValue: "@")
                 .Replace(oldValue: ",", newValue: "@")
                 .Replace(oldValue: ".", newValue: "@")
                .Replace(oldValue: "!", newValue: "@")
                .Replace(oldValue: "?", newValue: "@");
        }
    }
}
