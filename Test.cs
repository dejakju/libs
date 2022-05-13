using System;
using System.Collections.Generic;
using System.Linq;

namespace libs
{
    public static class Test
    {
        private static List<string> fancyNames = LoadFancyNames();

        public static void Run_Menu_Test()
        {
            string title = "TEST V4.6";
            string[] options = { "Hash/Encrypt algos", "Math related", "LINQ queries", "Prefs", "Exit" };
            string promptTest = @"
______________________ ____________________         _____       ______  
\__    ___/\_   _____//   _____/\__    ___/ ___  __/  |  |     /  __  \ 
  |    |    |    __)_ \_____  \   |    |    \  \/ /   |  |_    >      < 
  |    |    |        \/        \  |    |     \   /    ^   /   /   --   \
  |____|   /_______  /_______  /  |____|      \_/\____   | /\ \______  /
                   \/        \/                       |__| \/  v4.8  \/ 
";
            DOS.CreateMenu(promptTest, options, title);
            DOS.mMenuPrefix = " >> ";
            DOS.mMenuSuffix = " << ";
            int selectedIndex = DOS.SelectMenu();

            while (selectedIndex != (options.Length - 1))
            {
                 switch (selectedIndex)
                 {
                    case 0:
                        Run_Hash_Menu();
                        break;
                    case 1:
                        Run_Math_Menu();
                        break;
                    case 2:
                        Console.WriteLine("Invoking Fancy names test...\n");
                        Run_ListFancynames_Test();
                        break;
                    case 3:
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
                selectedIndex = DOS.SelectMenu();
            }

        }

        private static List<string> LoadFancyNames()
        {
           List<string> fancyNames = new List<string>() {
                "proton", "electron", "neutron", "pion", "photon", "neutrino", "muon", "graviton", "lepton",
                "One", "Two", "Three", "Four", "Fife", "Six", "Seven", "Eight", "Nine",
                "1st", "2nd", "3rd", "4th", "5th", "6th", "7th", "8th", "9th",
                "1", "2", "3", "4", "5", "6", "7", "8", "9",
                "Perseus", "Thor", "Superman", "Batman", "Lothain", "Adramelech", "Zeus", "Kju", "Goran", "Botabing", "Ares", "Your Mothers Face",
                "Battlestar Galactica", "Bird of Prey", "X-Wing", "Enterprise", "Defiand", "Tie Fighter", "Quadron Confinement", "Prometheus", "Warp Beacon",
                "11", "12", "13", "14", "21", "22", "23", "24", "31", "32", "33", "41", "42"
            };
            return fancyNames;
        }

