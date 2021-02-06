﻿using System;

namespace HabboBot
{
    public static class CLILogger
    {
        public static void Moch()
        {
            string[] lines = new string[]
            {
                @" _    _       _     _           ____   ____ _______ ",
                @"| |  | |     | |   | |         |  _ \ / __ \__   __|",
                @"| |__| | __ _| |__ | |__   ___ | |_) | |  | | | |   ",
                @"|  __  |/ _` | '_ \| '_ \ / _ \|  _ <| |  | | | |   ",
                @"| |  | | (_| | |_) | |_) | (_) | |_) | |__| | | |   ",
                @"|_|  |_|\__,_|_.__/|_.__/ \___/|____/ \____/  |_|   ",
                @"              http://discord.gg/yjWM72b             ",
                @"              Discord: Moch#1555                    " + "\n",
            };
            foreach (var line in lines)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(line);
                Console.ResetColor();
            }
        }
        public static void LogSuccess(string log)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"[{DateTime.Now}] {log}");
            Console.ResetColor();
        }

        public static void LogInformation(string log)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"[{DateTime.Now}] {log}");
            Console.ResetColor();
        }

        public static void LogError(string log)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"[{DateTime.Now}] {log}");
            Console.ResetColor();
        }

        public static void LogAction(string log)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"[{DateTime.Now}] {log}");
            Console.ResetColor();
        }
    }
}
