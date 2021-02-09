using AltV.Net;
using AltV.Net.Elements.Entities;
using ProjectHome_001.OwnEntities;
using System;


namespace ProjectHome_001.Factories
{
    class PlayerFactory : IEntityFactory<IPlayer>
    {
        public IPlayer Create(IntPtr entityPointer, ushort id)
        {
            return new OwnPlayer(entityPointer, id);
        }
    }
}
