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
            JSONReader reader = new JSONReader();
            RootObject ourHoods =  reader.ViewWords();

            //Output all of the neighborhoods in this data list
            /*IEnumerable<RootObject> allQuery = from features in ourHoods.features.
                           select features;*/

            //Filter out all the neighborhoods that do not have any names
            //Remove the Duplicates
            //Rewrite the queries from above, and consolidate all into one single query.

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
 * Output all of the neighborhoods in this data list
 * Filter out all the neighborhoods that do not have any names
 * Remove the Duplicates
 * Rewrite the queries from above, and consolidate all into one single query.
 * Rewrite at least one of these questions only using a LINQ query(without lambda statement)
 */