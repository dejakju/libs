using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

namespace Kju
{
    class Run
    {

        static void Main(string[] args)
        {
            List<string> fancyNames = LoadFancyNames();

            Core.MeasureRuntime(() => {
                fancyNames.FilterBy(i => i.EndsWith("n")).ThenFilterBy(i => i.Contains("G")).ToList().ForEach(i => {
                    System.Console.WriteLine($"{i}");
                });
            }, "applying some filter methods to a list");

            Run_Memoization_Test();

        }

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

        private static void Run_Memoization_Test()
        {
            
            Dictionary<int, ulong> memo = new Dictionary<int, ulong>();
            Core.MeasureRuntime(() =>
            {
                Console.WriteLine($"From 50 <= x <= 75");
                for (var i = 50; i >= 50 && i <= 75; i++)
                {
                    Console.WriteLine($"The fib sequence number # {i} = {Math.NthFibonacci(i, memo)}");
                }
            }, "n-th Fibonacci sequence with MEMOIZATION");
        }

        


            //
            // LIST FANCY NAMES ###########################################################################################
            //
            // Core.MeasureRuntime(() =>
            // {
            //         // All items ordered ascending
            //         fancyNames.FilterBy(n => n.Any()).OrderBy(n => n).ToList().ForEach(n => Console.WriteLine($"{n}"));
            //         // All items UPPERCASE ordered descending
            //         fancyNames.FilterBy(n => n.Any()).OrderByDescending(n => n).ToList().ForEach(n => Console.WriteLine($"{n.ToUpper()}"));
            //         // All numbers
            //         fancyNames.FilterBy(n => int.TryParse(n, out var num)).OrderByDescending(n => n).ToList().ForEach(n => Console.WriteLine($"{n}"));
            //         // All even numbers
            //         fancyNames.Where(n => int.TryParse(n, out var num)).OrderByDescending(n => n).ToList().ForEach(n => Console.WriteLine($"{n}"));
            // }, "LIST FANCY NAMES");





            //
            // INSERT AUTOMATIC NODES #####################################################################################
            //
            // Core.MeasureRuntime(() =>
            // {
            //     for (int i = 0; i < 15; i++)
            //     {
            //         nodeList.Insert($"ObjectName{i}");
            //         System.Console.WriteLine($"Inserting Node # {i}: Data = ObjectName{i}");
            //     }
            //     System.Console.WriteLine($"Nodes: # {nodeList.GetLength()}");
            // }, "INSERT NODES");


            //
            // LIST ALL NODES #############################################################################################
            //
            // Core.MeasureRuntime(() =>
            // {
            //     if (nodeList.GetLength() > 0)
            //     {
            //         System.Console.WriteLine($"We got at least something!");
            //         System.Console.WriteLine($"Nodes: # {nodeList.GetLength()}");
            //         for (int i = 1; i < nodeList.GetLength(); i++)
            //         {
            //             Node currentNode = nodeList.GetNodeAt(i);
            //             System.Console.WriteLine($"Listing Node # {currentNode.GetHashCode().ToString()}: Data = {currentNode.getData().ToString()} (Next = {currentNode.getNextNode().GetHashCode().ToString()})");

            //             // ((string)currentNode.getData()).FilterBy(n => true).ToList().ForEach(n =>
            //             // {
            //             //     System.Console.WriteLine($"Listing Node # {n}: Data = {n.ToString()} (Next = {n.ToString()})");
            //             // });
            //         }
            //     }
            // }, "SELECT ALL NODES");

            // Core.MeasureRuntime(() => {
            //     if (nodes.IsEmpty())
            //     {
            //         System.Console.WriteLine($"Nodes list is empty!");
            //         return;
            //     }
            //     else
            //     {
            //         nodes.Items.Where(n => n.Next != null)
            //             .FilterBy(n => n.Data.ToString().Contains("7") || n.Data.ToString().Contains("55")).ToList().ForEach(n => {
            //                 System.Console.WriteLine($"Listing Node # {n.Data.ToString()}: Data = {n.Data.ToString()} (Next = {n.Next.Data.ToString()})");
            //             });
            //     }
            // }, "SELECT FILTERED NODES");



            // Core.MeasureRuntime(() =>
            // {
            //     nodes.Items.Where(n => n.Next != null).OrderBy(n => n.Data.ToString())
            //         .FilterBy(n => n.Data.ToString().EndsWith("2")).ToList().ForEach(n => {
            //             System.Console.WriteLine($"Listing Node # {n.Data.ToString()}: Data = {n.Data.ToString()} (Next = {n.Next.Data.ToString()})");
            //         });
            // }, "FILTER NODES THAT END WITH »2«");

            // Core.MeasureRuntime(() =>
            // {
            //     nodes.Items.Where(n => n.Next != null).OrderBy(n => n.Data.ToString())
            //         .FilterBy(n => n.Data.ToString().EndsWith("7") || n.Data.ToString().Contains("5")).ToList().ForEach(n => {
            //             System.Console.WriteLine($"Listing Node # {n.Data.ToString()}: Data = {n.Data.ToString()} (Next = {n.Next.Data.ToString()})");
            //         });
            // }, "FILTER NODES THAT END WITH »7« OR CONTAINS »5«");
    }
}
