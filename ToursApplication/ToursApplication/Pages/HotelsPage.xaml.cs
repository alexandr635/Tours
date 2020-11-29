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

namespace ToursApplication.Pages
{
    /// <summary>
    /// Interaction logic for HotelsPage.xaml
    /// </summary>
    public partial class HotelsPage : Page
    {
        public HotelsPage()
        {
            InitializeComponent();
        }

        private void HotelsBtn_Click(object sender, RoutedEventArgs e)
        {
            //Logic.Manager.MainFrame.Navigate(new AddEditPage());
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            Logic.Manager.MainFrame.Navigate(new AddEditPage((sender as Button).DataContext as DataBase.Hotel));
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Logic.Manager.MainFrame.Navigate(new AddEditPage(null));
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var hotelsForRemoving = DtGridHotels.SelectedItems.Cast<DataBase.Hotel>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {hotelsForRemoving.Count()} элементов?", 
                "Внимание", MessageBoxButton.YesNoCancel) == MessageBoxResult.Yes)
            {
                Exception exception = Logic.QueryDB.DeleteHotel(hotelsForRemoving);
                if (exception == null)
                {
                    MessageBox.Show("Данные удалены!");
                    DtGridHotels.ItemsSource = DataBase.TourBaseEntities.GetContext().Hotels.ToList();
                }
                else
                    MessageBox.Show(exception.Message);
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                DataBase.TourBaseEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DtGridHotels.ItemsSource = DataBase.TourBaseEntities.GetContext().Hotels.ToList();
            }
        }
    }
}
