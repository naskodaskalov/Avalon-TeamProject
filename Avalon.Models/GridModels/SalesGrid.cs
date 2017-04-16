using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avalon.Models.GridModels
{
    public class SalesGrid
    {
        public int SaleId { get; set; }
        public DateTime Date { get; set; }
        public string Customer { get; set; }
        public int BeersCount { get; set; }
        public decimal TotalSalePrice { get; set; }
        public decimal TotalBoughtPrice { get; set; }
        public decimal Profit { get; set; }
        public string Seller { get; set; }
    }
}
