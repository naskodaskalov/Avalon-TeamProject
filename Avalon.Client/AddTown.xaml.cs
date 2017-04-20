namespace Avalon.Client
{
    using Avalon.Service;
    using System.Collections.ObjectModel;
    using System.Windows;

    /// <summary>
    /// Interaction logic for AddTown.xaml
    /// </summary>
    public partial class AddTown : Window
    {
        public AddTown()
        {
            InitializeComponent();
            AddContinentsToComboBox();

        }

        private void AddContinentsToComboBox()
        {
            ObservableCollection<string> continentsList = new ObservableCollection<string>();
            continentsList.Add("Select continent");
            continentsList.Add("Asia");
            continentsList.Add("Afrika");
            continentsList.Add("Antarctica");
            continentsList.Add("Europe");
            continentsList.Add("North America");
            continentsList.Add("South America");

            cbContinent.SelectedIndex = 0;
            cbContinent.ItemsSource = continentsList;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string townName = TownNameTextBox.Text;
            string zipCode = ZipCodeTextBox.Text;
            string country = CountryNameTextBox.Text;
            string continent = cbContinent.SelectedItem.ToString();

            if (townName == string.Empty || zipCode == string.Empty || country == string.Empty || continent == "Select continent")
            {
                WarningLabel.Content = "All field are required";
                WarningLabel.Visibility = Visibility.Visible;
            }
            else if (AddressService.IsTownExisiting(townName,country))
            {
                WarningLabel.Content = "Town already exist!";
                WarningLabel.Visibility = Visibility.Visible;
            }
            else
            {
                if (!AddressService.IsZipCodeValid(zipCode))
                {
                    WarningLabel.Visibility = Visibility.Visible;
                    WarningLabel.Content = "Invalid zip code, must contains only numbers!";
                    return;
                }
                AddressService.AddTown(townName, zipCode, country, continent);
                this.Close();
            }
        }
    }
}
