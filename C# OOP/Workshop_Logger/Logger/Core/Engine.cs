using Logger.Contracts;
using Logger.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logger.Core
{
   public class Engine
    {
        private ILogger loggers;
        private ErrorFactory errorFactory;

        private Engine()
        {
            this.errorFactory = new ErrorFactory();
        }
        public Engine(ILogger logger)
            :this()
        {
            this.loggers = logger;
        }

        public void Run()
        {
            string command = Console.ReadLine();

            while (command !="END")
            {
                string[] errorArgs = command
                    .Split("|")
                    .ToArray();

                string level = errorArgs[0];
                string date = errorArgs[1];
                string message = errorArgs[2];

                IError error;

                try
                {
                    error = this.errorFactory.GetError(date, level, message);
                    this.loggers.Log(error);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                   
                }

               

                command = Console.ReadLine();
            }
            Console.WriteLine(this.loggers.ToString());
        }
    }
}
