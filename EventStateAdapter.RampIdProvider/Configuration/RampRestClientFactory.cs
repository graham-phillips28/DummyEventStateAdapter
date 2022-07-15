using RestSharp;

namespace EventStateAdapter.RampIdProvider.Configuration
{
    public class RampRestClientFactory : IRestClientFactory
    {
        private readonly RampRestClientConfiguration _restClientConfiguration;

        public RampRestClientFactory(RampRestClientConfiguration restClientConfiguration)
        {
            _restClientConfiguration = restClientConfiguration;
        }

        public string Name => "RampWebServices";

        public RestClient GetClient =>




            new RestClient(_restClientConfiguration.PrimaryUri)
            {
                Authenticator = _restClientConfiguration.RestBasicAuthenticator
            };
    }





}



