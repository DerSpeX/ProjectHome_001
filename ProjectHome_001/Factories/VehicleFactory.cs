using AltV.Net;
using AltV.Net.Elements.Entities;
using ProjectHome_001.OwnEntities;
using System;

namespace ProjectHome_001.Factories
{
    class VehicleFactory : IEntityFactory<IVehicle>
    {
        public IVehicle Create(IntPtr entityPointer, ushort id)
        {
            return new OwnVehicle(entityPointer, id);
        }
    }
}
