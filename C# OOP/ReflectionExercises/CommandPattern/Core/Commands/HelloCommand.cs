﻿using CommandPattern.Core.Contracts;
using System;


namespace CommandPattern.Core.Commands
{
    public class HelloCommand : ICommand
    {
        public string Execute(string[] args)
        {
            return $"Hello, {args [0]}";
        }
    }
}
