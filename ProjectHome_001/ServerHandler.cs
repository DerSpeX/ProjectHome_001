using AltV.Net;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Factories;
using ProjectHome_001.Database;

namespace ProjectHome_001
{
    class ServerHandler : Resource
    {
        public override void OnStart()
        {
            Alt.Log(" >> Server wird gestartet! << ");
            new OwnDatabase();
            
        }

        public override void OnStop()
        {
            Alt.Log(" >> Server wird gestoppt! << ");
        }

        public override IEntityFactory<IVehicle> GetVehicleFactory()
        {
            return new VehicleFactory();
        }

        public override IEntityFactory<IPlayer> GetPlayerFactory()
        {
            return new PlayerFactory();
        }

    }
}
