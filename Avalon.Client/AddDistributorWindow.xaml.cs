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

        
        }

        private void AddBreweriesToViewList()
        {
            ObservableCollection<BreweryGrid> viewListData = BeerService.GetAllBreweries();

            foreach (var brewery in viewListData)
            {
                this.ListView.Items.Add(brewery);
            }
        }

        private void AddTownsToComboBox()
        {
            ObservableCollection<string> townList = new ObservableCollection<string>();
            townList = AddressService.GetAllTowns();
            TownsComboBox.SelectedIndex = 0;
            townList.Add("Add New Town...");
            this.TownsComboBox.ItemsSource = townList;
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

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            
            
        }

        private void TownsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var value = TownsComboBox.SelectedItem.ToString();

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
    }
}
