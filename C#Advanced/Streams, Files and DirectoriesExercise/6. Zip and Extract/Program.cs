using System;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace _6._Zip_and_Extract
{
    class Program
    {
        static void Main(string[] args)
        {
            string picture = @"copyMe.png";
            string folderPicture = @".";
            string targetPath = @"../../../result.zip";

            ZipFile.CreateFromDirectory(folderPicture, targetPath);
            
            //var zipFile = @"..\..\..\myZip.zip";
            //using (var archive=ZipFile.Open(zipFile,ZipArchiveMode.Create))
            //{
            //    archive.CreateEntryFromFile(picture,Path.GetFileName(picture));
            //}
            ZipFile.ExtractToDirectory(targetPath, @"../../");
        }
    }
}
