using System;
using System.IO;

namespace Streams__Files_and_Directories
{
    class Program
    {
        static void Main(string[] args)
        {

            //string filePath = "files" + Path.PathSeparator + "input.txt";
            string path = "files";
            string outputFile = "output.txt";
            string fileName = "input.txt";
            string filePath = Path.Combine(path, fileName);

            using (var reader = new StreamReader(filePath))
            {
                int count = 0;

                string line = reader.ReadLine();


                using (var writer = new StreamWriter(Path.Combine(path, outputFile)))
                {
                    while (line != null)
                    {
                        
                        line = $"{++count}. {line}";
                        Console.WriteLine(line);
                        writer.WriteLine(line);


                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
