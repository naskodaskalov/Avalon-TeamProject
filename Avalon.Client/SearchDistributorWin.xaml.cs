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
    /// Interaction logic for SearchDistributorWin.xaml
    /// </summary>
    public partial class SearchDistributorWin : Window
    {
        public SearchDistributorWin()
        {
            InitializeComponent();
            this.distributorsDatagrid.DataContext = DistributorService.GetAllDistributors();

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();

        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            EditDistributor editDistributorWin = new EditDistributor(this.distributorsDatagrid.SelectedItem as Distributor);
            this.Close();
            editDistributorWin.Show();


        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            string distributorName = (this.distributorsDatagrid.SelectedItem as Distributor).Name;

            DistributorService.DeleteDistributor(distributorName);
            distributorsDatagrid.DataContext = DistributorService.GetAllDistributors();


        }


        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string distributorName = SearchTextBox.Text.Trim();

            if (distributorName == null || distributorName.Length == 0)
            {
                WarningLabel.Visibility = Visibility.Visible;
                WarningLabel.Content = "Beer name cannot be empty.";
                return;
            }

            distributorsDatagrid.DataContext = DistributorService.GetDistributorsByName(distributorName);

        }
    }
}
