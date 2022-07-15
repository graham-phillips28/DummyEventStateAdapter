using DummyEventStateAdapterForRampIDs;



// Build the configuration before we run the host
var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Development.json").AddEnvironmentVariables().Build();

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
		var legacyRestClientFactories = new List<ILegacyRestClientFactory>();
        legacyRestClientFactories.Add(new RampRestClientFactory(new RampRestClientConfiguration(configuration.GetSection("RampWebServicesOptions").Get<RampWebServicesOptions>())));

        services.AddSingleton<IEnumerable<ILegacyRestClientFactory>>(legacyRestClientFactories);
	})
    .Build();








await host.RunAsync();

