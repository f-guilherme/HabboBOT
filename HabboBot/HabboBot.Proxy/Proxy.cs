using Fiddler;

using HabboBot.Connection;
using System.Text;

namespace HabboBot
{
    public class Proxy
    {
        Form1 form;
        public Proxy(Form1 form)
        {
            this.form = form;
        }
        public void Start()
        {
            form.LogBox("Interceptando conexão...");
            FiddlerApplication.AfterSessionComplete += FiddlerApplication_AfterSessionComplete;
            FiddlerApplication.Startup(9090, true, true, true);
        }

        public void Stop()
        {
            form.LogBox("Interrompendo interceptação de conexão.");
            FiddlerApplication.AfterSessionComplete -= FiddlerApplication_AfterSessionComplete;
            if (!FiddlerApplication.IsStarted())
                return;
            FiddlerApplication.Shutdown();
        }

        private void FiddlerApplication_AfterSessionComplete(Session sess)
        {
            try
            {
                Encoding encoding = sess.GetResponseBodyEncoding();
                form.LogBox(encoding.EncodingName);
                form.LogBox(sess.GetResponseBodyAsString());
                if (sess.GetResponseBodyAsString().Contains("clienturl"))
                {
                    string sso = sess.GetResponseBodyAsString().Split('"')[3].Split('/')[5];
                    HConnection connection = new HConnection(sso, form);
                    form.LogBox("Interceptando conta...");
                    connection.Start();
                    Form1.connections.Add(connection);
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