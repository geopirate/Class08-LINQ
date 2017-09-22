using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab08George
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the neighborhood!");
            Console.WriteLine();
            // I use the JSON reader class to read from the file and return the object I need
            JSONReader reader = new JSONReader();
            RootObject ourHoods =  reader.ViewWords();

            // Output all of the neighborhoods in this data list
            // orderby puts all the empties at the top
            var allQuery = from features in ourHoods.features
                           select features;
            Console.WriteLine("Output all of the neighborhoods in this data list");
            Console.WriteLine();
            foreach (Feature hood in allQuery)
            {
                Console.Write($"{hood.properties.neighborhood}  ");
            }

            // Filter out all the neighborhoods that do not have any names
            // Rewrite at least one of these questions only using a LINQ query(without lambda statement)
            // no lambda version of the query directly below
            /*var removeQuery = from features in ourHoods.features
                              where features.properties.neighborhood != ""
                              orderby features.properties.neighborhood
                              select features;*/

            var removeQuery = ourHoods.features.Where(x => x.properties.neighborhood != "");
            Console.WriteLine(); Console.WriteLine();
            Console.WriteLine("Filter out all the neighborhoods that do not have any names");
            Console.WriteLine();
            foreach (Feature hood in removeQuery)
            {
                Console.Write($"{hood.properties.neighborhood}  ");
            }

            // Remove the Duplicates
            // the empty is between east village and tribeca
            var duplicateQuery = ourHoods.features.GroupBy(x => x.properties.neighborhood).Select(x => x.First());
            Console.WriteLine(); Console.WriteLine();
            Console.WriteLine("Remove the Duplicates");
            Console.WriteLine();
            foreach (Feature hood in duplicateQuery)
            {
                Console.Write($"{hood.properties.neighborhood}  ");
            }

            // Rewrite the queries from above, and consolidate all into one single query.
            var combinedQuery = ourHoods.features.Where(x => x.properties.neighborhood != "").GroupBy(x => x.properties.neighborhood).Select(x => x.First());
            Console.WriteLine(); Console.WriteLine();
            Console.WriteLine("All together now!");
            Console.WriteLine();
            foreach (Feature hood in combinedQuery)
            {
                Console.Write($"{hood.properties.neighborhood}  ");
            }
            Console.Read();
        }
    }
}
/*
 * * Provided is a JSON file that contains a data set of location information for properties in Manhatten.
 * * Read in the file and answer the questions below
 * Use LINQ queries and Lambda statements(when appropriate) to find the answers.
 * Setup
 * * Add the data.json file to your solution root folder
 * * Explore the NuGet packages and install NewtonSoftJson
 * * Do some self research (prev.labs count too) and find out how to read in JSON file(hint: JsonConvert.DeserializedOject is part of it)
 * * You will need to break up each section of the JSON file up into different classes, use your resources - ask the TA's if your stuck.
 * 
 * Each query builds off of the next.
 * * Output all of the neighborhoods in this data list
 * * Filter out all the neighborhoods that do not have any names
 * * Remove the Duplicates
 * * Rewrite the queries from above, and consolidate all into one single query.
 * * Rewrite at least one of these questions only using a LINQ query(without lambda statement)
 */