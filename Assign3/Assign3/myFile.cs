using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign3
{
    class myFile
    {       
        static string path = @"C:\Users\Victor\Documents\output.txt";

        

        public void writeToFile(string input)
        {
            try
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(input);
                    sw.Close();
                }
            }
            catch (IOException) { }
            

        }
    }
}
