using System;
using Sulakore.Crypto;
using Sulakore.Protocol;
using Sulakore.Communication;
using Sulakore.Habbo;
using HabboBot;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace HabboBot.Connection
{
    public class HConnection
    {
        private readonly Random random = new Random();
        private readonly Random random_ = new Random();

        private readonly HKeyExchange keyExchange;
        readonly Form1 form;
        private HNode hnode;
        private RC4 rc4;

        CancellationTokenSource cancellationTokenSource = null;

        private readonly string sso;
        private readonly string id;

        public static int _botCount = 0;


        private readonly int exponent = 65537;
        private readonly string modulus =
            "bd214e4f036d35b75fee36000f24ebbef15d56614756d7afbd4d186ef5445f758b284647feb773927418ef70b95387b80b961ea56d8441d410440e3d3295539a3e86e7707609a274c02614cc2c7df7d7720068f072e098744afe68485c6297893f3d2ba3d7aaaaf7fa8ebf5d7af0ba2d42e0d565b89d332de4cf898d666096ce61698de0fab03a8a5e12430cb427c97194cbd221843d162c9f3acf74da1d80ebc37fde442b68a0814dfea3989fdf8129c120a8418248d7ee85d0b79fa818422e496d6fa7b5bd5db77e588f8400cda1a8d82efed6c86b434bafa6d07dfcc459d35d773f8dfaf523dfed8fca45908d0f9ed0d4bceac3743af39f11310eaf3dff45";



        public HConnection(string ssoTicket, Form1 form)
        {
            keyExchange = new HKeyExchange(exponent, modulus);
            id = HId.GenerateId();
            sso = ssoTicket;
            this.form = form;
        }


        public async void Start()
        {
            hnode = new HNode();

            await hnode.ConnectAsync("game-br.habbo.com", 30000);
            if (!hnode.IsConnected)
                return;

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
                    form.LogBox($"{sso} Conta conectada!");
                    _botCount++;
                    form.BotCount(_botCount);
                }

                ConnectionHandler(await hnode.ReceivePacketAsync());
            }
            catch
            {
                form.LogBox($"{sso} Conta desconectada.");
                Form1.connections.Remove(this);
                if (_botCount >= 1)
                {
                    _botCount--;
                    form.BotCount(_botCount);
                }
            }
        }

        #region Initial packets
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
        #region Misc packets
        public async void WalkRandomButtom()
        {
            cancellationTokenSource = new CancellationTokenSource();
            var _token = cancellationTokenSource.Token;
            await Task.Run(() => WalkRandom(_token));
        }

        public async void WalkRandom(CancellationToken token)
        {
            while (true)
            {
                SendPacket(HMessage.Construct(HHeaders.RoomUserWalk, random_.Next(1, 24), random_.Next(1, 24)));
                await Task.Delay(1024);
                if (token.IsCancellationRequested)
                    break;
            }
        }

        public void CancelWalkRandom()
        {
            cancellationTokenSource.Cancel();
        }

        public void ChangeLook(string look, string gender)
        {
            SendPacket(HMessage.Construct(HHeaders.UserSaveLook, gender, look));
        }
        public void Dance()
        {
            SendPacket(HMessage.Construct(HHeaders.RoomUserDance, 1));
        }

        public void Shout(string message)
        {
            SendPacket(HMessage.Construct(HHeaders.RoomUserShout, message, 0, 0));
        }

        public void GiveRespect(int id)
        {
            SendPacket(HMessage.Construct(HHeaders.RoomUserGiveRespect, id));
        }
        public void FriendRequest(string name)
        {
            SendPacket(HMessage.Construct(HHeaders.FriendRequest, name));
        }
        public void LoadRoom(int roomId = 0)
        {
            SendPacket(HMessage.Construct(HHeaders.RequestRoomLoad, roomId, "", -1));
        }
        #endregion
    }
}