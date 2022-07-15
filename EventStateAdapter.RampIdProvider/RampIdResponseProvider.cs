using EventStateAdapter.RampIdProvider.Client;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventStateAdapter.RampIdProvider
{
    public class RampIdResponseProvider : IDisposable
    {
        public IRampIdClient _rampIdClient;
        private bool _disposed;
        private const string AcceptHeaderValue = @"application/json";
        private const string ContentHeaderValue = @"application/json";
    
        
        public  RampIdResponseProvider(IRampIdClient client)
        {
            _rampIdClient = client;
        }
        public async Task<long> GetNewRampId()
        {
            
            long rampId = -1;

            try
            {
                var rwsRestRequest = new RestRequest();
                rwsRestRequest.AddHeader("Accept", AcceptHeaderValue);
                rwsRestRequest.AddHeader("Content", ContentHeaderValue);
                rwsRestRequest.Resource = "resources/nextId/event";
                /*
				_logger.LogInformation(
					$"Attempting to retrieve next {range} of RAMP event Ids at: {rampRestClient.BaseUrl}/resources/nextId/event?numberOfIds={range}",
					("event", "RAMP event Id request"));
				*/
                var rwsRestResponse =  await _rampIdClient.GetIdResponse(rwsRestRequest);

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

        ~RampIdResponseProvider()
        {
            Dispose(false);
        }
    }
}
