using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace NumberParser
{
    class NumberStorage_XML : INumberStorage
    {



        void INumberStorage.saveToFile(List<int> in_Numbers)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;                                     //settings for formatting
            settings.NewLineOnAttributes = true;


            XmlWriter xmlFile = XmlWriter.Create("numbersOut.xml", settings);       //create new file to write to

            xmlFile.WriteStartDocument();
            xmlFile.WriteStartElement("numbers");

            foreach (int item in in_Numbers)
            {
                xmlFile.WriteElementString("number", item.ToString());
            }

            xmlFile.WriteEndElement();
            xmlFile.WriteEndDocument();

            xmlFile.Close();
        }
        

    }
}
