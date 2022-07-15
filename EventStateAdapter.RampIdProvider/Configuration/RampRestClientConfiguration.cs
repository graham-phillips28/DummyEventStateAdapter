using System;
using RestSharp.Authenticators;

namespace EventStateAdapter.RampIdProvider.Configuration


{
    public class RampRestClientConfiguration
    {
        private readonly RampWebServicesOptions _rampWebServicesOptions;

        public RampRestClientConfiguration(RampWebServicesOptions rampWebServicesOptions)
        {
            _rampWebServicesOptions = rampWebServicesOptions;
        }

        public Uri PrimaryUri => new Uri(_rampWebServicesOptions.RwsEndpointBlue);
        public Uri SecondaryUri => new Uri(_rampWebServicesOptions.RwsEndpointGreen);

        public HttpBasicAuthenticator RestBasicAuthenticator => new HttpBasicAuthenticator(_rampWebServicesOptions.RwsUser, _rampWebServicesOptions.RwsPass);
    }
}
