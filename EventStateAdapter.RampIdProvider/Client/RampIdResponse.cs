using System.Collections.Generic;
using Newtonsoft.Json;

namespace EventStateAdapter.RampIdProvider.Client

{
    public class RampIdResponse
    {
        [JsonProperty("list")] public List<long> List { get; set; }
    }
}
