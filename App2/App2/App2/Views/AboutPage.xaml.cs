
using System;
using System.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ContentPage
    {
        int rowIndex;
        DataTable dataTable;
        public AboutPage()
        {
            InitializeComponent();

            //Image img = new Image();
            //img.Source = ImageSource.FromUri(new Uri("http://180.151.85.74/public/FOA-Wholesale/FOA-CM7702F.jpg"));
            //img.HeightRequest = 100;
            //img.WidthRequest = 100;

            productImage.Source = ImageSource.FromUri(new Uri("http://180.151.85.74/public/FOA-Wholesale/FOA-CM7702F.jpg"));
            productImage.HeightRequest = 300;
            productImage.WidthRequest = 300;

            App2.Models.DataSetReader dataSetReader = new Models.DataSetReader();
            dataTable = dataSetReader.Read();
            AddButtons();

            var pinchGestureRecognizer = new PanGestureRecognizer();
            pinchGestureRecognizer.PanUpdated += PinchGestureRecognizer_PanUpdated;

            productImage.GestureRecognizers.Add(pinchGestureRecognizer);
        }

        private void PinchGestureRecognizer_PanUpdated(object sender, PanUpdatedEventArgs e)
        {
            if(e.TotalX < 0)
            {
                BtnNext_Clicked(null, null);
            }
            else if(e.TotalX > 0)
            {
                Privous_Clicked(null, null);
            }
        }

        private void AddButtons()
        {

            foreach (DataColumn col in dataTable.Columns)
            {
                Button btn = new Button();
                btn.Text = col.ColumnName;
                btn.Clicked += Btn_Clicked;
                mainStackLayout.Children.Add(btn);
            }
        }

        private void Btn_Clicked(object sender, EventArgs e)
        {
            var fieldName = ((Button)sender).Text;
            txtEditor.Text = dataTable.Rows[rowIndex][fieldName].ToString();
        }

        private void BtnNext_Clicked(object sender, EventArgs e)
        {
            
            rowIndex++;
            //productImage.Source = ImageSource.FromUri(new Uri(imageUrl));

            //            productImage.Source = ImageSource.FromUri(new Uri("http://180.151.85.74/public/FOA-Wholesale/FOA-CM6814RD-SF.jpg"));
            ShowImage();
        }

        private void Privous_Clicked(object sender, EventArgs e)
        {
            //  productImage.Source = ImageSource.FromUri(new Uri("http://180.151.85.74/public/FOA-Wholesale/FOA-CM-DK6252DO.jpg"));
            if (rowIndex > 0)
                rowIndex--;
            ShowImage();
        }


        private void ShowImage()
        {
            var imageUrl = dataTable.Rows[rowIndex]["URL"].ToString();
            productImage.Source = ImageSource.FromUri(new Uri(imageUrl));
        }

        private void Reminder_Clicked(object sender, EventArgs e)
        {
            var remiderService = DependencyService.Get<IReminderService>();
            remiderService.ShowAlert("sd");
        }


    }
}