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
            NumberStorageFactory factory = new NumberStorageFactory();


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

            var numberStorage = factory.createNewNumberStorage(ext);
            numberStorage.saveToFile(numbersParsed);
           
            
        }



     

    }
}
