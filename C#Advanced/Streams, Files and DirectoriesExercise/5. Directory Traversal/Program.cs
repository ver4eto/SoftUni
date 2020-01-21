using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace _5._Directory_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] files = Directory.GetFiles(".","*.*");
          
            Dictionary<string, Dictionary<string, double>> dirInfo = new Dictionary<string, Dictionary<string, double>>();

            DirectoryInfo directoryInfo = new DirectoryInfo(".");
            FileInfo[] allFiles = directoryInfo.GetFiles();

            foreach (var currFile in allFiles)
            {
                double size = currFile.Length / 1024d;
                string fileName = currFile.Name;
                string extension = currFile.Extension;

                if (!dirInfo.ContainsKey(extension))
                {
                    dirInfo.Add(extension, new Dictionary<string, double>());
                }
                if (!dirInfo[extension].ContainsKey(fileName))
                {
                    dirInfo[extension].Add(fileName, size);
                }
                
            }

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+@"/report.txt";

            var sortedDic = dirInfo.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key).ToDictionary(x => x.Key, y => y.Value);

            foreach (var item in sortedDic)
            {
               File.AppendAllText(path,item.Key+ Environment.NewLine);

                foreach (var file in item.Value.OrderBy(x=>x.Value))
                {
                    File.AppendAllText(path,$"--{file.Key} - {file.Value:f3}kb {Environment.NewLine}");
                }
            }
            

        }
    }
}
