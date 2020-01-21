using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Text;

namespace _02._Song_Encryption
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> bandsAndSomgs = new Dictionary<string, string>();
            string input = Console.ReadLine();
            StringBuilder encrypted = new StringBuilder();
            while (input!="end")
            {
                string[] data = input
               .Split(':')
               .ToArray();

                string bandName = data[0];
                string song = data[1];
                string groupPattern = @"(?<group>(?<=\s|^)[A-Z]{1}[a-z|\s|']+)(,|\z)";
                string songPattern = @"\b[A-Z][A-Z|\s]+\b";
               

                Regex regex = new Regex(groupPattern);
                Regex songRegex = new Regex(songPattern);
                if (regex.IsMatch(bandName)&&songRegex.IsMatch(song))
                {
                    
                    int key = bandName.Length;
                    for (int i = 0; i < bandName.Length; i++)
                    {
                        int currentChar = bandName[i];
                        if (currentChar==32 || currentChar==39)
                        {
                            encrypted.Append((char)currentChar);
                            continue;
                        }
                       
                        int newChar = currentChar + key;
                        if (newChar>122)
                        {
                            newChar -= 122;
                            newChar = 96+ (newChar);
                        }
                        else
                        {
                            newChar = currentChar + key;
                        }
                        
                        encrypted.Append((char)newChar);
                    }
                    encrypted.Append("@");
                    for (int i = 0; i < song.Length; i++)
                    {
                        int currentChar = song[i];
                        if (currentChar == 32 || currentChar == 39 )
                        {
                            encrypted.Append((char)currentChar);
                            continue;
                        }
                        int newChar = currentChar + key;
                        if (newChar > 90)
                        {
                            newChar -= 90;
                            newChar = 64 + newChar;
                        }
                        
                        encrypted.Append((char)newChar);
                    }
                    Console.WriteLine($"Successful encryption: {encrypted}");
                    encrypted = new StringBuilder();
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
                input = Console.ReadLine();
            }
           
        }
    }
}
