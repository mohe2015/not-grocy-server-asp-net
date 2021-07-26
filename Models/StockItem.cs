using System;

namespace StockApi.Models
{
    public class StockItem
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public double Amount { get; set; }
        public DateTime BestBeforeDate { get; set; }
        public DateTime PurchasedDate { get; set; }
        public string StockId { get; set; }
        public double Price { get; set; }
        public bool IsOpen { get; set; }
        public DateTime OpenedDate { get; set; }
        public DateTime RowCreated { get; set; }
        public long LocationId { get; set; }
        public long ShoppingLocationId { get; set; }
    }
}