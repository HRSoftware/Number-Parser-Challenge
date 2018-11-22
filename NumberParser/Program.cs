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

   

    class Program
    {
        private static void Main(string[] args)
        {

            List<int> numbersParsed = new List<int>();  //Hold individual numbers
           

            string[] numbersEntered = args[0].Split(",".ToCharArray());     //split the string at the commas
            string ext = args[1];      


            for(int i = 0; i < numbersEntered.Length; i++)
            { 
                int tempNum;            //tempory var to hold result of TryParse

                if ((Int32.TryParse(numbersEntered[i], out tempNum)))     
                {
                    numbersParsed.Add(tempNum);                 //add it to the list if it is an Int
                }
                else
                {
                    Console.WriteLine("Could not parse " + tempNum + ". Please ensure it is a number and not a letter");
                }  
            }

            numbersParsed = numbersParsed.OrderByDescending(i => i).ToList();   //sort list into descending order

            
            //call relevant function based on file format provided
            if(ext== "xml")
            {
                writeToXml(numbersParsed);
            }
            else if(ext == "json")
            {
                writeToJson(numbersParsed);
            }
            else if(ext == "txt")
            {
                writeToTxt(numbersParsed);
            }
            else
            {
                Console.WriteLine("File extension: " + ext + " is not supported. Supported formats = .Xml, .Json or .Txt");
            }
            
        }



      private static void writeToXml(List<int> numbers)
        {
            XmlWriterSettings settings = new XmlWriterSettings();      
            settings.Indent = true;                                     //settings for formatting
            settings.NewLineOnAttributes = true;

            
            XmlWriter xmlFile = XmlWriter.Create("numbersOut.xml", settings);       //create new file to write to

            xmlFile.WriteStartDocument();
            xmlFile.WriteStartElement("numbers");   

            foreach (int item in numbers)
            {
                xmlFile.WriteElementString("number", item.ToString());
            }

            xmlFile.WriteEndElement();
            xmlFile.WriteEndDocument();

            xmlFile.Close();
        }

        private static void writeToTxt(List<int> numbers)
        {
            StreamWriter txtFile = new StreamWriter("numbersOut.txt");

            foreach(int number in numbers)
            {
                txtFile.WriteLine(number);      //simple text file
            }

            txtFile.Close();
        }

       private static void writeToJson(List<int> numbers)
        {

            JsonObjectFactory JOFactory = new JsonObjectFactory();              //Factory class to create new JsonObject


            StreamWriter jsonFile = File.CreateText("numbersOut.json");         //create a new file to write to

            JsonObject tempJsonObject = JOFactory.createNewJsonObject();        //create new JsonObject
           
            foreach(int number in numbers)
            {

                tempJsonObject.Number = number;     //set the Json "Number" property
                jsonFile.WriteLine(JsonConvert.SerializeObject(tempJsonObject, Newtonsoft.Json.Formatting.Indented)); //Write to file
            }

            jsonFile.Close();
        }
    }
}
