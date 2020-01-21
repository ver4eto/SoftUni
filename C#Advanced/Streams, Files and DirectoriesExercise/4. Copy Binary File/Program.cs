using System;
using System.IO;

namespace _4._Copy_Binary_File
{
    class Program
    {
        static void Main(string[] args)
        {
            string picturePath = @"copyMe.png";
            string copyPicturePath = @"copyMe-copy.png";

            using (FileStream streamReader = new FileStream(picturePath, FileMode.Open))
            {
                using (FileStream streamWritter=new FileStream(copyPicturePath,FileMode.Create))
                {

                    while (true)
                    {
                        byte[] byteArray = new byte[4096];

                        int size = streamReader.Read(byteArray, 0, byteArray.Length);
                        if (size==0)
                        {
                            break;
                        }
                        streamWritter.Write(byteArray, 0, size);
                    }
                    
                }

                
            }
        }
    }
}
