using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberParser
{
    public class JsonObject
    {
        [JsonProperty("Number")]
        public int Number { get; set; }
    }

    class JsonObjectFactory
    {

        public JsonObject createNewJsonObject()
        {
            return new JsonObject();
        }
    }
}
