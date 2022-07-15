using System.Collections.Generic;
using Newtonsoft.Json;

namespace DummyEventStateAdapterForRampIDs

{
	public class RampIdResponse
	{
		[JsonProperty("list")] public List<long> List { get; set; }
	}
}
