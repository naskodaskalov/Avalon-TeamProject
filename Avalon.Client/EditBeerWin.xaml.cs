using Avalon.Models;
using Avalon.Service;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Avalon.Client
{
    /// <summary>
    /// Interaction logic for EditBeerWin.xaml
    /// </summary>
    public partial class EditBeerWin : Window
    {
        private Beer _beerForEdit;

        public EditBeerWin()
        {
            InitializeComponent();
            AddStylesToComboBox();
            AddDistributorsToComboBox();
            AddBreweriesToComboBox();
        }

        public EditBeerWin(Beer beerforEditing)
        {
            InitializeComponent();
            _beerForEdit = beerforEditing;
            this.DataContext = _beerForEdit;
            AddStylesToComboBox();
            AddDistributorsToComboBox();
            AddBreweriesToComboBox();

        }


        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            SearchEditBeerWin searchEditBeerWin = new SearchEditBeerWin();
            searchEditBeerWin.ShowDialog();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Beer beerToUpdate = this.DataContext as Beer;
            string newStyle = String.Empty;
            string newDistributor = String.Empty;
            string newBrewery = String.Empty;

            if (this.cbStyles.SelectedItem != null)
            {
                newStyle = this.cbStyles.SelectedItem.ToString();
            }
            if (this.cbDistributors.SelectedItem != null)
            {
                newDistributor = this.cbDistributors.SelectedItem.ToString();
            }
            if (this.cbBreweries.SelectedItem != null)
            {
                newBrewery = this.cbBreweries.SelectedItem.ToString();
            }

            BeerService.UpdateBeer(beerToUpdate, newStyle, newDistributor, newBrewery);
            this.Close();
            SearchEditBeerWin searchEditBeerWin = new SearchEditBeerWin();
            searchEditBeerWin.ShowDialog();
        }

        private void cbStyles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //to do if we want to add functionality to add New Style directly from the Combobox
        }

        private void cbBreweries_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //to do if we want to add functionality to add New Brewery directly from the Combobox
        }

        private void cbDistributors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //to do if we want to add functionality to add New Distributor directly from the Combobox
        }

        private void AddStylesToComboBox()
        {
            ObservableCollection<string> stylesList = new ObservableCollection<string>();
            stylesList = BeerService.GetAllBeerStyles();
            if (stylesList.Count != 0 && _beerForEdit.Style != null)
            {
            cbStyles.SelectedIndex = stylesList.IndexOf(_beerForEdit.Style.Name);
            //townList.Add("Add New Town...");
            this.cbStyles.ItemsSource = stylesList;
            }
        }


        private void AddDistributorsToComboBox()
        {
            ObservableCollection<string> distributorsList = new ObservableCollection<string>();
            distributorsList = DistributorService.GetAllDistributorsNames();
            if (distributorsList.Count != 0 && _beerForEdit.Distributor != null)
            {
            cbDistributors.SelectedIndex = distributorsList.IndexOf(_beerForEdit.Distributor.Name);
            //townList.Add("Add New Town...");
            this.cbDistributors.ItemsSource = distributorsList;

            }
        }

        private void AddBreweriesToComboBox()
        {
            ObservableCollection<string> breweriesList = new ObservableCollection<string>();
            breweriesList = BeerService.GetAllBreweriesNames();
            if (breweriesList.Count != 0 && _beerForEdit.Brewery != null)
            {
            cbBreweries.SelectedIndex = breweriesList.IndexOf(_beerForEdit.Brewery.Name);
            //townList.Add("Add New Town...");
            this.cbBreweries.ItemsSource = breweriesList;
            }
        }
    }
}
