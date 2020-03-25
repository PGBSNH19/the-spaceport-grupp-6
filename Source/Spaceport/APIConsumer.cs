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
        public static bool CharacterExists(string search)
        {
            return SearchCharacterAsync(search).Results.Any();
        }

        public static CharacterDataRoot SearchCharacterAsync(string search)
        {
            var task = new RestClient("https://swapi.co/api/")
                .ExecuteAsync<CharacterDataRoot>(
                    new RestRequest("people/?search=" + search, DataFormat.Json)
                );

            Styling.InfoPrint("\nWaiting for API response");
            new VisualProgress().AwaitAndShow(new Task[] { task }); 
            Styling.InfoPrint("\nResults are in");

            var response = JsonConvert.DeserializeObject<CharacterDataRoot>(task.Result.Content);
            return response;
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