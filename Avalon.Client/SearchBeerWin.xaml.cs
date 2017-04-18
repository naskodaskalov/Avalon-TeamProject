﻿using Avalon.Models;
using Avalon.Service;
using System.Windows;

namespace Avalon.Client
{
    /// <summary>
    /// Interaction logic for SearchBeerWin.xaml
    /// </summary>
    public partial class SearchBeerWin : Window
    {
        public SearchBeerWin()
        {
            InitializeComponent();
            beersDatagrid.DataContext = BeerService.GetAllBeers();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if(this.beersDatagrid.SelectedItem != null)
            {
                AddSaleWin.AddBeerToSaleList(this.beersDatagrid.SelectedItem as Beer);
                this.Close();
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string beerName = SearchTextBox.Text;

            if (beerName == null || beerName.Length == 0)
            {
                WarningLabel.Visibility = Visibility.Visible;
                WarningLabel.Content = "Beer name cannot be empty.";
                return;
            }

            //if (!isBeerExist)
            //{
            //    WarningLabel.Visibility = Visibility.Visible;
            //    WarningLabel.Content = "There aren't any beers with this name.";
            //    return;
            //}

            beersDatagrid.DataContext = BeerService.GetBeersByName(beerName);

        }

    }
}
