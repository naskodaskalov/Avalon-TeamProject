using Avalon.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for AddBeer.xaml
    /// </summary>
    public partial class AddBeer : Window
    {
        public AddBeer()
        {
            InitializeComponent();
            AddBreweriesToComboBox();
            AddStylesToComboBox();
            AddDistributorsToComboBox();

        }

        private void AddDistributorsToComboBox()
        {
            ObservableCollection<string> distributors = new ObservableCollection<string>();
            distributors = BeerService.GetAllDistributors();
            this.cbDistributors.SelectedIndex = 0;
            this.cbDistributors.ItemsSource = distributors;

        }

        private void AddBreweriesToComboBox()
        {
            ObservableCollection<string> breweries = new ObservableCollection<string>();
            breweries = BeerService.GetAllBreweriesNames();
            this.cbBreweries.SelectedIndex = 0;
            this.cbBreweries.ItemsSource = breweries;

        }

        private void AddStylesToComboBox()
        {
            ObservableCollection<string> stylesList = new ObservableCollection<string>();
            stylesList = BeerService.GetAllBeerStyles();
            cbStyles.SelectedIndex = 0;
            this.cbStyles.ItemsSource = stylesList;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }


        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string beerName = this.BeerName.Text;
            decimal price = decimal.Parse(this.BeerPrice.Text);
            int quantity = int.Parse(this.Quantity.Text);
            float rating = float.Parse(this.BeerRating.Text);
            string style = this.cbStyles.SelectedItem.ToString();
            string breweryName = this.cbBreweries.SelectedItem.ToString();
            string distributorName = this.cbDistributors.SelectedItem.ToString();
            decimal distributorPrice = decimal.Parse(this.DistributorPrice.Text);

            if (beerName == string.Empty || price <= 0 ||
                quantity <= 0 || rating <= 0 || rating > 10 || 
                style == string.Empty || breweryName == string.Empty || 
                distributorName == string.Empty || distributorPrice <= 0)
            {
                WarningLabel.Content = "All field are required!";
                WarningLabel.Visibility = Visibility.Visible;
            }
            else
            {
                BeerService.AddBeer(beerName, price, quantity, rating, style, breweryName, distributorName, distributorPrice);
                MainWindow mainWindow = new MainWindow();
                this.Close();
                mainWindow.Show();
            }
        }
        private void Quantity_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
