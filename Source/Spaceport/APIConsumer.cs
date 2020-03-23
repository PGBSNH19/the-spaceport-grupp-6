using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spaceport
{
    public class APIConsumer
    {
        public static async Task<bool> GetCharacterAsync(string search)
        {
            var restClient = new RestClient("https://swapi.co/api/");
            var restRequest = new RestRequest("people/?search=" + search, DataFormat.Json);
            var task = restClient.ExecuteAsync<CharacterDataRoot>(restRequest);

            Console.WriteLine("Fetching...");
            task.Wait();
            Console.WriteLine("Done...");

            var response = JsonConvert.DeserializeObject<CharacterDataRoot>(task.Result.Content);
            Console.WriteLine(response.Results.First().Name);
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