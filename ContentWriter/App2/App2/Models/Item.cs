using System;
using System.Data;
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
        public DataTable Read()
        {


            var path = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
            var filename = Path.Combine(path.ToString(), "myfile.txt");

            File.WriteAllText(filename, "Write this text into a file");



            var directory = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads);


            var file = System.IO.Path.Combine(directory.AbsolutePath, "100.XML");

            DataSet dst = new DataSet();
            dst.ReadXml(file);
           return dst.Tables[0];
        }
    }

}