
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

            App2.Models.DataSetReader dataSetReader = new Models.DataSetReader();
            dataTable = dataSetReader.Read();
            AddButtons();

            var pinchGestureRecognizer = new PanGestureRecognizer();
            pinchGestureRecognizer.PanUpdated += PinchGestureRecognizer_PanUpdated;

            productImage.GestureRecognizers.Add(pinchGestureRecognizer);
        }

        private void PinchGestureRecognizer_PanUpdated(object sender, PanUpdatedEventArgs e)
        {
            if (e.TotalX < 0)
            {
                Next();
            }
            else if (e.TotalX > 0)
            {
                Privous();
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

        private void Next()
        {
            if (dataTable.Rows.Count > (rowIndex + 1) )
                rowIndex++;

            ShowImage();
        }

        private void Privous()
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

        private void Reminder_Clicked(object sender, EventArgs e)
        {
            var remiderService = DependencyService.Get<IReminderService>();
            remiderService.ShowAlert("sd");
        }


    }
}