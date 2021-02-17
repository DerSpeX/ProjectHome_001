using AltV.Net.Elements.Entities;
using ProjectHome_001.Database;
using System;

namespace ProjectHome_001.OwnEntities
{
    class OwnPlayer : Player
    {

        public bool IsLoggedIn { get; set; }
        public int Db_Id { get; set; }
        public string DisplayName { get; set; }
        public uint Cash { get; set; }

        public int Team { get; set; }

        public bool IsInRagdoll { get; set; }

        public OwnPlayer(IntPtr nativePointer, ushort id) : base(nativePointer, id)
        {
            IsLoggedIn = false;
            Cash = 500;
            SetTeam(0);
        }

        public void Login()
        {
            IsLoggedIn = true;
        }

        public void SendNotification(string msg)
        {
            Emit("ProjectHome_001:notify", msg);
        }

        public void SetTeam(int team)
        {
            Team = team;

            int color;
            switch (team)
            {
                case 0: //Cops
                    color = 3;
                    break;
                case 1: //Grove
                    color = 2;
                    break;
                case 2: //Ballas
                    color = 7;
                    break;
                default: //Zivilist
                    color = 4;
                    break;
            }
            SetStreamSyncedMetaData("ProjectHome_001:teamcolor", color);
        }

        public void CreatePlayer(string username, string password)
        {
            DisplayName = username;

            Db_Id = PlayerDatabase.CreatePlayer(DisplayName, password);
            Login();
        }

        public void LoadPlayer(string username)
        {
            DisplayName = username;
            PlayerDatabase.LoadPlayer(this);
            Login();
        }

        public void Save()
        {
            PlayerDatabase.UpdatePlayer(this);
        }
    }
}
