using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Spaceport
{
    class Program
    {
        //public readonly string CONNECTION_STRING = Environment.GetEnvironmentVariable("project3_spaceport_connectionString");
        public const string CONNECTION_STRING = @"Server=den1.mssql7.gear.host;Database=spaceport;Uid=spaceport;Pwd=Zm0~!8U6r493;";
        static void Main(string[] args)
        {
            Console.ReadLine();
            WelcomeToSpacePark();
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();

            var luke = new Person() { Name = "Luke Skywalker", PersonID = 1 };
            var xi = new Person() { Name = "Xi Jinping", PersonID = 2 };
            var donald = new Person() { Name = "Donald Trump", PersonID = 3 };

            var coruscantSpacePort = new SpacePort() {SpacePortID = 1, Name = "Coruscant" };

            SpaceShip bigShip = new StarShip() { SpaceShipID = 1, Length = 40 , Driver = luke};
            
            var parkingSession = new ParkingSession()
                .AtSpacePort(coruscantSpacePort)
                .SetForShip(bigShip)
                .ValidateParkingRight()
                .FindFreeSpot()
                .StartParkingSession();

            Console.ReadLine();
        }

        private static void WelcomeToSpacePark()
        {
            Console.Clear();
            Thread.Sleep(1000);
            Console.ForegroundColor = ConsoleColor.Green;
            var logo = File.ReadAllLines("spacepark_logo.txt");


            List<string> textArt = new List<string>();
            List<Task> printJobs = new List<Task>();

            for(int i=0; i < logo.Length; i++)
            {
                textArt.Add(logo[i]);
            }

            // 102 15

            char[,] letters = new char[textArt.Count, 102];
            for (int y = 0; y < textArt.Count; y++)
            {
                //Console.WriteLine("Get Line y"+y);
                char[] let = textArt[y].ToCharArray();

                for (int x = 0; x < let.Length; x++)
                {
                    //Console.WriteLine("Get X{0},Y{1},{2}",x,y,let.GetValue(x));
                    letters[y, x] = (char)let.GetValue(x);
                }
            }

            Random r = new Random();
            List<string> discard = new List<string>();

            foreach (int y in Enumerable.Range(0, textArt.Count - 1).OrderBy(x => r.Next()))
            {
                Console.CursorTop = y; 
                foreach (int x in Enumerable.Range(0, textArt[y].Length - 1).OrderBy(x => r.Next()))
                {
                    Console.CursorLeft = x;
                    if(letters[y,x] != ' ')
                    {
                        Console.Write(letters[y,x]);
                        Thread.Sleep(3);
                    }
                }
            }
            Thread.Sleep(500);
            foreach (int y in Enumerable.Range(0, textArt.Count - 1).OrderBy(x => r.Next()))
            {
                Console.CursorTop = y;
                foreach (int x in Enumerable.Range(0, textArt[y].Length - 1).OrderBy(x => r.Next()))
                {
                    Console.CursorLeft = x;
                    if (letters[y, x] != ' ')
                    {
                        Console.Write(" ");
                        Thread.Sleep(3);
                    }
                }
            }
            Thread.Sleep(500);
            Console.Clear();
            Thread.Sleep(100);
            Console.SetCursorPosition(0, 0);
            foreach (string line in logo)
            {
                Console.WriteLine(line);
                Thread.Sleep(50);
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

    }
}