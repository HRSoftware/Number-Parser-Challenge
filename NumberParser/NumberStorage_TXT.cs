using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberParser
{
    class NumberStorage_TXT : INumberStorage
    {

        void INumberStorage.saveToFile(List<int> in_Numbers )
        {
            StreamWriter txtFile = new StreamWriter("numbersOut.txt");

            foreach (int number in in_Numbers)
            {
                txtFile.WriteLine(number);      //simple text file
            }

            txtFile.Close();
        }
        

    }
}
