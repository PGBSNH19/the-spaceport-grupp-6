using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spaceport
{
    class APIConsumer
    {
    }

    public class CharacterData
    {
        [JsonProperty("name")]
        public string Name { get; set; }

    }
    public class CharacterDataRoot
    {
        [JsonProperty("results")]
        public List<CharacterData> Results { get; set; }

    }
}