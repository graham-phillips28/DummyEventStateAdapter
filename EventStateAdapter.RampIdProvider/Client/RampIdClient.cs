using EventStateAdapter.RampIdProvider.Configuration;
using RestSharp;

namespace EventStateAdapter.RampIdProvider.Client
{
    public class RampIdClient : IRampIdClient
    {
        private readonly IRestClientFactory _rampRestClientFactory;

        public RampIdClient(IRestClientFactory restClientFactory)
        {
            _rampRestClientFactory = restClientFactory;
        }
        public async Task<RestResponse<RampIdResponse>> GetIdResponse(RestRequest request)
        {
            var rampRestClient = _rampRestClientFactory.GetClient;
            var restResponse = await rampRestClient.ExecuteGetAsync<RampIdResponse>(request);
            return restResponse;
        }
    }
}
