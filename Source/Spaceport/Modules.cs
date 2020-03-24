using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace Spaceport
{
    class Modules
    {
        public static void InfoPrint(string s, int milliSeconds = 0)
        {
            for (int i = 0; i < s.Length; i++)
            {
                Console.Write(s[i]);
                Thread.Sleep(10);
            }
            Console.Write("\n");
            Thread.Sleep(milliSeconds);
        }

        public static void ComputerPrint(string s, int milliSeconds = 2000)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < s.Length; i++)
            {
                Console.Write(s[i]);
                Thread.Sleep(10);
            }
            Console.Write("\n");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(milliSeconds);
        }

        public static void WelcomeToSpacePark()
        {
            Console.Clear();
            Thread.Sleep(1000);
            Console.ForegroundColor = ConsoleColor.Green;
            var logo = File.ReadAllLines("spacepark_logo.txt");

            List<string> textArt = new List<string>();

            for (int i = 0; i < logo.Length; i++)
            {
                textArt.Add(logo[i]);
            }

            char[,] letters = new char[textArt.Count, 102];
            for (int y = 0; y < textArt.Count; y++)
            {
                char[] let = textArt[y].ToCharArray();

                for (int x = 0; x < let.Length; x++)
                {
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
                    if (letters[y, x] != ' ')
                    {
                        Console.Write(letters[y, x]);
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
                        Thread.Sleep(2);
                    }
                }
            }

            Console.SetCursorPosition(0, 0);

            foreach (string line in logo)
            {
                Console.WriteLine(line);
                Thread.Sleep(50);
            }

            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(1000);
        }
    }
}
