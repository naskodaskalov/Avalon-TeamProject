namespace Avalon.Client
{
    using Avalon.Models;
    using Avalon.Service;
    using System.Windows;

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
            this.Close();
            //MainWindow mainWindow = new MainWindow();
            //mainWindow.Show();

        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            //this.Close();
            EditDistributor editDistributorWin = new EditDistributor(this.distributorsDatagrid.SelectedItem as Distributor);
            editDistributorWin.ShowDialog();


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
