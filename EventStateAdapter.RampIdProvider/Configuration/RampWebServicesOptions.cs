using System;

namespace EventStateAdapter.RampIdProvider.Configuration
{
    public class RampWebServicesOptions
    {
        public string RwsEndpointBlue { get; set; }
        public string RwsEndpointGreen { get; set; }
        public string RwsUser { get; set; }
        public string RwsPass { get; set; }
    }
}
