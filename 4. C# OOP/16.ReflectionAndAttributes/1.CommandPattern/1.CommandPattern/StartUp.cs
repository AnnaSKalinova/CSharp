﻿using CommandPattern.Core;
using CommandPattern.Core.Contracts;
using System;

namespace CommandPattern
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            ICommandInterpreter command = new CommandInterpreter();
            IEngine engine = new Engine(command);
            engine.Run();

            ICommandInterpreter ci = new CommandInterpreter();
            ci.Read(Console.ReadLine());
        }
    }
}
 