using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Spaceport
{
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonID { get; set; }
        // Note: 
        // Specify more of these to avoid varchar(max)
        [MaxLength(50)] 
        public string Name { get; set; }

        public bool IsPartOfStarwars()
        {
            //var client = new RestClient("https://swapi.co/api/people/");
            //var request = new RestRequest("?search=Luke+Sky", DataFormat.Json);
            //var peopleResponse = client.Get<StarwarsAPIResponse>(request);

            //Console.WriteLine("API: " + peopleResponse.Content);

            return true;
        }
    }
}
