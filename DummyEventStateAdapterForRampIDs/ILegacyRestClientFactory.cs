using RestSharp;

namespace DummyEventStateAdapterForRampIDs
{
	public interface ILegacyRestClientFactory
	{
		string Name { get; }
		//RestClient GetClient { get; }

		public RestClient GetClient();
	}
}
