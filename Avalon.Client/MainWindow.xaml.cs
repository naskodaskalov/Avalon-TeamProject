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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Avalon.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void CommonMenuClickHandler(object sender, RoutedEventArgs e)
        {
            FrameworkElement feSource = e.Source as FrameworkElement;
            switch (feSource.Name)
            {
                case "AddClient":
                case "AddClientBtn":
                    this.Hide();
                    AddClient addClientWin = new AddClient();
                    addClientWin.Show();
                    break;
                case "AddDistributor":
                    this.Hide();
                    AddDistributorWindow addDistributorWin = new AddDistributorWindow();
                    addDistributorWin.Show();
                    break;
                case "AddBeerBtn":
                case "AddBeer":
                    this.Hide();
                    AddBeer addBeerWin = new AddBeer();
                    addBeerWin.Show(); 
                    break;
                case "AddBrewery":
                    this.Hide();
                    AddBreweryWin addBreweryWin = new AddBreweryWin();
                    addBreweryWin.Show(); 
                    break;
                case "AddSale":
                case "AddSaleBtn":
                    this.Hide();
                    AddSaleWin addSaleWin = new AddSaleWin();
                    addSaleWin.Show();
                    break;
                case "SearchBeer":
                    this.Hide();
                    SearchBeerWin searchBeerWindow = new SearchBeerWin();
                    searchBeerWindow.Show();
                    break;
                case "SearchBeerBtn":
                    this.Hide();
                    SearchEditBeerWin searchEditBeerWindow = new SearchEditBeerWin();
                    searchEditBeerWindow.Show();
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
                    SearchDistributorWin searchDistributorWin = new SearchDistributorWin();
                    this.Close();
                    searchDistributorWin.Show();
                    break;
                case "AboutApp":
                    About abautWindow = new About();
                    abautWindow.Show();
                    break;
                case "ExitApp":
                    // do something ...
                    Application.Current.Shutdown();
                    break;
                case "ShowSaleBtn":
                case "ShowSale":
                    ShowSales showSalesWindow = new ShowSales();
                    this.Close();
                    showSalesWindow.Show();
                    break;
            }
            e.Handled = true;
        }
    }
}
