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
    /// Interaction logic for AddDistributorWindow.xaml
    /// </summary>
    public partial class AddDistributorWindow : Window
    {
        public AddDistributorWindow()
        {
            InitializeComponent();

            //hard-coded data for testing
            var brew = new Brewery() { Name = "Brewery1" };
            var brewList = new List<Brewery>();
            brewList.Add(brew);
            this.breweriesList.ItemsSource = brewList;
            var newDistributor = new Distributor();
            this.DataContext = newDistributor;
        }


        private void CommonMenuClickHandler(object sender, RoutedEventArgs e)
        {
            FrameworkElement feSource = e.Source as FrameworkElement;
            switch (feSource.Name)
            {
                case "AddClient":
                case "AddClientBtn":

                    // do something here ...
                    this.Hide();
                    AddClient addClientWin = new AddClient();
                    addClientWin.Show();
                    break;
                case "AddDistributor":
                    // do something here ...
                    break;
                case "AddBeer":
                case "AddBeerBtn":

                    // do something ...
                    break;
                case "AddBrewery":
                    // do something ...
                    break;
                case "AddSale":
                case "AddSaleBtn":

                    // do something ...
                    break;
                case "SearchBeer":
                case "SearchBeerBtn":

                    // do something ...
                    break;
                case "SearchClient":
                case "SearchClientBtn":

                    // do something ...
                    break;
                case "SearchSale":
                case "SearchSaleBtn":

                    // do something ...
                    break;
                case "SearchDistributor":
                    // do something ...
                    break;
                case "AboutApp":
                    // do something ...
                    break;
                case "ExitApp":
                    // do something ...
                    break;
            }
            e.Handled = true;
        }

        private void AddNewDistributor_Click(object sender, RoutedEventArgs e)
        {
            if (this.TownBox.Text != null)
            {
                TownService.AddTown(this.TownBox.Text);
            }

            DistributorService.AddDistributor(this.DataContext as Distributor);
            
        }
    }
}
