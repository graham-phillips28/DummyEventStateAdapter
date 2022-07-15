using EventStateAdapter.RampIdProvider;
using EventStateAdapter.RampIdProvider.Client;
using EventStateAdapter.RampIdProvider.Configuration;
using Microsoft.Extensions.Configuration;
using RestSharp;

namespace RampIdProviderIntegrationTests
{

    public class RampIdIntegrationTests
    {
        private readonly IRestClientFactory _rampRestClientFactory;
        public static IConfiguration InitConfiguration()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.test.json").AddEnvironmentVariables().Build();
            return config;
        }



        public RampIdIntegrationTests()
        {
            var configuration = InitConfiguration();
            RampWebServicesOptions rampWebServicesOptions = configuration.GetSection("RampWebServicesOptions").Get<RampWebServicesOptions>();
            _rampRestClientFactory = new RampRestClientFactory(new RampRestClientConfiguration(rampWebServicesOptions));
        }


        [Fact]
        public async Task GetRampId_IntgrationTest()
        {
            RampIdClient rampIdClient = new RampIdClient(_rampRestClientFactory);
            RampIdResponseProvider rampAdaptor = new RampIdResponseProvider(rampIdClient);

            var rampId = await rampAdaptor.GetNewRampId();

            Assert.NotEqual(-1, rampId);
        }
    }
}