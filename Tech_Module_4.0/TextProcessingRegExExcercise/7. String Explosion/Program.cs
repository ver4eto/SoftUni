using System;
using System.Text;

namespace _7._String_Explosion
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int explosions = 0;
            bool hasExplosition = false;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i]=='>')
                {
                    hasExplosition = true;
                    explosions+= int.Parse(input[i+1].ToString());
                    continue;
                }
                if (hasExplosition&&explosions>0)
                {                   
                    input = input.Remove(i,1);
                    explosions--;
                    i--;
                    if (explosions==0)
                    {
                        hasExplosition = false;
                    }
                }
            }
            Console.WriteLine(input);
        }
    }
}
