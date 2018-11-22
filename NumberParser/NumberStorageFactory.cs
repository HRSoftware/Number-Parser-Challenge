using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberParser
{
    class NumberStorageFactory
    {

        public INumberStorage createNewNumberStorage(string fileFormat)
        {
            
            if(fileFormat.ToLower() == "json")
            {
                return new NumberStorage_JSON();
            }
            else if(fileFormat.ToLower() == "xml")
            {
                return new NumberStorage_XML();
            }
            else if(fileFormat.ToLower() == "txt")
            {
                return new NumberStorage_TXT();
            }

            Console.WriteLine("File format " + fileFormat + ". Not supported");
            return null;
            
        }
    }
}
