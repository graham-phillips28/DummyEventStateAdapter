using RestSharp;

namespace EventStateAdapter.RampIdProvider.Client
{
    public interface IRampIdClient
    {
        public Task<RestResponse<RampIdResponse>> GetIdResponse(RestRequest request);
    }
}
