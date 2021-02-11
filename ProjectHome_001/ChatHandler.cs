using System;
using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Enums;
using AltV.Net.Resources.Chat.Api;
using ProjectHome_001.OwnEntities;

namespace ProjectHome_001
{
    class ChatHandler : IScript
    {

        [ClientEvent("chat:message")]
        public void OnChatMessage(OwnPlayer player, string msg)
        {
            if (msg.Length == 0 || msg[0] == '/') return;

            foreach (OwnPlayer target in Alt.GetAllPlayers())
            {
                if (target.Position.Distance(player.Position) <= 10)
                {
                    target.SendChatMessage($"{player.Name} sagt: {msg}");
                }
            }
        }

        [CommandEvent(CommandEventType.CommandNotFound)]
        public void OnCommandNotFound(OwnPlayer player, string cmd)
        {
            player.SendChatMessage("{FF0000}[Server] {FFFFFF}Befehl konnte nicht gefunden werden!");
        }

        [Command("veh")]
        public static void CMD_CreateVehicle(OwnPlayer player, string vehName, int r = 0, int g = 0, int b = 0)
        {
            uint vehHash = Alt.Hash(vehName);
            if (!Enum.IsDefined(typeof(AltV.Net.Enums.VehicleModel), vehHash))
            {
                player.SendChatMessage("[Server] Ungültiger Fahrzeugname!");
                return;
            }

            OwnVehicle veh;
            if (player.HasData("ProjectHome_001:vehicle"))
            {
                player.GetData("ProjectHome_001:vehicle", out veh);
                veh.Remove();
            }

            //IVehicle veh = Alt.CreateVehicle(vehHash, GetRandomPositionAround(player.Position, 5.0f), player.Rotation);
            veh = new OwnVehicle(vehHash, GetRandomPositionAround(player.Position, 5.0f), player.Rotation);
            veh.PrimaryColorRgb = new Rgba(Convert.ToByte(r), Convert.ToByte(g), Convert.ToByte(b), 255);
            veh.SecondaryColorRgb = new Rgba(Convert.ToByte(r), Convert.ToByte(g), Convert.ToByte(b), 255);

            player.SetData("ProjectHome_001:vehicle", veh);

            player.SendChatMessage("Fahrzeug gespawnt!");

        }

        [Command("engine")]
        public static void CMD_Engine(OwnPlayer player)
        {
            if (!player.IsInVehicle || player.Seat != 1) return;
            OwnVehicle veh = (OwnVehicle)player.Vehicle;
            veh.ToggleEngine();
        }

        [Command("fixveh")]
        public static void CMD_FixVeh(OwnPlayer player)
        {
            if (!player.IsInVehicle || player.Seat != 1) return;
            OwnVehicle veh = (OwnVehicle)player.Vehicle;
            veh.Repair();
        }

        [Command("team")]
        public static void CMD_Team(OwnPlayer player, int team)
        {
            player.SetTeam(team);
        }

        public static Position GetRandomPositionAround(Position pos, float range)
        {
            Random rnd = new Random();
            float x = pos.X + (float)rnd.NextDouble() * (range * 2) - range;
            float y = pos.Y + (float)rnd.NextDouble() * (range * 2) - range;
            return new Position(x, y, pos.Z);
        }
    }
}

