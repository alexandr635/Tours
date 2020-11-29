using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataBase;

namespace ToursApplication.Pages
{
    /// <summary>
    /// Interaction logic for AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private Hotel currentHotel = new Hotel();
        public AddEditPage(Hotel selectedHotel)
        {
            InitializeComponent();

            if (selectedHotel != null)
                currentHotel = selectedHotel;

            DataContext = currentHotel;
            CountriesCmbBx.ItemsSource = Logic.QueryDB.GetContext().Countries.ToList();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(currentHotel.Name))
                errors.AppendLine("Укажите название отеля");
            if (currentHotel.CountOfStars > 5 || currentHotel.CountOfStars < 1)
                errors.AppendLine("Количество звезд - число от 1 до 5");
            if (currentHotel.Country == null)
                errors.AppendLine("Введите страну");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (currentHotel.Id == 0)
            {
                Exception exception = Logic.QueryDB.AddHotel(currentHotel);
                if (exception == null)
                {
                    MessageBox.Show("Информация сохранена!");
                    Logic.Manager.MainFrame.GoBack();
                }
                else
                    MessageBox.Show(exception.Message);
            }
            else
            {
                Exception exception = Logic.QueryDB.EditHotel(currentHotel);
                if (exception == null)
                {
                    MessageBox.Show("Информация обновлена!");
                    Logic.Manager.MainFrame.GoBack();
                }
                else
                    MessageBox.Show(exception.Message);
            }
        }
    }
}
