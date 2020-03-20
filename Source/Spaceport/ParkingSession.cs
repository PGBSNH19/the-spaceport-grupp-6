using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Spaceport
{
    public class ParkingSession
    {
        public int ParkingSessionID { get; set; }
        public ParkingSpot ParkingSpot { get; set; }
        [NotMapped]
        public ISpaceShip SpaceShip { get; set; }
        public SpacePort SpacePort { get; set; }
        public bool ParkingToken { get; set; }
        public DateTime RegistrationTime { get; set; }
        public DateTime ValidUntil { get; set; }

        public ParkingSession SetForShip(ISpaceShip ship)
        {
            SpaceShip = ship;
            return this;
        }
        public ParkingSession  ValidateParkingRight()
        {
            if (!this.SpaceShip.Driver.IsPartOfStarwars())
            {
                throw new NotImplementedException();
            }
            return this;
        }

        public ParkingSession AtSpacePort(SpacePort port)
        {
            SpacePort = port;
            return this;
        }

        public ParkingSession FindFreeSpot()
        {
            ParkingSpot = SpacePort.FreeParkingSpot(SpaceShip.Length);
            return this;
        }

        public bool SessionIsValid(DateTime currentTime)
        {
            return currentTime > ValidUntil;
        }
    }
}
