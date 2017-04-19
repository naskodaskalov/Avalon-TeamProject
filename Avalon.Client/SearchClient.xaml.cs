using Avalon.Models;
using Avalon.Service;
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
using System.Windows.Shapes;

namespace Avalon.Client
{
    /// <summary>
    /// Interaction logic for SearchClient.xaml
    /// </summary>
    public partial class SearchClient : Window
    {
        public SearchClient()
        {
            InitializeComponent();
            clientsDatagrid.DataContext = CustomerService.GetAllClients();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.clientsDatagrid.SelectedItem != null)
            {
                EditClient editClientrWin = new EditClient(this.clientsDatagrid.SelectedItem as Customer);
                this.Close();
                editClientrWin.Show();
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.clientsDatagrid.SelectedItem != null)
            {
                string clientName = (this.clientsDatagrid.SelectedItem as Customer).Name;

                CustomerService.DeleteClient(clientName);
                clientsDatagrid.DataContext = CustomerService.GetAllClients();
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string clientName = SearchTextBox.Text.Trim();

            if (clientName == null || clientName.Length == 0)
            {
                WarningLabel.Visibility = Visibility.Visible;
                WarningLabel.Content = "Beer name cannot be empty.";
                return;
            }

            clientsDatagrid.DataContext = CustomerService.GetCustomersByName(clientName);
        }
    }
}
