// 18/11/2020 //

// Credits: Moch
// Discord: Moch#2477
// www.youtube.com/channel/UCTEdYQGckSYIy7080OJaRFw
// Enjoy!

using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using HabboBot.Connection;

namespace HabboBot
{
    class Program
    {
        static void Main() => new Program().Run();

        public static bool proxyStatus = false;
        public static List<HConnection> connections = new List<HConnection>();

        void Run()
        {
            Console.Title = "HabboBot - Connected BOTs: 0 - Proxy Enabled: False";
            CLILogger.LogInformation("Loading Headers...");
            HHeaders.LoadHeaders();
            CertificateHandler();

            CLILogger.Moch();

            CommandHandler();
        }

        void CommandHandler()
        {
            Console.Clear();
            CLILogger.Moch();
            CLILogger.LogAction("Type number of the feature you want to use: ");
            Console.WriteLine("[01] => Load a Room");
            Console.WriteLine("[02] => Walk");
            Console.WriteLine("[03] => Change Look");
            Console.WriteLine("[04] => Shout");
            Console.WriteLine("[05] => Enable/Disable proxy");

            int value = int.Parse(Console.ReadLine());
            switch (value)
            {
                case 01:
                    Parallel.ForEach(connections, connection =>
                    {
                        CLILogger.LogInformation("Type a room id and press enter: ");
                        connection.LoadRoom(int.Parse(Console.ReadLine()));
                    });
                    break;
                case 02:
                    Parallel.ForEach(connections, connection =>
                    {
                        CLILogger.LogInformation("Type the coordinates X and Y. example: 05/18");
                        string values = Console.ReadLine();
                        if (values.Split('/')[1] != null)
                            connection.Walk(int.Parse(values.Split('/')[0]), int.Parse(values.Split('/')[1]));
                    });
                    break;
                case 03:
                    Parallel.ForEach(connections, connection =>
                    {
                        CLILogger.LogInformation("Type a look string and press enter: ");
                        connection.ChangeLook(Console.ReadLine());
                    });
                    break;
                case 04:
                    Parallel.ForEach(connections, connection =>
                    {
                        CLILogger.LogInformation("Type a message and press enter: ");
                        connection.Shout(Console.ReadLine());
                    });
                    break;
                case 05:
                    proxyStatus = !proxyStatus;
                    if (proxyStatus) Proxy.Start();
                    else Proxy.Stop();
                    Console.Title = $"HabboBot - Connected BOTs: {connections.Count} - Proxy Enabled: {proxyStatus}";
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Unknown value");

            }
            CommandHandler();
        }

        void CertificateHandler()
        {
            if (!Proxy.HasInstalledCertificate())
                Proxy.InstallCertificate();
        }
    }
}
