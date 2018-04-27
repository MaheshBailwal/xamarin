using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace App2
{
    public class DataSetReader
    {
        public void Read()
        {
            var documents =
 Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var filename = Path.Combine(documents, "Write123.txt");
            File.WriteAllText(filename, "Write this text into a file");

            //DataSet dst = new DataSet();
            //dst.ReadXml()
        }
    }
}
