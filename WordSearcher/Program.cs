using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using WordSearcher.Common;
using WordSearcher.Interfaces;

namespace WordSearcher
{
    public class Program 
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            Console.WriteLine("Word Searcher\r");
            Console.WriteLine("------------------------\n");

            var dirToLoad = @"c:\tmp";
            if(args.Length != 1)
            {
                Console.WriteLine("Path not provided! Usage: WordSearcher.exe 'Folder' ");
                Environment.Exit(-1);
            }

            // Setup dependency injection
            using (var serviceProvider = ServicesProvider.SetupDI())
            {
                // Load directory
                var wordSearchManager = serviceProvider.GetRequiredService<IManageWordSearch>();

                try
                {
                    var fileNumber = wordSearchManager.LoadDirectory(dirToLoad);
                    Console.WriteLine($"There are {fileNumber} in {dirToLoad}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading directory {dirToLoad}: {ex.Message}");
                    Environment.Exit(-1);
                }

                // Search Logic here
                while (true)
                {
                    Console.Write("search>");
                    var pattern = Console.ReadLine();

                    try
                    {
                        var topTen = wordSearchManager.SearchMatches(pattern);
                        topTen.ToList().ForEach((kvp) => Console.WriteLine($"file {kvp.Key} : {kvp.Value} ocurrences"));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error performing search {pattern} : {ex.Message}");
                        Environment.Exit(-1);
                    }
                }
            }
        }
    }
}
