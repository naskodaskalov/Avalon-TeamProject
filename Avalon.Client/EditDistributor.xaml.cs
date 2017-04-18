using Avalon.Models;
using Avalon.Models.GridModels;
using Avalon.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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
    /// Interaction logic for EditDistributor.xaml
    /// </summary>
    public partial class EditDistributor : Window
    {

        private Distributor _distributorForEdit;

        private string distributorNameForEdit;

        private ObservableCollection<string> _checkedBreweries;

        private ObservableCollection<string> _allBreweries;

        public ObservableCollection<string> CheckedBreweries
        {
            get
            {
                return _checkedBreweries;
            }

            set
            {
                _checkedBreweries = value;
            }
        }

        public ObservableCollection<string> AllBreweries
        {
            get
            {
                return _allBreweries;
            }

            set
            {
                _allBreweries = value;
            }
        }

        public EditDistributor(Distributor distributor)
        {
            InitializeComponent();
            _distributorForEdit = distributor;
            distributorNameForEdit = distributor.Name;
            this.DataContext = _distributorForEdit;
            CheckedBreweries = new ObservableCollection<string>();
            AllBreweries = new ObservableCollection<string>();
            AddTownsToComboBox();
            AddBreweriesToViewList();

            ((INotifyCollectionChanged)ListBoxAllBreweries.ItemsSource).CollectionChanged +=
        new NotifyCollectionChangedEventHandler(ListAllCollectionChanged);
        }


        public void ListAllCollectionChanged(Object sender, NotifyCollectionChangedEventArgs e)
        {
            ListBoxAllBreweries.ItemsSource = null;
            ListBoxDistributorBreweries.ItemsSource = null;
            ListBoxAllBreweries.ItemsSource = AllBreweries;
            ListBoxDistributorBreweries.ItemsSource = CheckedBreweries;
        }


        private void AddBreweriesToViewList()
        {

            _distributorForEdit.Breweries.ToList().ForEach(b => CheckedBreweries.Add(b.Name));
            AllBreweries = BeerService.GetAllBreweriesNames();
            foreach (var i in CheckedBreweries)
            {
                AllBreweries.Remove(i);
            }
            CheckedBreweries.OrderBy(b => b);
            AllBreweries.OrderBy(b => b);
            this.ListBoxAllBreweries.ItemsSource = AllBreweries;
            this.ListBoxDistributorBreweries.ItemsSource = CheckedBreweries;



        }

        private void AddTownsToComboBox()
        {
            ObservableCollection<string> townList = new ObservableCollection<string>();
            townList = AddressService.GetAllTowns();
            if (_distributorForEdit.Town != null)
            {
                cbTowns.SelectedIndex = townList.IndexOf(_distributorForEdit.Town.Name);

            }
            townList.Add("Add New Town...");
            this.cbTowns.ItemsSource = townList;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string distributorName = this.distributorNameForEdit;

            string address = this.AddressTextBox.Text;
            string town = this.cbTowns.SelectedItem.ToString();
            string phone = this.PhoneTextBox.Text;
            string newDestributorName = this.DistributorNameTextBox.Text;


            if (address == string.Empty || town == string.Empty || 
                phone == string.Empty || newDestributorName == string.Empty)
            {
                WarningLabel.Content = "All field are required";
                WarningLabel.Visibility = Visibility.Visible;
            }
            else
            {
                DistributorService.UpdateDistributor(distributorName, newDestributorName, town, phone, address, _checkedBreweries.ToList());
            }
            MainWindow mainWindow = new MainWindow();
            this.Close();
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
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }

        private void IncludeButton_Click(object sender, RoutedEventArgs e)
        {
            string addedBrewery = ListBoxAllBreweries.SelectedItem.ToString();
            CheckedBreweries.Add(addedBrewery);
            AllBreweries.Remove(addedBrewery);



        }

        private void ExcludeButton_Click(object sender, RoutedEventArgs e)
        {
            string removedBrewery = ListBoxDistributorBreweries.SelectedItem.ToString();
            CheckedBreweries.Remove(removedBrewery);
            AllBreweries.Add(removedBrewery);

        }

       


        
    }
}
