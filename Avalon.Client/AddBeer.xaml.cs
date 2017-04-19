using Avalon.Service;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

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
            this.Close();
        }


        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string beerName = this.BeerName.Text;
                var price = decimal.Parse(this.BeerPrice.Text);
                var quantity = int.Parse(this.Quantity.Text);
                var rating = float.Parse(this.BeerRating.Text);
                string style = this.cbStyles.SelectedItem.ToString();
                string breweryName = this.cbBreweries.SelectedItem.ToString();
                string distributorName = this.cbDistributors.SelectedItem.ToString();
                var distributorPrice = decimal.Parse(this.DistributorPrice.Text);

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
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                WarningLabel.Visibility = Visibility.Visible;
                WarningLabel.Content = ex.Message;
                return;
            }
        }
        private void Quantity_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
