using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using App2.Models;
using System.Threading.Tasks;
using App2.ViewModels;

namespace App2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        ItemViewModel viewModel;

        public NewItemPage()
        {
            InitializeComponent();


            Item = new Item
            {
                Name = "new reminder",
                Notes = "your notes"
            };

            viewModel = new ItemViewModel();

            Item = viewModel.ExecuteLoadItem().Result;

            BindingContext = this;

        }

        public NewItemPage(Item item)
        {
            InitializeComponent();
            this.Item = item;
            BindingContext = this;
        }


        void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "Upsert", Item);
            var messages = DependencyService.Get<IMessages>();
            messages.ShowBlinkMesage( "Data updated sucessfully");
            //await Navigation.PopModalAsync();
        }
    }
}