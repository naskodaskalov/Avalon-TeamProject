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

        private void AddClient_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddDistributor_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddBeer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddBrewery_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddSale_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SearchBeer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SearchClient_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SearchSale_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SearchDistributor_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AboutApp_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ExitApp_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
