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
    /// Interaction logic for EditClient.xaml
    /// </summary>
    public partial class EditClient : Window
    {
        private Customer _clientForEdit;

        public EditClient()
        {
            InitializeComponent();
        }
        
        public EditClient(Customer clientforEditing)
        {
            InitializeComponent();
            _clientForEdit = clientforEditing;
            this.DataContext = _clientForEdit;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            SearchClient searchClientWin = new SearchClient();
            searchClientWin.ShowDialog();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Customer clientToUpdate = this.DataContext as Customer;

            CustomerService.UpdateClient(clientToUpdate);
            this.Close();
            SearchClient searchClientWin = new SearchClient();
            searchClientWin.ShowDialog();
        }
    }
}
