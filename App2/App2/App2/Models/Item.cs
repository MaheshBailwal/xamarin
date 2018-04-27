using System;
using System.IO;
using Xamarin.Forms.PlatformConfiguration;

namespace App2.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsReminderEnabled { get; set; }
        public string Notes { get; set; }
        public int IntervalInMinutes { get; set; }

        public string AudioFileName { get; set; }
    }

    public class DataSetReader
    {
 //       public void Read()
 //       {

 //           var pathFile = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads);
 //           var absolutePath = pathFile.AbsolutePath;

 //           var documents =
 //Environment.GetFolderPath(Environment.SpecialFolder.Personal);
 //        //   var filename = Path.Combine(absolutePath, "Write123.txt");


 //           var path = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
 //           var filename = Path.Combine(path.ToString(), "myfile.txt");

 //           File.WriteAllText(filename, "Write this text into a file");

 //           //DataSet dst = new DataSet();
 //           //dst.ReadXml()
 //       }
    }
}