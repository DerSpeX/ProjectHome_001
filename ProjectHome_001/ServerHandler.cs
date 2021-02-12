using AltV.Net;
using AltV.Net.Elements.Entities;
using ProjectHome_001.Factories;
using ProjectHome_001.Database;

namespace ProjectHome_001
{
    class ServerHandler : Resource
    {
        public override void OnStart()
        {
            Alt.Log(" >> Server wird gestartet! << ");
            new OwnDatabase();
            Alt.Log("Pre Alpha v.0.0.1");
            
        }

        public override void OnStop()
        {
            Alt.Log(" >> Server wird gestoppt! << ");
        }

        public override IEntityFactory<IVehicle> GetVehicleFactory()
        {
            return new ProjectHome_001.Factories.VehicleFactory();
        }

        public override IEntityFactory<IPlayer> GetPlayerFactory()
        {
            return new ProjectHome_001.Factories.PlayerFactory();
        }

    }
}
