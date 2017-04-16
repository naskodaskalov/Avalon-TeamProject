using Avalon.Models;
using Avalon.Service;
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
using System.Windows.Shapes;

namespace Avalon.Client
{
    /// <summary>
    /// Interaction logic for SearchEditBeerWin.xaml
    /// </summary>
    public partial class SearchEditBeerWin : Window
    {
        public SearchEditBeerWin()
        {
            InitializeComponent();
            beersDatagrid.DataContext = BeerService.GetAllBeers();

        }


        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            EditBeerWin editBeerWin = new EditBeerWin(this.beersDatagrid.SelectedItem as Beer);
            this.Close();
            editBeerWin.Show();
            

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            string beerName = (this.beersDatagrid.SelectedItem as Beer).Name;

            BeerService.DeleteBeer(beerName);
            beersDatagrid.DataContext = BeerService.GetAllBeers();


        }


        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string beerName = SearchTextBox.Text.Trim();

            if (beerName == null || beerName.Length == 0)
            {
                WarningLabel.Visibility = Visibility.Visible;
                WarningLabel.Content = "Beer name cannot be empty.";
                return;
            }

            beersDatagrid.DataContext = BeerService.GetBeersByName(beerName);

        }
    }
}
