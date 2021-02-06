using HabboBot.Connection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HabboBot
{
    public partial class Form1 : Form
    {
        public static List<HConnection> connections = new List<HConnection>();
        public static bool proxyStatus = false;
        public static bool walkRandom = false;
        Proxy _proxy;

        public Form1()
        {
            _proxy = new Proxy(this);
            InitializeComponent();
        }
        #region buttons
        private void buttonIntercept_Click(object sender, EventArgs e)
        {
            buttonIntercept.Text = (proxyStatus ? "Interceptar" : "Parar de interceptar");
            proxyStatus = !proxyStatus;
            if (proxyStatus)
                _proxy.Start();

            else
                _proxy.Stop();
        }


        private void walkRandomButton_Click(object sender, EventArgs e)
        {
            walkRandomButton.Text = (walkRandom ? "Andar Aleatório" : "Parar");
            walkRandom = !walkRandom;
            if (walkRandom)
            {
                foreach (var connection in connections)
                {
                    connection.WalkRandomButtom();
                };
            }

            else
            {
                foreach (var connection in connections)
                {
                    connection.CancelWalkRandom();
                };
            }
        }

        private void buttonRoom_Click(object sender, EventArgs e)
        {
            string idString = textBoxRoomId.Text;
            foreach (var connection in connections)
            {
                bool flag = Int32.TryParse(idString, out int idInt);
                if (flag)
                    connection.LoadRoom(idInt);
            };
        }

        private void buttonShout_Click(object sender, EventArgs e)
        {
            string message = textBoxShout.Text;
            if (textBoxShout.Text != null)
            {
                foreach (var connection in connections)
                {
                    connection.Shout(message);
                };
            }

        }

        private void buttonRespect_Click(object sender, EventArgs e)
        {
            string idString = textBoxRespect.Text;
            foreach (var connection in connections)
            {
                bool flag = Int32.TryParse(idString, out int idInt);
                if (flag)
                    connection.GiveRespect(idInt);
            };
        }

        private void buttonFriendRequest_Click(object sender, EventArgs e)
        {
            string name = textBoxFriendRequest.Text;
            if (textBoxFriendRequest.Text != null)
            {
                foreach (var connection in connections)
                {
                    connection.FriendRequest(name);
                };
            }
        }
        private void danceButton_Click(object sender, EventArgs e)
        {
            foreach (var connection in connections)
            {
                connection.Dance();
            };
        }
        #endregion
        #region topMost
        private void checkBoxTopMost_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTopMost.Checked)
                TopMost = true;
            else
                TopMost = false;
        }
        #endregion
        #region logger
        public void LogBox(string text)
        {
            richTextBox1.ScrollToCaret();
            richTextBox1.AppendText(text + Environment.NewLine);
        }
        public void LogBox(ushort header, string text)
        {
            richTextBox1.ScrollToCaret();
            richTextBox1.AppendText(header + " ---> " + text + Environment.NewLine);
        }
        #endregion
        #region form load/closing
        void CertificateHandler()
        {
            if (!Proxy.HasInstalledCertificate())
                Proxy.InstallCertificate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            HHeaders.LoadHeaders();
            CertificateHandler();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (proxyStatus)
                _proxy.Stop();
        }
        #endregion
        #region botCount
        public static void BotCount(int _botCount)
        {
            labelBotCount.Text = _botCount.ToString();
        }
        #endregion
    }
}
