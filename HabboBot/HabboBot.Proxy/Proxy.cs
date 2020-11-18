using Fiddler;

using HabboBot.Connection;

namespace HabboBot
{
    public static class Proxy
    {
        public static void Start()
        {
            FiddlerApplication.AfterSessionComplete += FiddlerApplication_AfterSessionComplete;
            FiddlerApplication.Startup(9090, true, true, true);
        }

        public static void Stop()
        {
            FiddlerApplication.AfterSessionComplete -= FiddlerApplication_AfterSessionComplete;
            if (!FiddlerApplication.IsStarted())
                return;
            FiddlerApplication.Shutdown();
        }

        private static void FiddlerApplication_AfterSessionComplete(Session sess)
        {
            try
            {
                if (sess.GetResponseBodyAsString().Contains("clienturl"))
                {
                    string sso = sess.GetResponseBodyAsString().Split('"')[3].Split('/')[5];
                    HConnection connection = new HConnection(sso);
                    connection.Start();

                    Program.connections.Add(connection);
                }
            }
            catch { }
        }

        public static bool HasInstalledCertificate()
        {
            return CertMaker.trustRootCert();
        }

        public static void InstallCertificate()
        {
            CertMaker.createRootCert();
            CertMaker.trustRootCert();
        }
    }
}