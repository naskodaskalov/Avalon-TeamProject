using Avalon.Data;
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
            Console.WriteLine(beerName);

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
            Console.WriteLine(beerCount);
        }
    }
}
