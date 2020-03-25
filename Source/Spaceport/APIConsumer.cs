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
        public static CharacterDataRoot SearchCharacterAsync(string search)
        {
            var task = new RestClient("https://swapi.co/api/")
                .ExecuteAsync<CharacterDataRoot>(
                    new RestRequest("people/?search=" + search, DataFormat.Json)
                );

            Styling.InfoPrint("\nWaiting for API response");
            new VisualProgressBar().AwaitAndShow(new Task[] { task }); 
            Styling.InfoPrint("\nResults are in!", 1000);

            return JsonConvert.DeserializeObject<CharacterDataRoot>(task.Result.Content);
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