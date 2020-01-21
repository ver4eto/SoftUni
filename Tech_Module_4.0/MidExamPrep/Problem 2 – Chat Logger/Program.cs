using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2___Chat_Logger
{
    class Program
    {
        static void Main(string[] args)
        {

            string command = Console.ReadLine();
            List<string> chatMessages = new List<string>();

            while (command !="end")
            {
                string[] tokens = command
                    .Split()
                    .ToArray();

                string action = tokens[0];
                string message = tokens[1];

                switch (action)
                {
                    case "Chat":
                        chatMessages.Add(message);
                        break;
                    case "Delete":
                        if (chatMessages.Contains(message))
                        {
                            int index = chatMessages.IndexOf(message);
                            chatMessages.RemoveAt(index);
                        }
                        break;
                    case "Edit":
                        int indexForUpdate = chatMessages.IndexOf(message);
                        string updatedMessage = tokens[2];
                        chatMessages.RemoveAt(indexForUpdate);
                        chatMessages.Insert(indexForUpdate, updatedMessage);
                        break;
                    case "Pin":
                     int indexForPin=chatMessages.IndexOf(message);
                        chatMessages.RemoveAt(indexForPin);
                        chatMessages.Add(message);
                        break;
                    case "Spam":
                        List<string> spanMessage = new List<string>();
                        for (int i = 1; i < tokens.Length; i++)
                        {
                            spanMessage.Add(tokens[i]);
                        }
                        
                        chatMessages.AddRange(spanMessage);
                        break;
                        
                    default:
                        break;
                }
                command = Console.ReadLine();
            }
            foreach (var message in chatMessages)
            {
                Console.WriteLine(message);
            }
        }
    }
}
