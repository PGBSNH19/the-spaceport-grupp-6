using System;
using System.Collections.Generic;
using System.Text;

namespace Spaceport
{
    class StarwarsAPIResponse
    {
        public int count { get; set; }
        public string next { get; set; }
        public string previous { get; set; }
        public IEnumerable<Object> results { get; set; }
    }
}
