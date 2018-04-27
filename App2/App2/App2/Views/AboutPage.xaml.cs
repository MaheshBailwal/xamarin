
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AboutPage : ContentPage
	{
		public AboutPage ()
		{
			InitializeComponent ();

            //Image img = new Image();
            //img.Source = ImageSource.FromUri(new Uri("http://180.151.85.74/public/FOA-Wholesale/FOA-CM7702F.jpg"));
            //img.HeightRequest = 100;
            //img.WidthRequest = 100;

            productImage.Source = ImageSource.FromUri(new Uri("http://180.151.85.74/public/FOA-Wholesale/FOA-CM7702F.jpg"));
            productImage.HeightRequest = 300;
            productImage.WidthRequest = 300;

         //   btnNext.Clicked += BtnNext_Clicked;

          //  stack1.Children.Add(img);
		}

        private void BtnNext_Clicked(object sender, EventArgs e)
        {
            App2.Models.DataSetReader dataSetReader = new Models.DataSetReader();
        //    dataSetReader.Read();
            productImage.Source = ImageSource.FromUri(new Uri("http://180.151.85.74/public/FOA-Wholesale/FOA-CM6814RD-SF.jpg"));
        }

        private void Privous_Clicked(object sender, EventArgs e)
        {
            productImage.Source = ImageSource.FromUri(new Uri("http://180.151.85.74/public/FOA-Wholesale/FOA-CM-DK6252DO.jpg"));
        }

        private void Reminder_Clicked(object sender, EventArgs e)
        {
            var remiderService = DependencyService.Get<IReminderService>();
            remiderService.ShowAlert("sd");
        }

      
    }
}