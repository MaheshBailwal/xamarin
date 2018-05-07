using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using App2.Models;

[assembly: Xamarin.Forms.Dependency(typeof(App2.Services.MockDataStore))]
namespace App2.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>();
            var mockItems = new List<Item>
            {
                new Item { Id = 1, Name = "One", IsReminderEnabled = true, VerbirationDuration=2, Notes="Notes of reminder" + Environment.NewLine + "1. One thing is to be what the" +  Environment.NewLine + "2. Two thing is to be what the"
                , IntervalInMinutes=1},
                new Item { Id = 2, Name = "Two", IsReminderEnabled = true, VerbirationDuration=2,Notes="Notes of reminder", IntervalInMinutes=1}
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> UpSertAsync(Item item)
        {
            var _item = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            if (_item != null)
            {
                items.Remove(_item);
            }
            items.Add(item);

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
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == int.Parse(id)));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}