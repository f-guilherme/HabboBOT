using System;

namespace HabboBot
{
    public static class CLILogger
    {
        public static void Moch()
        {
            string[] lines = new string[]
            {
                @" __  __            _       _______        _                 _             _           ",
                @"|  \/  |          | |     |__   __|      | |               | |           (_)          ",
                @"| \  / | ___   ___| |__      | | ___  ___| |__  _ __   ___ | | ___   __ _ _  ___  ___ ",
                @"| |\/| |/ _ \ / __| '_ \     | |/ _ \/ __| '_ \| '_ \ / _ \| |/ _ \ / _` | |/ _ \/ __|",
                @"| |  | | (_) | (__| | | |    | |  __/ (__| | | | | | | (_) | | (_) | (_| | |  __/\__ \",
                @"|_|  |_|\___/ \___|_| |_|    |_|\___|\___|_| |_|_| |_|\___/|_|\___/ \__, |_|\___||___/",
                @"                                                                     __/ |            ",
                @"                                                                    |___/             ",
                @"                              http://discord.gg/yjWM72b                               ",
                @"                                 Discord: Moch#2477                                   " + "\n",
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