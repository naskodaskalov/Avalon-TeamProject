namespace Avalon.Models
{
    public class BeerSale
    {
        public int BeerId { get; set; }

        public int SaleId { get; set; }

        public virtual Beer Beer { get; set; }

        public virtual Sale Sale { get; set; }

        public int Quantity { get; set; }
    }
}
