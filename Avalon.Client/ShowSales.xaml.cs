using Avalon.Models.GridModels;
using Avalon.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Interaction logic for ShowSales.xaml
    /// </summary>
    public partial class ShowSales : Window
    {
        public ShowSales()
        {
            InitializeComponent();
            AddSalesToViewList();
        }
        
        private void AddSalesToViewList()
        {
            var viewListData = new ObservableCollection<SalesGrid>();
            viewListData = BeerService.ShowAllSales();
            this.ListViewSales.ItemsSource = viewListData;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }
    }
}
