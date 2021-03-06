﻿using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using System;
using static ProjectHome_001.Enums;

namespace ProjectHome_001.OwnEntities
{
    class OwnVehicle : Vehicle
    {

        public static float MAX_FUEL = 60.0f;

        public FuelTypes FuelType { get; set; }
        public float Fuel { get; set; }

        public string License { get; set; }

        public string Owner { get; set; }
        public OwnVehicle(IntPtr nativePointer, ushort id) : base(nativePointer, id)
        {

        }

        public OwnVehicle(uint model, Position position, Rotation rotation, FuelTypes fueltype = FuelTypes.None) : base(model, position, rotation)
        {
            FuelType = fueltype;
            Fuel = 0;
            ManualEngineControl = true;
        }

        /* public void Repair()
        {
            if(NetworkOwner != null) {
                Fuel = MAX_FUEL;
                NetworkOwner.Emit("ProjectHome_001:fixveh");
                PlayerEvents.SendNotification(NetworkOwner, "Fahrzeug repariert!");
            }
        }*/

        public void ToggleEngine()
        {
            if (!EngineOn && FuelType != FuelTypes.None && Fuel == 0)
            {
                OwnPlayer player = (OwnPlayer)NetworkOwner;
                player.SendNotification("Tank leer");
                //return;
            }
            EngineOn = !EngineOn;

            if (EngineOn)
            {
                OwnPlayer player = (OwnPlayer)NetworkOwner;
                player.SendNotification("Motor an");
            }
            else
            {
                OwnPlayer player = (OwnPlayer)NetworkOwner;
                player.SendNotification("Motor aus");
            }
        }
    }
}