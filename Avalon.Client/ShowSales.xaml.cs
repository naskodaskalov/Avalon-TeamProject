namespace Avalon.Client
{
    using Avalon.Models.GridModels;
    using Avalon.Service;
    using System.Collections.ObjectModel;
    using System.Windows;
    using iTextSharp.text;
    using iTextSharp.text.pdf;
    using System.IO;
    using System.Diagnostics;

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
            this.Close();
            //MainWindow mainWindow = new MainWindow();
            //mainWindow.Show();
        }

        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            SalesGrid export = this.ListViewSales.SelectedItem as SalesGrid;    

            if (export != null)
            {
                FileStream fs = new FileStream("..\\..\\ExportPdf" + "\\" + $"SaleId {export.SaleId} PDF Document.pdf", FileMode.Create);

                Document document = new Document(PageSize.A6);
                PdfWriter writer = PdfWriter.GetInstance(document, fs);
                document.Open();
                document.AddHeader("Date of sale", export.Date.ToString());
                document.AddAuthor(export.Seller);

                PdfContentByte cb = writer.DirectContent;
                iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance("..\\..\\Images\\avalon-mark.png");
                img.SetAbsolutePosition(180,30);
                img.ScalePercent(40);
                cb.AddImage(img);

                Font calibri = new Font(Font.FontFamily.COURIER, 14, Font.ITALIC);  

                iTextSharp.text.Paragraph p1 = new iTextSharp.text.Paragraph($"Data of sale: {export.Date.ToString()}",calibri);
                iTextSharp.text.Paragraph p2 = new iTextSharp.text.Paragraph($"Customer: {export.Customer}", calibri);
                iTextSharp.text.Paragraph p3 = new iTextSharp.text.Paragraph($"Number of beers: {export.BeersCount}", calibri);
                iTextSharp.text.Paragraph p4 = new iTextSharp.text.Paragraph($"Total Sale Price: {export.TotalSalePrice}$", calibri);
                iTextSharp.text.Paragraph p5 = new iTextSharp.text.Paragraph($"Total Bought Price: {export.TotalBoughtPrice}$", calibri);
                iTextSharp.text.Paragraph p6 = new iTextSharp.text.Paragraph($"Profit: {export.Profit}$", calibri);
                iTextSharp.text.Paragraph p7 = new iTextSharp.text.Paragraph($"Seller: {export.Seller}", calibri);

                document.Add(p1);
                document.Add(p2);
                document.Add(p3);
                document.Add(p4);
                document.Add(p5);
                document.Add(p6);
                document.Add(p7);

                document.Close();
                writer.Close();
                fs.Close();

                this.WarningLabel.Content = $"Sale with id {export.SaleId} succesfully exported.";
                this.WarningLabel.Visibility = Visibility.Visible;
                ProcessStartInfo startInfo = new ProcessStartInfo("..\\..\\ExportPdf" + "\\" + $"SaleId {export.SaleId} PDF Document.pdf");
                Process.Start(startInfo);
            }
            else
            {
                this.WarningLabel.Content = $"You should select sale first!";
                this.WarningLabel.Visibility = Visibility.Visible;
            }
            
        }
    }
}
