using Logger.Contracts;
using Logger.Core;
using Logger.Factories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logger
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            int appendersCounts = int.Parse(Console.ReadLine());

            ICollection<IAppender> appenders = new List<IAppender>();

            AppenderFactory appenderFactory = new AppenderFactory();

            ILogger logger = new Models.Logger(appenders);
            ReadAppendersData(appendersCounts, appenders, appenderFactory);

            Engine engine = new Engine(logger);
            engine.Run();
        }

        private static void ReadAppendersData(int appendersCounts, ICollection<IAppender> appenders, AppenderFactory appenderFactory)
        {
            for (int i = 0; i < appendersCounts; i++)
            {
                string[] appendersInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string appenderType = appendersInfo[0];
                string layoutType = appendersInfo[1];
                string levelString = "INFO";

                if (appendersInfo.Length == 3)
                {
                    levelString = appendersInfo[2];
                }

                                
                try
                {
                   IAppender appender = appenderFactory.GetAppender(appenderType, layoutType, levelString);
                    appenders.Add(appender);
                }
                catch (Exception e )
                {
                    //output needed?
                    Console.WriteLine(e.Message);
                    continue;
                }

               
            }

        }
    }
}
