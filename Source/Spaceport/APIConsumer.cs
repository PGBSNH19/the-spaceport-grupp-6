using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spaceport
{
    public class APIConsumer
    {
        public static bool GetCharacterAsync(string search)
        {
            var task = new RestClient("https://swapi.co/api/")
                .ExecuteAsync<CharacterDataRoot>(
                    new RestRequest("people/?search=" + search, DataFormat.Json)
                );

            Styling.InfoPrint("\nWaiting for API response");
            new VisualProgress().Show(new Task[] { task }); 
            Styling.InfoPrint("\nResults are in");

            var response = JsonConvert.DeserializeObject<CharacterDataRoot>(task.Result.Content);
            return response.Results.Any();
        }
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