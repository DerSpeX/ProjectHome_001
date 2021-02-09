using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Enums;
using AltV.Net.Resources.Chat.Api;
using ProjectHome_001.OwnEntities;

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
            player.Model = (uint)PedModel.ArmLieut01GMM;
            player.Spawn(new AltV.Net.Data.Position (0, 0, 72));
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.AdvancedRifle, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.Widowmaker, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.FireExtinguisher, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.CarbineRifleMkII, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.SMGMkII, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.RPG, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.PistolMkII, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.StunGun, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.VintagePistol, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.UpnAtomizer, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.UnholyHellbringer, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.TearGas, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.Switchblade, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.SweeperShotgun, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.StoneHatchet, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.StickyBomb, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.SpecialCarbine, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.SpecialCarbineMkII, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.SNSPistolMkII, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.SNSPistol, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.Snowballs, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.SniperRifle, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.SMG, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.SawedOffShotgun, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.Railgun, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.PumpShotgunMkII, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.PumpShotgun, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.ProximityMines, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.PoolCue, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.Pistol50, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.Pistol, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.PipeWrench, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.PipeBombs, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.Parachute, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.Nightstick, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.Musket, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.MolotovCocktail, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.MiniSMG, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.Minigun, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.MicroSMG, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.MG, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.MarksmanRifleMkII, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.MarksmanRifle, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.MarksmanPistol, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.MachinePistol, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.Machete, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.Knife, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.JerryCan, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.HomingLauncher, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.HeavySniperMkII, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.HeavySniper, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.HeavyShotgun, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.HeavyRevolverMkII, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.HeavyRevolver, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.HeavyPistol, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.Hatchet, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.Hammer, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.GusenbergSweeper, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.Grenade, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.GrenadeLauncher, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.GrenadeLauncherSmoke, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.GolfClub, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.Flashlight, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.FlareGun, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.Flare, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.Fist, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.FireworkLauncher, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.FireExtinguisher, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.DoubleBarrelShotgun, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.DoubleActionRevolver, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.Crowbar, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.CompactRifle, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.CompactGrenadeLauncher, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.CombatPistol, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.CombatPDW, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.CombatMGMkII, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.CombatMG, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.BZGas, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.BullpupShotgun, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.BullpupRifleMkII, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.BullpupRifle, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.BrokenBottle, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.BrassKnuckles, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.BattleAxe, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.BaseballBat, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.Baseball, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.AssaultSMG, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.AssaultShotgun, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.AssaultRifleMkII, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.AssaultRifle, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.APPistol, 999, true);
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.AntiqueCavalryDagger, 999, true);
            



        }

        [ScriptEvent(ScriptEventType.PlayerEnterVehicle)]

        public void OnPlayerEnterVehicle(OwnVehicle vehicle, IPlayer player, byte seat)
        {
            
            SendNotification(player, (VehicleModel)vehicle.Model + " betreten.");

        }

        [ScriptEvent(ScriptEventType.PlayerLeaveVehicle)]

        public void OnPlayerLeaveVehicle(OwnVehicle vehicle, IPlayer player, byte seat)
        {
           
            SendNotification(player, (VehicleModel)vehicle.Model + " verlassen.");
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
