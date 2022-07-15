//using entmgt.Id.Collector.Configuration.Ramp.Configuration;
using RestSharp;

namespace DummyEventStateAdapterForRampIDs
{
	public class RampRestClientFactory : ILegacyRestClientFactory
	{
		private readonly RampRestClientConfiguration _restClientConfiguration;

		public RampRestClientFactory(RampRestClientConfiguration restClientConfiguration)
		{
			_restClientConfiguration = restClientConfiguration;
		}

		public string Name => "RampWebServices";

		public RestClient GetClient()
        {
			return new RestClient(_restClientConfiguration.PrimaryUri)
			{
				Authenticator = _restClientConfiguration.RestBasicAuthenticator
			};
		}




			
	}
}


