using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string COMMAND_POSTFIX = "Command";
        public string Read(string input)
        {
            string[] tokens = input
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string command = tokens[0]+ COMMAND_POSTFIX;

            string[] commandArgs = tokens
                .Skip(1)
                .ToArray();

            Assembly assembly = Assembly.GetCallingAssembly();

            Type[] types = assembly.GetTypes();

            Type typeToCreate = types.FirstOrDefault(t => t.Name == command);

            if (typeToCreate==null)
            {
                throw new InvalidOperationException("Invalid command Type");
            }

            Object instance = Activator.CreateInstance(typeToCreate);

            ICommand finalCommand = (ICommand)instance;

            string result = finalCommand.Execute(commandArgs);

            return result;
        }
    }
}
