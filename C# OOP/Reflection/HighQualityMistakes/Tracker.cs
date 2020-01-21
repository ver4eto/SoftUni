﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace HighQualityMistakes
{
    public class Tracker
    {

        public Tracker()
        {

        }
        public void PrintMethodsByAuthor()
        {

            var type = typeof(StartUp);
            var methods =
              type.GetMethods(
                BindingFlags.Instance | BindingFlags.Public |
                BindingFlags.Static);

            foreach (var method in methods)
            {
                if (method.CustomAttributes.Any(n => n.AttributeType == typeof(AuthorAttribute)))
                {
                    var attributes = method.GetCustomAttributes(false);
                    foreach (AuthorAttribute attr in attributes)
                    {
                        Console.WriteLine("{0} iw written by {1}", method.Name, attr.Name);


                    }
                }
            }
        }
    }
}
