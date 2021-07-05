using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Spaceport.Models;

namespace Spaceport
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
            while(true)
            {
                Console.Clear();
                //Styling.PrintSpaceParkASCIILogo();

                Styling.ConsolePrint("\nWelcome to SpacePark!");

                var userInput = new UserInput()
                    .GetPersonChoice()
                    .GetSpaceShipChoice()
                    .GetSpacePortChoice();

                new ParkingSession()
                    .AtSpacePort(userInput.SpacePort)
                    .SetForShip(userInput.SpaceShip)
                    .ValidateParkingRight(userInput.Person)
                    .FindFreeSpot()
                    .CreateInvoice()
                    .StartParkingSession();

                Console.ReadLine();
            }
        }
    }
}