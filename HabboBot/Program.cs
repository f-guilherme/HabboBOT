using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using HabboBot.Connection;
using System.Windows.Forms;

namespace HabboBot
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}