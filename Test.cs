using System;
using System.Collections.Generic;
using System.Linq;

namespace libs
{
    public static class Test
    {
        private static List<string> fancyNames = LoadFancyNames();
        private static List<string> LoadFancyNames()
        {
           List<string> fancyNames = new List<string>() {
                "proton", "electron", "neutron", "pion", "photon", "neutrino", "muon", "graviton", "lepton",
                "One", "Two", "Three", "Four", "Fife", "Six", "Seven", "Eight", "Nine",
                "1st", "2nd", "3rd", "4th", "5th", "6th", "7th", "8th", "9th",
                "1", "2", "3", "4", "5", "6", "7", "8", "9",
                "Perseus", "Thor", "Superman", "Batman", "Lothain", "Adramelech", "Zeus", "Kju", "Goran", "Botabing", "Ares",
                "Battlestar Galactica", "Bird of Prey", "X-Wing", "Enterprise", "Defiand", "Tie Fighter", "Quadron Confinement", "Prometheus", "Warp Beacon",
                "11", "12", "13", "14", "21", "22", "23", "24", "31", "32", "33", "41", "42"
            };
            return fancyNames;
        }

        public static void Run_Fancynames_Test()
        {
            Core.MeasureRuntime(() => {
                fancyNames.FilterBy(i => i.EndsWith("n")).ThenFilterBy(i => i.Contains("G")).ToList().ForEach(i => {
                    System.Console.WriteLine($"{i.ToUpper()}");
                });
            }, "applying some filter methods to a list");
        }
        
        public static void Run_ListFancynames_Test()
        {
            Core.MeasureRuntime(() =>
            {
                    // All items ordered ascending
                    fancyNames.FilterBy(n => n.Any()).OrderBy(n => n).ToList().ForEach(n => Console.WriteLine($"{n}"));
                    // All items UPPERCASE ordered descending
                    fancyNames.FilterBy(n => n.Any()).OrderByDescending(n => n).ToList().ForEach(n => Console.WriteLine($"{n.ToUpper()}"));
                    // All numbers
                    fancyNames.FilterBy(n => int.TryParse(n, out var num)).OrderByDescending(n => n).ToList().ForEach(n => Console.WriteLine($"{n}"));
                    // All even numbers
                    fancyNames.Where(n => int.TryParse(n, out var num)).OrderByDescending(n => n).ToList().ForEach(n => Console.WriteLine($"{n}"));
            }, "LIST FANCY NAMES");
        }
// 
        public static void Run_Fibonacci_Test()
        {
            Dictionary<int, ulong> m = new Dictionary<int, ulong>();
            for (int i = 0; i < 80; i++)
            {
                Console.WriteLine($"The #{i}-th fib number is = {Math.NthFibonacci(i, m)}");
            }
        }

        public static void Run_Hash_Test()
        {
            System.Console.Write($"Enter a phrase or word: ");
            string input = Console.ReadLine();

            if (!string.IsNullOrEmpty(input))
            {
                // MD5
                System.Console.WriteLine("MD5:".PadRight(6) + $"{Hash.MD5(input)}");
                // SHA1
                System.Console.WriteLine("SHA1:".PadRight(6) + $"{Hash.SHA1(input)}");
                // Encode (string -> byte array)
                var encoded = Hash.Encode(input);
                System.Console.WriteLine($"Encoded:");
                for (int ctr = 0; ctr < encoded.Length; ctr++)
                {
                    System.Console.Write("{0:X2}\t", encoded[ctr]);
                    if ((ctr+1) % 16 == 0)
                        System.Console.WriteLine();
                }
                // Decode (byte array -> string)
                var decoded = Hash.Decode(encoded);
                System.Console.WriteLine($"\nDecoded:\n{decoded}");
                // Encrypt
                var encrypted = Hash.Encrypt(Hash.Encode(input), "kfdkfd", "12345678");
                System.Console.WriteLine($"Encrypted:");
                for (int ctr = 0; ctr < encrypted.Length; ctr++)
                {
                    System.Console.Write("{0:X2}\t", encrypted[ctr]);
                    if ((ctr+1) % 16 == 0)
                        System.Console.WriteLine();
                }
                // Decrypt
                var decrypted = Hash.Decode(Hash.Decrypt(encrypted, "kfdkfd", "12345678"));
                System.Console.WriteLine($"\nDecrypted:\n{decrypted}");
            }

        }

        public static void Run_Menu_Test()
        {
            string title = "Files V4.6";
            string[] options = { "Play", "About", "Prefs", "Exit" };
            string prompt = "Select an option and hit ENTER\n";

            DOS.CreateMenu(prompt, options, title);
            int selectedIndex = DOS.RunMenu();

            while (selectedIndex != 3)
            {
                 switch (selectedIndex)
                 {
                    case 0:
                        Console.WriteLine("We're gonna play...");
                        Console.ReadKey(true);
                        break;
                    case 1:
                        Console.WriteLine("About this app\nPress the HOME key to coontinue...");
                        DOS.WaitForKey(ConsoleKey.Home);
                        break;
                    case 2:
                        Console.WriteLine("Setting Preferences...find the special key");
                        if (DOS.WaitForKey(ConsoleKey.H))
                        {
                            Console.WriteLine("You found the special H key");
                            Console.ReadKey(true);
                        }
                        break;
                     default:
                     break;
                 }
                selectedIndex = DOS.RunMenu();
            }

        }


   }
}