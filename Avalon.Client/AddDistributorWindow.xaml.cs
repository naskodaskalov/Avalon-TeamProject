using Avalon.Models;
using Avalon.Models.GridModels;
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
    /// Interaction logic for AddDistributorWindow.xaml
    /// </summary>
    public partial class AddDistributorWindow : Window
    {
        public AddDistributorWindow()
        {
            InitializeComponent();
            AddTownsToComboBox();
            AddBreweriesToViewList();
            this.DataContext = new Distributor();
            _checkedBreweries = new List<string>();
        
        }

        private void AddBreweriesToViewList()
        {
            var viewListData = new ObservableCollection<BreweryGrid>();
            viewListData =  BeerService.GetAllBreweries();
            this.ListBoxBreweries.ItemsSource = viewListData;
           
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
            var newDistributor = this.DataContext as Distributor;
            string chosenTown = this.cbTowns.SelectedItem.ToString();
            DistributorService.AddDistributor(newDistributor, chosenTown, _checkedBreweries);
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
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private List<string> _checkedBreweries;

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            string addedBrewery = ((CheckBox)sender).Content.ToString();
            _checkedBreweries.Add(addedBrewery);

        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            string removedBrewery = ((CheckBox)sender).Content.ToString();
            _checkedBreweries.Remove(removedBrewery);
        }
    }
}
