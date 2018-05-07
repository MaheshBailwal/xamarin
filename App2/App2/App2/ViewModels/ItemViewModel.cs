using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using App2.Models;
using App2.Views;
using System.Linq;

namespace App2.ViewModels
{
    public class ItemViewModel : BaseViewModel
    {
        public ObservableCollection<Item> Items { get; set; }
        public Command LoadItemsCommand { get; set; }
        public ItemViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<Item>();
           // LoadItemsCommand = new Command(async () => await ExecuteLoadItemCommand());


            MessagingCenter.Subscribe<NewItemPage, Item>(this, "Upsert", async (obj, item) =>
            {
                var _item = item as Item;
                var _item12 = Items.Where ((Item arg) => arg.Id == item.Id).FirstOrDefault();
                if (_item12 != null)
                {
                    Items.Remove (_item12);
                }

                Items.Add(_item);
                await DataStore.UpSertAsync(_item);

                var remiderService = DependencyService.Get<IReminderService>();
                if (item.IsReminderEnabled)
                {
                    remiderService.Remind(item);
                }

            });
        }

      public async Task<Item> ExecuteLoadItem()
        {
           
            try
            {
                Items.Clear();
                var item = await DataStore.GetItemAsync("0");

                var items = await DataStore.GetItemsAsync();

                foreach(var it in items)
                {
                    var tt = it;
                }


                if (item != null)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }

            return await Task.FromResult(Items.FirstOrDefault());
        }
    }
}