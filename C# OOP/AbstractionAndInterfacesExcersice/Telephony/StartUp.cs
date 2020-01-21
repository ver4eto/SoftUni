using System;

namespace Telephony
{
   public class StartUp
    {
        static void Main(string[] args)
        {

                string[] numbers = Console.ReadLine().Split();

                Smartphone smartphone = new Smartphone();
           
                foreach (var number in numbers)
                {
                try
                {
                    smartphone.CallingOtherPhones(number);
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }

                   
                }
           
                

                string[] URLs = Console.ReadLine().Split();

           
                foreach (var url in URLs)
                {
                try
                {
                    smartphone.Browsing(url);
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
                    
                }
           
                
            
            //catch (Exception ex)
            //{

            //    Console.WriteLine(ex.Message);
            //}
            
        }
    }
}
