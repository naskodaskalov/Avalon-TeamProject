namespace Avalon.Client
{
    using Avalon.Models;
    using Avalon.Service;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for AddBreweryWin.xaml
    /// </summary>
    public partial class AddBreweryWin : Window
    {
        public AddBreweryWin()
        {
            InitializeComponent();
            AddTownsToComboBox();
            AddBeersToViewList();
            AddDistributorsToViewList();
            this.DataContext = new Brewery();
            _checkedBeers = new List<string>();
            _checkedDistributors = new List<string>();
        }

        private void AddDistributorsToViewList()
        {
            var viewListDataDistributors = new ObservableCollection<Distributor>();
            viewListDataDistributors = DistributorService.GetAllDistributors();
            this.ListBoxDistributors.ItemsSource = viewListDataDistributors;
        }

        private void AddBeersToViewList()
        {
            var viewListDataBeers= new ObservableCollection<Beer>();
            viewListDataBeers = BeerService.GetAllBeers();
            this.ListBoxBeers.ItemsSource = viewListDataBeers;

        }

        private void AddTownsToComboBox()
        {
            ObservableCollection<string> townList = new ObservableCollection<string>();
            townList = AddressService.GetAllTowns();
            cbTowns.SelectedIndex = 0;
            townList.Add("Add New Town...");
            this.cbTowns.ItemsSource = townList;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var newBrewery = this.DataContext as Brewery;
            string chosenTown = this.cbTowns.SelectedItem.ToString();
            BeerService.AddBrewery(newBrewery, chosenTown, _checkedBeers, _checkedDistributors);
            this.Close();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void TownsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var value = cbTowns.SelectedItem.ToString();

            if (value == "Add New Town...")
            {
                AddTown addTownWindow = new AddTown();
                addTownWindow.Show();
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            //MainWindow mainWindow = new MainWindow();
            //mainWindow.Show();
        }

        private List<string> _checkedBeers;

        private void BeerCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            string addedBeer = ((CheckBox)sender).Content.ToString();
            _checkedBeers.Add(addedBeer);

        }

        private void BeerCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            string removedBeer = ((CheckBox)sender).Content.ToString();
            _checkedBeers.Remove(removedBeer);
        }

        private List<string> _checkedDistributors;

        private void DistributorCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            string addedDistro = ((CheckBox)sender).Content.ToString();
            _checkedDistributors.Add(addedDistro);

        }

        private void DistributorBeerCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            string removedDistro = ((CheckBox)sender).Content.ToString();
            _checkedDistributors.Remove(removedDistro);
        }

    }
}
