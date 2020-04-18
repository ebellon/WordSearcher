using Microsoft.Extensions.DependencyInjection;
using System;
using WordSearcher.Common;
using WordSearcher.Interfaces;

namespace WordSearcher
{
    public class Program 
    {
        // TODO: make it a program argument
        const string dirToLoad = @"c:\tmp";

        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            Console.WriteLine("Word Searcher\r");
            Console.WriteLine("------------------------\n");

            // Setup dependency injection
            using (var serviceProvider = ServicesProvider.SetupDI())
            {
                // Load directory
                var wordSearchManager = serviceProvider.GetRequiredService<IManageWordSearch>();

                try
                {
                    wordSearchManager.LoadDirectory(dirToLoad);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading directory {dirToLoad}: {ex.Message}");
                }

                // Search Logic here
                while (true)
                {
                    Console.Write("search>");
                    var pattern = Console.ReadLine();

                    try
                    {
                        wordSearchManager.SearchMatches(pattern);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error performing search {pattern} : {ex.Message}");
                    }
                }
            }
        }
    }
}
