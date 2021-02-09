using AltV.Net.Elements.Entities;
using ProjectHome_001.Database;
using System;

namespace ProjectHome_001.OwnEntities
{
    class OwnPlayer : Player
    {
        public static string ConnectionString = "SERVER=localhost;DATABASE=ProjectHome;UID=ProjectHome;PASSWORD=ProjectHome";
        public bool IsLoggedIn { get; set; }
        public int Db_Id { get; set; }
        public string DisplayName { get; set; }
        public uint Cash { get; set; }



        public OwnPlayer(IntPtr nativePointer, ushort id) : base(nativePointer, id)
        {
            IsLoggedIn = false;
        }

        public void Login()
        {
            IsLoggedIn = true;
        }


        public void SendNotification(string msg)
        {
            Emit("ProjectHome_001:notify", msg);
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
