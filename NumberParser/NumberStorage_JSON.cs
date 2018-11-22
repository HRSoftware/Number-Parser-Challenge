using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberParser
{
    class NumberStorage_JSON : INumberStorage
    {
     

        private struct JsonObject
        {
            [JsonProperty("Number")]
            public int Number { get; set; }
        }

        void INumberStorage.saveToFile(List<int> in_Numbers)
        {
            StreamWriter jsonFile = File.CreateText("numbersOut.json");         //create a new file to write to

            JsonObject tempJsonObject = new JsonObject();        //create new JsonObject

            foreach (int number in in_Numbers)
            {

                tempJsonObject.Number = number;     //set the Json "Number" property
                jsonFile.WriteLine(JsonConvert.SerializeObject(tempJsonObject, Newtonsoft.Json.Formatting.Indented)); //Write to file
            }

            jsonFile.Close();
        }
        

    }
}
