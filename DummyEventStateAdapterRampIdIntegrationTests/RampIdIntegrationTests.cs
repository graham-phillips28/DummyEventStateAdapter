using DummyEventStateAdapterForRampIDs;
using Microsoft.Extensions.Configuration;
using RestSharp;

namespace DummyEventStateAdapterRampIdUnitTests
{
    public class RampIdIntegrationTests
    {
        private readonly ILegacyRestClientFactory _rampRestClientFactory;

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
            _rampRestClientFactory = new RampRestClientFactory(new RampRestClientConfiguration(configuration.GetSection("RampWebServicesOptions").Get<RampWebServicesOptions>()));
        }

        [Fact]
        public async Task GetRampId_IntgrationTest()
        {
            //RampIdClient rampIdClient = new RampIdClient(_rampRestClientFactory);
            RampIdProvider rampIdProvider = new RampIdProvider(_rampRestClientFactory);

            var rampId = await rampIdProvider.GetRampNewId();

            Assert.NotEqual(-1, rampId);
        }

    }
}