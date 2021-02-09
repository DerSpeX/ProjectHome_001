using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Enums;
using AltV.Net.Resources.Chat.Api;
using ProjectHome_001.OwnEntities;
using System;

namespace ProjectHome_001
{
    class ChatHandler : IScript
    {
        [ClientEvent("chat:message")]

        public void OnChatMessage(IPlayer player, string msg)
        {
            if (msg.Length == 0 || msg[0] == '/') return;

            foreach (IPlayer target in Alt.GetAllPlayers())
            {
                if (target.Position.Distance(player.Position) <= 10)
                {
                    target.SendChatMessage($"{target.Name} sagt: {msg}");
                }
            }
        }

        [CommandEvent(CommandEventType.CommandNotFound)]

        public void OnCommandNotFound(IPlayer player, string cmd)
        {
            player.SendChatMessage("{FF0000} [Server] {FFFFFF} Befehl konnte nicht gefunden werden!");
        }

        [Command("?")]

        public static void CMD_CommandList(IPlayer player)
        {
            player.SendChatMessage("/veh [1-255] [1-255] [1-255] = Fahrzeugspawn.");
            player.SendChatMessage("/pos = Zeigt deine aktuellen Koordinaten.");
            player.SendChatMessage("/go [x] [y] [z] = Spawnt dich zu den eingegebenen Koordinaten.");
            player.SendChatMessage("/engine = Motor anschalten/ausschalten.");
            player.SendChatMessage("/fixveh = Fahrzeugreperatur.");
        }




        public static Position GetRandomPositionAround(Position pos, float range)
        {
            Random rnd = new Random();
            float x = pos.X + (float)rnd.NextDouble() * (range * 2) - range;
            float y = pos.Y + (float)rnd.NextDouble() * (range * 2) - range;
            return new Position(x, y, pos.Z);
        }


        [Command("veh")]
        public static void CMD_CreateVehicle(IPlayer player, string vehName, int r = 0, int g = 0, int b = 0)
        {
            uint vehHash = Alt.Hash(vehName);
            if (!Enum.IsDefined(typeof(VehicleModel), vehHash))
            {
                player.SendChatMessage("[Server] Ungültiger Fahrzeugname!");
                return;
            }

           //IVehicle veh = Alt.CreateVehicle(vehHash, GetRandomPositionAround(player.Position, 5.0f), player.Rotation);
            OwnVehicle veh = new OwnVehicle(vehHash, GetRandomPositionAround(player.Position, 5.0f), player.Rotation);
            veh.PrimaryColorRgb = new Rgba(Convert.ToByte(r), Convert.ToByte(g), Convert.ToByte(b), 255);
            veh.SecondaryColorRgb = new Rgba(Convert.ToByte(r), Convert.ToByte(g), Convert.ToByte(b), 255);

            player.SendChatMessage(vehName + " wurde gespawnt!");
        }

        [Command("engine")]

        public static void CMD_Engine(IPlayer player)
        {
            if (!player.IsInVehicle || player.Seat != 1) return;
            OwnVehicle veh = (OwnVehicle)player.Vehicle;
            veh.ToggleEngine();
        }

        [Command("fixveh")]

        public static void CMD_FixVeh(IPlayer player)
        {
            if (!player.IsInVehicle || player.Seat != 1) return;
            OwnVehicle veh = (OwnVehicle)player.Vehicle;
            veh.Repair();
        }


        [Command("pos")]
        public static void CMD_LocateMyPos(IPlayer player)
        {
            player.GetPosition();
            player.SendChatMessage(player.GetPosition().ToString());
        }

        [Command("go")]
        public static void CMD_GoToPos(IPlayer player, float x, float y, float z)
        {
            player.SetPosition(x, y, z);
        }
        
        [Command("gethere")]
        public static void CMD_GetHere(IPlayer player)
        {
            
        }

        [Command("kick")]

        public static void CMD_Kick(IPlayer player)
        {

        }
    }   
}
