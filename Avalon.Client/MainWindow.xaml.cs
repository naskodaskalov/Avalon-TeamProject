namespace Avalon.Client
{
    using System.Windows;

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
                    AddClient addClientWin = new AddClient();
                    addClientWin.ShowDialog();
                    break;
                case "AddDistributor":
                    AddDistributorWindow addDistributorWin = new AddDistributorWindow();
                    addDistributorWin.ShowDialog();
                    break;
                case "AddBeerBtn":
                case "AddBeer":
                    AddBeer addBeerWin = new AddBeer();
                    addBeerWin.ShowDialog(); 
                    break;
                case "AddBrewery":
                    AddBreweryWin addBreweryWin = new AddBreweryWin();
                    addBreweryWin.ShowDialog(); 
                    break;
                case "AddSale":
                case "AddSaleBtn":
                    AddSaleWin addSaleWin = new AddSaleWin();
                    addSaleWin.ShowDialog();
                    break;
                case "SearchBeer":
                    SearchBeerWin searchBeerWindow = new SearchBeerWin();
                    searchBeerWindow.ShowDialog();
                    break;
                case "SearchBeerBtn":
                    SearchEditBeerWin searchEditBeerWindow = new SearchEditBeerWin();
                    searchEditBeerWindow.ShowDialog();
                    break;

                case "SearchClient":
                case "SearchClientBtn":
                    SearchClient searchClient = new SearchClient();
                    searchClient.ShowDialog();
                    break;

                case "SearchSale":
                case "SearchSaleBtn":

                    // do something ...
                    break;
                case "SearchDistributor":
                    //this.Close();
                    SearchDistributorWin searchDistributorWin = new SearchDistributorWin();
                    searchDistributorWin.ShowDialog();
                    break;
                case "AboutApp":
                    About abautWindow = new About();
                    abautWindow.ShowDialog();
                    break;
                case "ExitApp":
                    // do something ...
                    Application.Current.Shutdown();
                    break;
                case "ShowSaleBtn":
                case "ShowSale":
                    //this.Close();
                    ShowSales showSalesWindow = new ShowSales();
                    showSalesWindow.ShowDialog();
                    break;
            }
            e.Handled = true;
        }
    }
}
