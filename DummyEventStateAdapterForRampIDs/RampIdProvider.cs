using RestSharp;

namespace DummyEventStateAdapterForRampIDs


{
	public class RampIdProvider : IDisposable
	{
		private readonly ILegacyRestClientFactory _rampRestClientFactory;
		private bool _disposed;
		private const string AcceptHeaderValue = @"application/json";
		private const string ContentHeaderValue = @"application/json";

		public RampIdProvider(ILegacyRestClientFactory rampRestClientFactory)
		{
			_rampRestClientFactory = rampRestClientFactory;
		}

		public async Task<long> GetRampNewId()
		{
			//var rampIdsList = new List<long>();
			long rampId = -1;

			try
			{
				var rwsRestRequest = new RestRequest();
				rwsRestRequest.AddHeader("Accept", AcceptHeaderValue);
				rwsRestRequest.AddHeader("Content", ContentHeaderValue);
				rwsRestRequest.Resource = "resources/nextId/event";

				var rampRestClient = _rampRestClientFactory.GetClient();
				/*
				_logger.LogInformation(
					$"Attempting to retrieve next {range} of RAMP event Ids at: {rampRestClient.BaseUrl}/resources/nextId/event?numberOfIds={range}",
					("event", "RAMP event Id request"));
				*/
				var rwsRestResponse = await rampRestClient.ExecuteGetAsync<RampIdResponse>(rwsRestRequest);

				if (rwsRestResponse.IsSuccessful && rwsRestResponse.Data != null)
				{
					/*
					_logger.LogInformation(
						$"Found {rwsRestResponse.Data.List.Count} event Id.",
						("event", "RAMP event Id response"),
						("payload", $"{rwsRestResponse.Content}"));
					*/
					rampId = rwsRestResponse.Data.List[0];
				}

			}
			catch (Exception exception)
			{
				//_logger.LogInformation(exception.Message, exception);
				Console.WriteLine(exception);
			}

			return rampId;

		}


		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (_disposed) return;

			if (disposing)
			{
			}

			_disposed = true;
		}

		~RampIdProvider()
		{
			Dispose(false);
		}
	}
}