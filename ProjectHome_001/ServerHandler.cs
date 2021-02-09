using AltV.Net;
using System;

namespace ProjectHome_001
{
    class ServerHandler : Resource
    {
        public override void OnStart()
        {
            Alt.Log(" >> Server wird gestartet! << ");
        }

        public override void OnStop()
        {
            
        }
    }
}
