using System;
using System.Collections.Generic;
using System.Text;

namespace Spaceport
{
    public class ParkingSession
    {
        public int ParkingSessionId { get; set; }
        public Parkingspot Parkingspot { get; set; }
        public ISpaceship Spaceship { get; set; }
        public bool Token { get; set; }
        public DateTime RegistrationTime { get; set; }
        public DateTime ValidUntil { get; set; }

        public bool SessionIsValid(DateTime currentTime)
        {
            return currentTime > ValidUntil;
        }
    }
}
