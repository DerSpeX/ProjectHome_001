using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Enums;
using AltV.Net.Resources.Chat.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectHome_001
{
    class PlayerEvents:IScript
    {
        //[ScriptEvent(ScriptEventType.EventName)] -> ServerEvemt
        //Alt.Emit() -> Server to Server
        
        //Alt.EmitAllClient() -> Server to all Clients
        //player.Emit() -> Server to Client
        //[ClientEvent("eventname")] -> Client to Server



        [ScriptEvent(ScriptEventType.PlayerConnect)]
        public void OnPlayerConnect(IPlayer player, string reason)
        {
            player.Model = (uint)PedModel.Clown01SMY;
            player.Spawn(new AltV.Net.Data.Position (0, 0, 75));
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.AdvancedRifle, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.Widowmaker, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.FireExtinguisher, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.CarbineRifleMkII, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.SMGMkII, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.RPG, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.PistolMkII, 999, true);

        }

        [ScriptEvent(ScriptEventType.PlayerEnterVehicle)]

        public void OnPlayerEnterVehicle(IVehicle vehicle, IPlayer player, byte seat)
        {
            //vehicle.SecondaryColorRgb = new Rgba(255, 0, 0, 255);
            SendNotification(player, "Fahrzeug betreten.");

        }

        [ScriptEvent(ScriptEventType.PlayerLeaveVehicle)]

        public void OnPlayerLeaveVehicle(IVehicle vehicle, IPlayer player, byte seat)
        {
            //vehicle.SecondaryColorRgb = new Rgba(255, 255, 255, 255);
            SendNotification(player, "Fahrzeug verlassen.");
        }


        public static void SendNotification(IPlayer player, string msg)
        {
            player.Emit("ProjectHome_001:notify", msg);
        }

        [ScriptEvent(ScriptEventType.PlayerDead)]

        public static void OnPlayerDead(IPlayer player, IEntity killer, uint weapon)
        {
            if ((killer is IPlayer killerPlayer))
            {
                if (killerPlayer == player)
                {
                    player.SendChatMessage("Du hast dich selbst ermordet!");
                }
                else
                {
                    killerPlayer.SendChatMessage("Du hast " + player.Name + " getötet!");
                    player.SendChatMessage(killerPlayer?.Name + " hat dich umgebracht!");
                }
            }
            else if((killer is IVehicle vehicle))
            {
                player.SendChatMessage("Du wurdest von " + (VehicleModel)vehicle.Model + " getötet!");
            }

            player.Spawn(new Position(0, 0, 75), 1000);
        }
    }
}