        public static void Run_Fancynames_Test()
        {
            Core.MeasureRuntime(() => {
                fancyNames.FilterBy(i => i.EndsWith("n")).ThenFilterBy(i => i.Contains("G")).ToList().ForEach(i => {
                    DOS.WriteLine($"{i.ToUpper()}");
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
                    DOS.PressAnyKeyToContinue();
                    fancyNames.FilterBy(n => n.Any()).OrderByDescending(n => n).ToList().ForEach(n => Console.WriteLine($"{n.ToUpper()}"));
                    // All numbers
                    DOS.PressAnyKeyToContinue();
                    fancyNames.FilterBy(n => int.TryParse(n, out var num)).OrderByDescending(n => n).ToList().ForEach(n => Console.WriteLine($"{n}"));
                    // All even numbers
                    DOS.PressAnyKeyToContinue();
                    fancyNames.Where(n => int.TryParse(n, out var num)).OrderByDescending(n => n).ToList().ForEach(n => Console.WriteLine($"{n}"));
            }, "LIST FANCY NAMES");
        }

        public static void Run_Math_Menu()
        {
            string title = "Math Menu v2.71";
            string[] options = { "Find n-th position of a Fibonacci sequence", "Exit" };
            string promptMath = @"
                __  .__     
  _____ _____ _/  |_|  |__  
 /     \\__  \\   __\  |  \ 
|  Y Y  \/ __ \|  | |   Y  \
|__|_|  (____  /__| |___|  /
      \/     \/          \/ V3.14
";

            DOS.CreateMenu(promptMath, options, title);
            DOS.mMenuPrefix = " ** ";
            DOS.mMenuSuffix = " ** ";
            int selectedIndex = DOS.SelectMenu();

            while (selectedIndex != (options.Length - 1))
            {
                 switch (selectedIndex)
                 {
                    case 0:
                        Run_Fibonacci_Test();
                        break;
                    default:
                        break;
                 }
                selectedIndex = DOS.SelectMenu();
            }

            // Invoke Main Menu
            Run_Menu_Test(); 
        }

        public static void Run_Fibonacci_Test()
        {

            Dictionary<int, ulong> m = new Dictionary<int, ulong>();

            System.Console.Write($"Enter a positive integer between 1 and 79: ");
            string input = Console.ReadLine();
            int number = 0;

            if (!string.IsNullOrEmpty(input))
            {
                input = input.Trim();

                if (int.TryParse(input, out number) && number is > 0 and < 80)
                {
                    for (int i = 0; i < number + 1; i++)
                    {
                        Console.Write($"The #{i:00}-th fib number is = ");
                        Console.WriteLine($"{Math.NthFibonacci(i, m)}".PadLeft(17, ' '));
                    }
                }
                else if (int.TryParse(input, out number) && number is 0)
                {
                    throw new DOSException("0 is not in between 1 and 79!", new Exception(DOSCode.ERROR_BAD_NUMBER.ToString()));
                }
                else if (int.TryParse(input, out number) && number is >= 80)
                {
                    throw new DOSException($"'{input}' is greater than 79!", new Exception(DOSCode.ERROR_BAD_NUMBER.ToString()));
                }
                else if (int.TryParse(input, out number) && number is < 0)
                {
                    throw new DOSException($"'{input}' is not a positive integer!", new Exception(DOSCode.ERROR_BAD_NUMBER.ToString()));
                }
                else
                {
                    throw new DOSException($"'{input}' is not a valid integer!", new Exception(DOSCode.ERROR_BAD_NUMBER.ToString()));
                }
            }
            else
            {
                throw new DOSException($"No input, no action!", new Exception(DOSCode.ERROR_ACTION_NOT_KNOWN.ToString()));
            }
        }

        public static void Run_Hash_Menu()
        {
            string title = "Hash V4.6";
            string[] options = { "MD5", "SHA1", "BYTE ENCODE", "TRIPPLE DES", "ALL ABOVE", "Exit" };
            string prompt = @"
  ___ ___               .__      
 /   |   \_____    _____|  |__   
/    ~    \__  \  /  ___/  |  \  
\    Y    // __ \_\___ \|   Y  \ 
 \___|_  /(____  /____  >___|  / 
       \/      \/     \/     \/  V4.6
";

            DOS.CreateMenu(prompt, options, title);
            DOS.mMenuPrefix = " ** ";
            DOS.mMenuSuffix = " ** ";
            int selectedIndex = DOS.SelectMenu();

            while (selectedIndex != (options.Length - 1))
            {
                 switch (selectedIndex)
                 {
                    case 0:
                        Run_Hash_MD5_Test();
                        DOS.PressAnyKeyToContinue();
                        break;
                    case 1:
                        Run_Hash_SHA1_Test();
                        DOS.PressAnyKeyToContinue();
                        break;
                    case 2:
                        Run_Hash_ByteEncoding_Test();
                        DOS.PressAnyKeyToContinue();
                        break;
                    case 3:
                        Run_Hash_TrippleDes_Test();
                        DOS.PressAnyKeyToContinue();
                        break;
                    case 4:
                        Run_Hash_Test_All();
                        DOS.PressAnyKeyToContinue();
                        break;
                    default:
                        break;
                 }
                selectedIndex = DOS.SelectMenu();
            }

            Run_Menu_Test(); 
        }

        public static void Run_Hash_MD5_Test()
        {
            DOS.Write($"Enter a phrase or word: ");
            string input = Console.ReadLine();

            if (!string.IsNullOrEmpty(input))
                DOS.WriteLine("MD5:".PadRight(6) + $"{Hash.MD5(input)}");
        }

        public static void Run_Hash_SHA1_Test()
        {
            DOS.Write($"Enter a phrase or word: ");
            string input = Console.ReadLine();

            if (!string.IsNullOrEmpty(input))
                DOS.WriteLine("SHA1:".PadRight(6) + $"{Hash.SHA1(input)}");
        }

        public static void Run_Hash_ByteEncoding_Test()
        {
            DOS.Write($"Enter a phrase or word: ");
            string input = Console.ReadLine();
            var encoded = Hash.Encode(input);
            DOS.WriteLine($"Encoded:");

            for (int ctr = 0; ctr < encoded.Length; ctr++)
            {
                DOS.Write("{0:X2}\t", encoded[ctr]);
                if ((ctr+1) % 16 == 0)
                    DOS.NewLine();
            }

            var decoded = Hash.Decode(encoded);
            DOS.WriteLine($"\nDecoded:\n{decoded}");
        }

        public static void Run_Hash_TrippleDes_Test()
        {
            DOS.Write($"Enter a phrase or word: ");
            string input = Console.ReadLine();
            var encrypted = Hash.Encrypt(Hash.Encode(input), "abc", "12345678");
            DOS.WriteLine($"Encrypted:");

            for (int ctr = 0; ctr < encrypted.Length; ctr++)
            {
                DOS.Write("{0:X2}\t", encrypted[ctr]);
                if ((ctr+1) % 16 == 0)
                    DOS.NewLine();
            }

            var decrypted = Hash.Decode(Hash.Decrypt(encrypted, "abc", "12345678"));
            DOS.WriteLine($"\nDecrypted:\n{decrypted}");
        }

        public static void Run_Hash_Test_All()
        {
            DOS.Write($"Enter a phrase or word: ");
            string input = Console.ReadLine();

        }



   }
}