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
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Item> Items { get; set; }
        public Command LoadItemsCommand { get; set; }
        public ItemsViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
            {
                var _item = item as Item;
                Items.Add(_item);
                await DataStore.AddItemAsync(_item);
            });

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
                    remiderService.Remind(item.Name , item.Notes, item.IntervalInMinutes, item.AudioFileName);
                }

            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
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
        }
    }
}