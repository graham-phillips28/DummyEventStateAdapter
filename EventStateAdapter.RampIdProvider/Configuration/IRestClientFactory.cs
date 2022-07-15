using RestSharp;

namespace EventStateAdapter.RampIdProvider.Configuration
{
    public interface IRestClientFactory
    {
        string Name { get; }
        RestClient GetClient { get; }
    }
}
