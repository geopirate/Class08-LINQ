using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace Lab08George
{
    public class JSONReader
    {
        static string filePath = @"data.json";
        string fileContents;

        // View words in the text file
        public RootObject ViewWords()
        {
            // read JSON directly from a file
            using (StreamReader file = File.OpenText(filePath))
            {
                fileContents = file.ReadLine();
            }
            //Console.WriteLine(fileContents);
            RootObject deserializedProduct = JsonConvert.DeserializeObject<RootObject> (fileContents);
            return deserializedProduct;
        }
    }
    // these classes represent the parts of the JSON object
    // The root of the JSON objects
    public class RootObject
    {
        public string type { get; set; }
        public List<Feature> features { get; set; }
    }
    // subcontainer within RootObject
    public class Feature
    {
        public string type { get; set; }
        public Geometry geometry { get; set; }
        public Properties properties { get; set; }
    }
    // information for the location
    public class Geometry
    {
        public string type { get; set; }
        public List<double> coordinates { get; set; }
    }
    // information about the property itself
    public class Properties
    {
        public string zip { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string address { get; set; }
        public string borough { get; set; }
        public string neighborhood { get; set; }
        public string county { get; set; }
    }
}
