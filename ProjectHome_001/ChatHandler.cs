using System;
using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Enums;
using AltV.Net.Resources.Chat.Api;
using ProjectHome_001.OwnEntities;
using static ProjectHome_001.Enums;
using System.Collections.Generic;

namespace ProjectHome_001
{
    class ChatHandler : IScript
    {
        public static List<OwnVehicle> parkedCars = new List<OwnVehicle>();

        [ClientEvent("chat:message")]

        public void OnChatMessage(OwnPlayer player, string msg)
        {
            if (msg.Length == 0 || msg[0] == '/') return;

            foreach (OwnPlayer target in Alt.GetAllPlayers())
            {
                target.SendChatMessage($"{player.DisplayName} sagt: {msg}");
            }
        }

        [CommandEvent(CommandEventType.CommandNotFound)]
        public void OnCommandNotFound(OwnPlayer player, string cmd)
        {
            player.SendChatMessage("{FF0000}[Server] {FFFFFF}Befehl konnte nicht gefunden werden!");
        }

        [Command("?")]
        public static void CMD_CommandList(OwnPlayer player)
        {
            player.SendChatMessage("/veh [1-255] [1-255] [1-255] = Fahrzeugspawn.");
            player.SendChatMessage("/pos = Zeigt deine aktuellen Koordinaten.");
            player.SendChatMessage("/go [x] [y] [z] = Spawnt dich zu den eingegebenen Koordinaten.");
            player.SendChatMessage("/engine oder Tastendruck [M] = Motor anschalten/ausschalten.");
            player.SendChatMessage("/fixveh = Fahrzeugreperatur.");
            player.SendChatMessage("/player = Liste aller Spieler die sich auf dem Server befinden.");
            player.SendChatMessage("/team [1-4] = Hier kannst du eines von 4 Teams wählen.");
            player.SendChatMessage("/SCiD = Hier kannst du dir deine Social-Club ID anzeigen lassen.");
            player.SendChatMessage("/remveh [Bsp.FBI2] = entfernt Fahrzeug innerhalb von 5 Metern.");
            player.SendChatMessage("/doorlock verschließt Türen von innen");
            player.SendChatMessage("/doorunlock öffnet Türen von innen");
            player.SendChatMessage("/getHere [Name] portet Spieler XY zu mir");
            player.SendChatMessage("/goThere [Name] portet mich zum Spieler XY");
            player.SendChatMessage("/kick [Name] kickt den Spieler XY");
        }

        // Fahrzeugbefehle

        [Command("veh")]
        public static void CMD_CreateVehicle(OwnPlayer player, string vehName, int r = 0, int g = 0, int b = 0)
        {
            uint vehHash = Alt.Hash(vehName);
            if (!Enum.IsDefined(typeof(VehicleModel), vehHash) && !Enum.IsDefined(typeof(ModCars), vehHash))
            {
                player.SendChatMessage("[Server] Ungültiger Fahrzeugname!");
                return;
            }

            OwnVehicle veh;
            if (player.HasData("ProjectHome_001:vehicle"))
            {
                player.GetData("ProjectHome_001:vehicle", out veh);
               // veh.Remove();    //vorerst entfernt
            }

            //IVehicle veh = Alt.CreateVehicle(vehHash, GetRandomPositionAround(player.Position, 5.0f), player.Rotation);
            veh = new OwnVehicle(vehHash, GetRandomPositionAround(player.Position, 5.0f), player.Rotation);
            veh.PrimaryColorRgb = new Rgba(Convert.ToByte(r), Convert.ToByte(g), Convert.ToByte(b), 255);
            veh.SecondaryColorRgb = new Rgba(Convert.ToByte(r), Convert.ToByte(g), Convert.ToByte(b), 255);

            player.SetData("ProjectHome_001:vehicle", veh);

            veh.License = veh.Model.ToString() + veh.Id.ToString(); //nur testweise
            veh.Owner = player.DisplayName;

            player.SendChatMessage(vehName + " wurde gespawnt! Kennzeichen: " + veh.License);
        }

