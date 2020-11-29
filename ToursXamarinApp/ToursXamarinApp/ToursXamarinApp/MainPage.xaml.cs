using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ToursXamarinApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            LstVwHotels.ItemsSource = DataBase.TourBaseEntities.GetContext().Hotels.ToList();
        }

        private void LstVwHotels_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}
