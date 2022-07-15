namespace DummyEventStateAdapterForRampIDs
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ILegacyRestClientFactory _clientFactory;

        public Worker(ILogger<Worker> logger, ILegacyRestClientFactory clientFactory)
        {
            _logger = logger;
            _clientFactory = clientFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //var rampIdProvider = new RampWebServicesRestAdapter(_clientFactory);
            //var newRampId = rampIdProvider.GetRampNewId();
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation($"Worker running at: ");
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}