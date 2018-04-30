
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

      
            productImage.Source = ImageSource.FromUri(new Uri("http://180.151.85.74/public/FOA-Wholesale/FOA-CM7702F.jpg"));
            productImage.HeightRequest = 300;
            productImage.WidthRequest = 300;

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

     
        private void Btn_Clicked(object sender, EventArgs e)
        {
            var fieldName = ((Button)sender).Text;
            txtEditor.Text = dataTable.Rows[rowIndex][fieldName].ToString();
        }

        private void BtnNext_Clicked(object sender, EventArgs e)
        {
            
            rowIndex++;
            ShowImage();
        }

        private void Privous_Clicked(object sender, EventArgs e)
        {
            if (rowIndex > 0)
                rowIndex--;
            ShowImage();
        }


        private void ShowImage()
        {
            var imageUrl = dataTable.Rows[rowIndex]["URL"].ToString();
            productImage.Source = ImageSource.FromUri(new Uri(imageUrl));
        }

    }
}