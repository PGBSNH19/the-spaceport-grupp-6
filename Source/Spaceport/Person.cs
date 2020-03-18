using System;
using System.Collections.Generic;
using System.Text;

namespace Spaceport
{
    public class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public List<String> Films { get; set; }
        public List<ISpaceShip> SpaceShips { get; set; }
    }
}
