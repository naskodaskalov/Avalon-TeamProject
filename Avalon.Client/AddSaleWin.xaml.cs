namespace Avalon.Client
{
    using Avalon.Models;
    using Avalon.Service;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for AddSaleWin.xaml
    /// </summary>
    public partial class AddSaleWin : Window
    {
        public AddSaleWin()
        {
            InitializeComponent();
            this.DataContext = new Sale() {
                Date = DateTime.Now,
                Seller =SecurityService.GetLoggedUser()
            };
            AddCustomersToCombobox();
            _soldBeers = new ObservableCollection<Beer>();
            this.dataGrid.ItemsSource = _soldBeers;

        }

        private void AddCustomersToCombobox()
        {
            var viewListDataClients = new List<string>();
            viewListDataClients = CustomerService.GetAllCustomers();
            this.cbClients.ItemsSource = viewListDataClients;
            cbClients.SelectedIndex = 0;
            viewListDataClients.Add("Add New Customer...");
            this.cbClients.ItemsSource = viewListDataClients;
        }

    private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            //MainWindow mainWindow = new MainWindow();
            //mainWindow.Show();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var customerName = cbClients.SelectedItem.ToString();
            Dictionary<string, int> beersQuantity = new Dictionary<string, int>();
            foreach (var beer in _soldBeers)
            {
                if(beer.Quantity > 0)
                {
                    beersQuantity.Add(beer.Name, beer.Quantity);
                }
            }

            if(beersQuantity.Count == 0)
            {
                WarningLabel.Visibility = Visibility.Visible;
                WarningLabel.Content = "There isn't selected beers or enough beer quantity for sale.";
                return;
            }

            BeerService.AddSale(beersQuantity, customerName);
            this.Close();
            //MainWindow mainWindow = new MainWindow();
            //mainWindow.Show();
        }

        private void ClientsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var value = cbClients.SelectedItem.ToString();

            if (value == "Add New Customer...")
            {
                AddClient addClientWindow = new AddClient();
                addClientWindow.ShowDialog();
            }
        }

        private void AddBeerToSale_Button_Click(object sender, RoutedEventArgs e)
        {
            SearchBeerWin searchBeerWin = new SearchBeerWin();
            searchBeerWin.ShowDialog();
        }

        private static ObservableCollection<Beer> _soldBeers;

        public static void AddBeerToSaleList(Beer beer)
        {
            _soldBeers.Add(beer);
        }
    }
}
