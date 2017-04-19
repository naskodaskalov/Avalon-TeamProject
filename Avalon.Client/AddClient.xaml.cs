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
    /// Interaction logic for AddClient.xaml
    /// </summary>
    public partial class AddClient : Window
    {
        public AddClient()
        {
            InitializeComponent();
            AddTownsToComboBox();
            AddStylesToComboBox();

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
            //MainWindow mainWindow = new MainWindow();
            //mainWindow.Show();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string clientName = ClientNameTextBox.Text;
            string town = cbTowns.SelectedItem.ToString();
            string address = AddressTextBox.Text;
            string email = EmailTextBox.Text;
            string phone = PhoneTextBox.Text;
            string style = cbStyles.SelectedItem.ToString();

            if (clientName == string.Empty || town == "Select towns" || address == string.Empty ||
                email == string.Empty || phone == string.Empty)
            {
                WarningLabel.Content = "All field are required!";
                WarningLabel.Visibility = Visibility.Visible;
            }
            else
            {
                CustomerService.AddCustomer(clientName, address, town, email, phone, style);
                this.Close();
                //MainWindow mainWindow = new MainWindow();
                //mainWindow.Show();
            }
        }
        private void AddTownsToComboBox()
        {
            ObservableCollection<string> townList = new ObservableCollection<string>();
            townList = AddressService.GetAllTowns();
            cbTowns.SelectedIndex = 0;
            townList.Add("Add New Town...");
            this.cbTowns.ItemsSource = townList;
        }

        private void cbTowns_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = cbTowns.SelectedItem.ToString();

            if (item == "Add New Town...")
            {
                AddTown addTownWindow = new AddTown();
                addTownWindow.ShowDialog();
            }
        }
    }
}
