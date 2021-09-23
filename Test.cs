using System;
using System.Collections.Generic;
using System.Linq;

namespace Kju
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
                "Perseus", "Thor", "Superman", "Batman", "Lothain", "Adramelech", "Zeus", "Kju", "Goran",
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

            // Run_Memoization_Test();
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


   }
}