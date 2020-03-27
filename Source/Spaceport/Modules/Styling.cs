using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace Spaceport
{
    public class Styling
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

        public static void ConsolePrint(string s, int milliSeconds = 0)
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

        public static void PrintSpaceParkASCIILogo()
        {
            Console.Clear();
            Thread.Sleep(1000);

            var logo = File.ReadAllLines("spacepark_logo.txt");
            List<string> textArt = LogoParseToList(logo);
            char[,] letters = LogoToCharArray(textArt);

            // Render
            RenderAtRandom(textArt, letters, true);
            Thread.Sleep(250);
            // Reverse Render
            RenderAtRandom(textArt, letters, false);
            Thread.Sleep(250);

            RenderTopDown(logo);

            Thread.Sleep(1000);
        }

        internal static List<string> LogoParseToList(string[] logo)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < logo.Length; i++)
                list.Add(logo[i]);
            return list;
        }

        internal static char[,] LogoToCharArray(List<string> textArt)
        {
            char[,] letters = new char[textArt.Count, 102];
            for (int y = 0; y < textArt.Count; y++)
            {
                char[] let = textArt[y].ToCharArray();
                for (int x = 0; x < let.Length; x++)
                    letters[y, x] = (char)let.GetValue(x);
            }
            return letters;
        }

        internal static void RenderAtRandom(List<string> textArt, char[,] letters, bool renderIn)
        {
            Random r = new Random();
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (int y in Enumerable.Range(0, textArt.Count - 1).OrderBy(x => r.Next()))
            {
                Console.CursorTop = y;
                foreach (int x in Enumerable.Range(0, textArt[y].Length - 1).OrderBy(x => r.Next()))
                {
                    Console.CursorLeft = x;
                    if (letters[y, x] != ' ')
                    {
                        Console.Write((renderIn) ? letters[y, x] : ' ');
                        Thread.Sleep(4);
                    }
                }
            }
        }

        internal static void RenderTopDown(string[] logo)
        {
            Console.SetCursorPosition(0, 0);
            foreach (string line in logo)
            {
                Console.WriteLine(line);
                Thread.Sleep(40);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}