        [Command("getOwner")]
        public static void CMD_GetOwner(OwnPlayer player, string license)
        {
            foreach (OwnVehicle target in Alt.GetAllVehicles())
            {
                if (target.License == license)
                {
                    player.SendChatMessage("Der Besitzer ist: " + target.Owner);
                    return;
                }
                player.SendChatMessage("kein Fahrzeug mit diesem Kennzeichen");
            }
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

        [Command("doorlock")] //schließt das nächste Fahrzeuge ab
        public static void CMD_DoorLock(OwnPlayer player)
        {
            float dist = 99;
            OwnVehicle tmp = null;

            foreach (OwnVehicle target in Alt.GetAllVehicles())
            {
                if (player.Position.Distance(target.Position) < dist)
                {
                    dist = player.Position.Distance(target.Position);
                    tmp = target;
                }
                target.LockState = VehicleLockState.ForceDoorsShut; //greift nicht
                target.LockState = VehicleLockState.Locked;
            }
            if(tmp == null)
            {
                player.SendChatMessage("kein Fahrzeug in deiner Nähe");
            }
        }

        [Command("doorunlock")] //schließt das nächste Fahrzeuge auf
        public static void CMD_DoorUnlock(OwnPlayer player)
        {
            float dist = 99;
            OwnVehicle tmp = null;

            foreach (OwnVehicle target in Alt.GetAllVehicles())
            {
                if (player.Position.Distance(target.Position) < dist)
                {
                    dist = player.Position.Distance(target.Position);
                    tmp = target;
                }
                target.LockState = VehicleLockState.Unlocked;
            }
            if (tmp == null)
            {
                player.SendChatMessage("kein Fahrzeug in deiner Nähe");
            }
        }

        [Command("doorstight")] //Türen verriegelbar
        public static void CMD_Doortight(OwnPlayer player)
        {
            if (!player.IsInVehicle || player.Seat != 1) return;

            OwnVehicle veh = (OwnVehicle)player.Vehicle;
            veh.SetDoorState(0, 0); // 0 = Fahrertür //!Convert.ToByte(g)!
            veh.SetDoorState(1, 0); // 1= Beifahrertür
            veh.SetDoorState(2, 0); // Türen hinten vsl. links
            veh.SetDoorState(3, 0); // Türen hinten vsl. rechts
            veh.SetDoorState(4, 0); // evtl. Motorhaube
            veh.SetDoorState(5, 0); // evtl. Kofferraum
        }

        [Command("doorswide")] //Türen nicht verriegelbar
        public static void CMD_DoorWide(OwnPlayer player)
        {
            if (!player.IsInVehicle || player.Seat != 1) return;

            OwnVehicle veh = (OwnVehicle)player.Vehicle;
            veh.SetDoorState(0, 1); // 0 = Fahrertür
            veh.SetDoorState(1, 1); // 1= Beifahrertür
            veh.SetDoorState(2, 1); // Türen hinten vsl. links
            veh.SetDoorState(3, 1); // Türen hinten vsl. rechts
            veh.SetDoorState(4, 1); // evtl. Motorhaube
            veh.SetDoorState(5, 1); // evtl. Kofferraum
        }

        [Command("remveh")]
        public static void CMD_RemoveVehicle(OwnPlayer player, string vehName)
        {
            uint vehHash = Alt.Hash(vehName);

            foreach (OwnVehicle target in Alt.GetAllVehicles())
            {
                if (player.Position.Distance(target.Position) <= 5 && target.Model == vehHash)
                {
                    parkedCars.Add(new OwnVehicle(target.Model, target.Position, target.Rotation , target.FuelType)); //speichere eine Kopie des Fahrzeugs
                    player.SendNotification("Fahrzeug wurde eingeparkt"); //funktioniert nur bei manchen
                    target.Remove();
                    return;
                }
                else
                {
                    player.SendChatMessage("kein Fahrzeug mit diesem Namen in deiner Nähe");
                }
            }
        }

        [Command("ausparken")] //test
        public static void CMD_ausparken(OwnPlayer player, string license)
        {
            foreach(OwnVehicle target in parkedCars)
            {
                if(target.License == license)
                {
                    OwnVehicle veh = new OwnVehicle(target.Model, GetRandomPositionAround(player.Position, 5.0f), player.Rotation);
                    parkedCars.Remove(target);
                    player.SendChatMessage("Fahrzeug wurde ausgeparkt");
                    return;
                }
            }
            player.SendChatMessage("kein Fahrzeug mit diesem Kennzeichen eingeparkt");
        }

        [Command("getLicense")]
        public static void CMD_getLicense(OwnPlayer player)
        {
            if (!player.IsInVehicle || player.Seat != 1) return;
            OwnVehicle veh = (OwnVehicle)player.Vehicle;

            player.SendChatMessage(veh.License);
        }

        [Command("getParkedCars")]
        public static void CMD_getParkedCars(OwnPlayer player)
        {
            foreach (OwnVehicle target in parkedCars)
            {
                player.SendChatMessage(target.Model.ToString());
            }
        }

        [Command("getSpeed")] //wirft immer 0 zurück, selbst im freien Fall
        public static void CMD_GetSpeed(OwnPlayer player)
        {
            player.SendChatMessage(player.MoveSpeed.ToString());
        }
        
        [Command("togglesiren")] //aktiviert/deaktiviert nur die Sirene ganz normal, wo ist der Sound?
        public static void CMD_ToggleSiren(OwnPlayer player)
        {
            if (!player.IsInVehicle || player.Seat != 1) return;

            OwnVehicle veh = (OwnVehicle)player.Vehicle;
            veh.SirenActive = !veh.SirenActive;
        }

        // Spielerbefehle

        [Command("team")]
        public static void CMD_Team(OwnPlayer player, int team)
        {
            player.SetTeam(team);
        }

        [Command("pos")]
        public static void CMD_LocateMyPos(OwnPlayer player)
        {
            player.SendChatMessage(player.GetPosition().X.ToString() + " // " + player.GetPosition().Y.ToString() + " // " + player.GetPosition().Z.ToString());
        }

        [Command("go")]
        public static void CMD_GoToPos(OwnPlayer player, float x, float y, float z)
        {
            player.SetPosition(x, y, z);
        }

        [Command("SCId")]
        public static void CMD_SocialClubId(OwnPlayer player)
        {
            player.SendChatMessage(player.SocialClubId.ToString());
        }

        [Command("player")]
        public static void CMD_ListPlayers(OwnPlayer player)
        {
            foreach (OwnPlayer target in Alt.GetAllPlayers())
            {
                player.SendChatMessage(target.DisplayName);
            }
        }

        [Command("getHere")]
        public static void CMD_GetHere(OwnPlayer player, string name)
        {
            foreach (OwnPlayer target in Alt.GetAllPlayers())
            {
                if (name == target.DisplayName)
                {
                    target.SetPosition(player.GetPosition());
                }
            }
        }

        [Command("goThere")]
        public static void CMD_GoThere(OwnPlayer player, string name)
        {
            foreach (OwnPlayer target in Alt.GetAllPlayers())
            {
                if (name == target.DisplayName)
                {
                    player.SetPosition(target.GetPosition());
                }
            }
        }

        [Command("setweather")]
        public static void CMD_SetWeather(OwnPlayer player, WeatherType weather)
        {
            player.SetWeather(weather);
        }

        [Command("noclip")]
        public static void CMD_NoClip(OwnPlayer player)
        {
            player.Visible = false;
            player.Health = player.MaxHealth;
            player.Armor = player.MaxArmor;
        }

        [Command("kick")]
        public static void CMD_KickPlayer(OwnPlayer player, string name)
        {
            foreach (OwnPlayer target in Alt.GetAllPlayers())
            {
                if (name == target.DisplayName)
                {
                    target.Kick("Deine Verbindung wurde getrennt");
                }
            }
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