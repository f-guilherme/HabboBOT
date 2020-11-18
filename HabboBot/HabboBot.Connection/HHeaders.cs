using System;
using System.IO;
using System.Net;
using System.Linq;

using Sulakore.Habbo;
using System.Threading.Tasks;

namespace HabboBot.Connection
{
    public static class HHeaders
    {
        public static ushort ClientVariables;
        public static ushort InitCrypto;
        public static ushort MachineID;
        public static ushort GenerateSecretKeyOut;
        public static ushort RequestUserData;
        public static ushort SSOTicket;
        public static ushort GenerateSecretKeyIn;
        public static ushort VerifyPrimes;

        public static ushort SecureLoginOK;

        public static ushort Pong;
        public static ushort Ping;
        public static ushort RequestRoomLoad;
        public static ushort RoomUserShout;
        public static ushort RequestHeighMap;
        public static ushort RoomUserWalk;
        public static ushort UserSaveLook;

        public static string ClientVariables1;
        public static string ClientVariables2;
        public static string ReleaseVersion;

        public static void LoadHeaders()
        {
            if (!File.Exists("Habbo.swf"))
            {
                Console.WriteLine($"[{DateTime.Now}] \"Habbo.swf\" was not found!");
                Task.Delay(2000);
                Environment.Exit(0);
            }

            var hgame = new HGame("Habbo.swf");
            hgame.Disassemble(true);
            ReleaseVersion = hgame.Revision;

            ClientVariables1 = GetExternalVariables();
            ClientVariables2 = string.Format("https://images.habbo.com/gordon/{0}/", ReleaseVersion);

            Pong = hgame.GetMessageHeaders("3a50ddfa7e72170e7097162580624b13").FirstOrDefault();
            Ping = hgame.GetMessageHeaders("5066be53f1b24abd1cf48a5b11237afa").FirstOrDefault();

            GenerateSecretKeyOut = hgame.GetMessageHeaders("742fe953c0579b43ce7837b89644a804").FirstOrDefault();
            GenerateSecretKeyIn = hgame.GetMessageHeaders("85fe9c6d60accb4e422dc09f5e1b3bb4").FirstOrDefault();
            VerifyPrimes = hgame.GetMessageHeaders("c1a50247db0c525bcdf5fb85a6ccf755").FirstOrDefault();
            InitCrypto = hgame.GetMessageHeaders("7946a7370f7929a1388c02b677ffe239").FirstOrDefault();
            MachineID = hgame.GetMessageHeaders("62516164cd12fc9b8412d798066e77dd").FirstOrDefault();

            SecureLoginOK = hgame.GetMessageHeaders("0f6440a57c3e726482d0828d359d6e11").FirstOrDefault();

            ClientVariables = hgame.GetMessageHeaders("24f7f5ded037cc98bd9fc6d263b8aae3").FirstOrDefault();
            RequestUserData = hgame.GetMessageHeaders("176fb2a1d3f3878b9b125e145756f57c").FirstOrDefault();
            SSOTicket = hgame.GetMessageHeaders("f190cdc97eea13b1c4e37e4ca38c011b").FirstOrDefault();

            RequestRoomLoad = hgame.GetMessageHeaders("a3dff45a9b34340ef771bab82cbeaed6").FirstOrDefault();
            RequestHeighMap = hgame.GetMessageHeaders("5b6d052cfe213e0168f39e7a3bb792e3").FirstOrDefault();
            RoomUserShout = hgame.GetMessageHeaders("68d1be9ce25f2d1173a95b74a2175c6b").FirstOrDefault();
            RoomUserWalk = hgame.GetMessageHeaders("f76a21e6be54cea897c44fbfc7c32839").FirstOrDefault();
            UserSaveLook = hgame.GetMessageHeaders("1f03ea2553d1f3a013c2d9aa30afaa8a").FirstOrDefault();
        }

        public static string GetExternalVariables()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.habbo.com.br/gamedata/external_variables/1");
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/71.0.3578.80 Safari/537.36";
            request.AllowAutoRedirect = false;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            return response.Headers["Location"];
        }
    }
}