using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spaceport
{
    public class Person
    {
        public int PersonID { get; set; }
        public string Name { get; set; }

        public bool IsPartOfStarwars()
        {
            var client = new RestClient("https://swapi.co/api/people/");
            var request = new RestRequest("?search=Luke+Sky", DataFormat.Json);
            var peopleResponse = client.Get<StarwarsAPIResponse>(request);

            Console.WriteLine("API: " + peopleResponse.Content);

            return true;
        }
    }
}
