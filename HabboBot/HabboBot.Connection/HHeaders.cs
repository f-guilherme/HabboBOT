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
        public static ushort RequestRoomData;
        public static ushort TrackingData;
        public static ushort RequestRoomHeightMap;
        public static ushort RequestCameraConfiguration;
        public static ushort RoomUserSign;
        
        public static ushort RoomUserShout;
        public static ushort RequestHeighMap;
        public static ushort RoomUserWalk;
        public static ushort UserSaveLook;
        public static ushort RoomUserGiveRespect;
        public static ushort FriendRequest;
        public static ushort RoomUserDance;

        public static ushort InRoomData;
        public static ushort InRoomUserTalk;
        public static ushort InRoomUserShout;
        public static ushort InRoomUserStatus;

        public static ushort InRoomUsers;
        public static ushort InRoomUserRemove;
        public static ushort InRoomHeightMap;

        public static string ClientVariables1;
        public static string ClientVariables2;
        public static string ReleaseVersion;

        public static void LoadHeaders()
        {
            if (File.Exists("Habbo.swf"))
            {
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
                RequestRoomData = hgame.GetMessageHeaders("feb59c7edb15bba39d83589298e30b66").FirstOrDefault();
                TrackingData = hgame.GetMessageHeaders("3ee5fd5dfa15f86da55b41e9f8eba22e").FirstOrDefault();
                RequestRoomHeightMap = hgame.GetMessageHeaders("5b6d052cfe213e0168f39e7a3bb792e3").FirstOrDefault();
                InRoomData = hgame.GetMessageHeaders("2c3b2b740f074b2971b4a5a8234cd8c5").FirstOrDefault();


                RequestHeighMap = hgame.GetMessageHeaders("5b6d052cfe213e0168f39e7a3bb792e3").FirstOrDefault();
                RoomUserShout = hgame.GetMessageHeaders("68d1be9ce25f2d1173a95b74a2175c6b").FirstOrDefault();
                RoomUserWalk = hgame.GetMessageHeaders("f76a21e6be54cea897c44fbfc7c32839").FirstOrDefault();
                UserSaveLook = hgame.GetMessageHeaders("1f03ea2553d1f3a013c2d9aa30afaa8a").FirstOrDefault();
                RoomUserGiveRespect = hgame.GetMessageHeaders("f14ff14415b3711f8d25def98e35c61d").FirstOrDefault();
                FriendRequest = hgame.GetMessageHeaders("9580a99eab161b15191ca50fbddeb750").FirstOrDefault();
                InRoomUserTalk = hgame.GetMessageHeaders("f9fded0fea632758324e629ea60a3f87").FirstOrDefault();
                InRoomUsers = hgame.GetMessageHeaders("84c6b9e56653d64d21cd8cf47c4242f1").FirstOrDefault();
                InRoomUserRemove = hgame.GetMessageHeaders("3c41c27886b935d66ed6c320160e389a").FirstOrDefault();
                InRoomHeightMap = hgame.GetMessageHeaders("f6389132439429010a2ebcd7fe59f8e8").FirstOrDefault();
                InRoomUserStatus = hgame.GetMessageHeaders("1d1cb11cb8d5156afeb284fb1eb04339").FirstOrDefault();
                RequestCameraConfiguration = hgame.GetMessageHeaders("cdee8ac8f9388e9b28318e6b89a446c2").FirstOrDefault();
                RoomUserDance = hgame.GetMessageHeaders("527fb818a6546ad4f63264f257ea58d4").FirstOrDefault();
                RoomUserSign = hgame.GetMessageHeaders("301410b5a331b26dd8653f9894afa87f").FirstOrDefault();
                InRoomUserShout = hgame.GetMessageHeaders("a9665763d1016f536e75d8d9366a496f").FirstOrDefault();
            }
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