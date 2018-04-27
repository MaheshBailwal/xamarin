using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using App2.Models;

namespace App2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();

            Item = new Item
            {
                Name = "new reminder",
                Notes = "your notes"
            };

            BindingContext = this;
        }

        public NewItemPage(Item item)
        {
            InitializeComponent();
            this.Item = item;
            BindingContext = this;
        }


        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "Upsert", Item);
            await Navigation.PopModalAsync();
        }
    }
}