using Avalon.Service;
using System;
using System.Windows;

namespace Avalon.Client
{
    /// <summary>
    /// Interaction logic for SearchBeer.xaml
    /// </summary>
    public partial class SearchBeer : Window
    {
        public SearchBeer()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string beerName = BeerNameTextBox.Text;

            if(beerName == null || beerName.Length == 0)
            {
                WarningLabel.Visibility = Visibility.Visible;
                WarningLabel.Content = "Beer name cannot be empty.";
                return;
            }

            var isBeerExist = BeerService.BeerExist(beerName);
            if (!isBeerExist)
            {
                WarningLabel.Visibility = Visibility.Visible;
                WarningLabel.Content = "There aren't beer with this name.";
                return;
            }

            int beerCount = BeerService.BeerCount(beerName);
            // TODO: show beer's count on new window
        }
    }
}
