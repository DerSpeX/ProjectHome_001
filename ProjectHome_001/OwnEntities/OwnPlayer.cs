using AltV.Net.Elements.Entities;
using System;

namespace ProjectHome_001.OwnEntities
{
    class OwnPlayer : Player
    {
        public bool IsLoggedIn { get; set; }
        public int Db_Id { get; set; }
        public string DisplayName { get; set; }
        public uint Cash { get; set; }



        public OwnPlayer(IntPtr nativePointer, ushort id) : base(nativePointer, id)
        {
            IsLoggedIn = false;
        }


        public void SendNotification(string msg)
        {
            Emit("ProjectHome_001:notify", msg);
        }


    }
}
