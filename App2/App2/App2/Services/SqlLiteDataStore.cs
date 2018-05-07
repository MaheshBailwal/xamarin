using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using App2.Models;
using SQLite.Net;

[assembly: Xamarin.Forms.Dependency(typeof(App2.Services.SqlLiteDataStore))]
namespace App2.Services
{
    public class SqlLiteDataStore : IDataStore<Item>
    {
        List<Item> items;

        static object locker = new object();

        static SQLiteConnection database;
        SqlLiteDataStore db;
        public SqlLiteDataStore()
        {

           var sqliteFilename = "ServiceReminder.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
            var path = Path.Combine(documentsPath, sqliteFilename);

            var plat = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();

            database = new SQLiteConnection(plat, path);

            database.CreateTable<Item>();

            // create the tables
          
        }
        public async Task<bool> UpSertAsync(Item item)
        {
            lock (locker)
            {
                database.InsertOrReplace(item);
            }

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(Item item)
        {
            var _item = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
     
            return database.Table<Item>().FirstOrDefault(s => s.Id == int.Parse(id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return database.Table<Item>();
            //return await Task.FromResult(items);
        }
    }
}