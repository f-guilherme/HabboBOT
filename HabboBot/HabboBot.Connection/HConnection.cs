using System;

using Sulakore.Crypto;
using Sulakore.Protocol;
using Sulakore.Communication;

using HabboBot;

namespace HabboBot.Connection
{
    public class HConnection
    {
        private readonly HKeyExchange keyExchange;
        private HNode hnode;
        private RC4 rc4;
        private readonly Random random = new Random();

        private readonly string sso;
        private readonly string id;

        private readonly int exponent = 65537;
        private readonly string modulus =
            "bd214e4f036d35b75fee36000f24ebbef15d56614756d7afbd4d186ef5445f758b284647feb773927418ef70b95387b80b961ea56d8441d410440e3d3295539a3e86e7707609a274c02614cc2c7df7d7720068f072e098744afe68485c6297893f3d2ba3d7aaaaf7fa8ebf5d7af0ba2d42e0d565b89d332de4cf898d666096ce61698de0fab03a8a5e12430cb427c97194cbd221843d162c9f3acf74da1d80ebc37fde442b68a0814dfea3989fdf8129c120a8418248d7ee85d0b79fa818422e496d6fa7b5bd5db77e588f8400cda1a8d82efed6c86b434bafa6d07dfcc459d35d773f8dfaf523dfed8fca45908d0f9ed0d4bceac3743af39f11310eaf3dff45";

        public HConnection(string ssoTicket)
        {
            keyExchange = new HKeyExchange(exponent, modulus);
            id = HId.GenerateId();
            sso = ssoTicket;
        }

        public async void Start()
        {
            hnode = new HNode();

            await hnode.ConnectAsync("game-br.habbo.com", 30000);
            if (!hnode.IsConnected)
                return;

            CLILogger.LogInformation($"[{sso}] The connection was started!");

            await hnode.SendPacketAsync(4000, HHeaders.ReleaseVersion, "FLASH", 1, 0);
            await hnode.SendPacketAsync(HHeaders.InitCrypto);

            ConnectionHandler(await hnode.ReceivePacketAsync());
        }

        private async void ConnectionHandler(HMessage hmessage)
        {
            try
            {
                HMessage packet = hmessage;
                if (packet.Header == HHeaders.Ping)
                    SendPacket(HMessage.Construct(HHeaders.Pong));

                else if (packet.Header == HHeaders.VerifyPrimes)
                    GetPublicKey(packet);
                else if (packet.Header == HHeaders.GenerateSecretKeyIn)
                    ConnectionPackets(packet);
                else if (packet.Header == HHeaders.SecureLoginOK)
                {
                    CLILogger.LogSuccess($"[{sso}] Account connected!");
                    Console.Title = $"HabboBot - Connected BOTs: {Program.connections.Count} - Proxy Enabled: {Program.proxyStatus}";
                }

                ConnectionHandler(await hnode.ReceivePacketAsync());
            }
            catch
            {
                CLILogger.LogError($"[{sso}] Account disconnected!");
                Program.connections.Remove(this);
                Console.Title = $"HabboBot - Connected BOTs: {Program.connections.Count} - Proxy Enabled: {Program.proxyStatus}";
            }
        }

        #region Packets
        private async void ConnectionPackets(HMessage packet)
        {
            rc4 = new RC4(keyExchange.GetSharedKey(packet.ReadString()));
            await hnode.SendAsync(rc4.Parse(HMessage.Construct(HHeaders.ClientVariables, 401, HHeaders.ClientVariables2, HHeaders.ClientVariables1)));
            await hnode.SendAsync(rc4.Parse(HMessage.Construct(HHeaders.MachineID, "", id, "WIN/32,0,0,238")));
            await hnode.SendAsync(rc4.Parse(HMessage.Construct(HHeaders.SSOTicket, sso, random.Next(1000, 10600))));
            await hnode.SendAsync(rc4.Parse(HMessage.Construct(HHeaders.RequestUserData)));
        }

        private async void GetPublicKey(HMessage packet)
        {
            keyExchange.VerifyDHPrimes(packet.ReadString(), packet.ReadString());
            keyExchange.Padding = PKCSPadding.RandomByte;

            await hnode.SendAsync(HMessage.Construct(HHeaders.GenerateSecretKeyOut, keyExchange.GetPublicKey()));
        }

        private async void SendPacket(byte[] data)
        {
            if (rc4 != null)
                rc4.RefParse(data);
            await hnode.SendAsync(data);
        }
        #endregion

        public void LoadRoom(int roomId = 0)
        {
            SendPacket(HMessage.Construct(HHeaders.RequestRoomLoad, roomId, "", -1));
        }

        public void Walk(int coordX, int coordY)
        {
            SendPacket(HMessage.Construct(HHeaders.RoomUserWalk, coordX, coordY));
        }

        public void ChangeLook(string lookString)
        {                                                       //F
            SendPacket(HMessage.Construct(HHeaders.UserSaveLook, "M", lookString));
        }

        public void Shout(string message)
        {
            SendPacket(HMessage.Construct(HHeaders.RoomUserShout, message, 0, 0));
        }
    }
}