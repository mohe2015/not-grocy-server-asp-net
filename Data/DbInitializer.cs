using NotGrocy.Models;
using System;
using System.Linq;

namespace NotGrocy.Data
{
    public static class DbInitializer
    {
        public static void Initialize(StockContext context)
        {
            context.Database.EnsureCreated();

            // Look for any stock items.
            if (context.StockItems.Any())
            {
                return;   // DB has been seeded
            }

            var stockItems = new StockItem[]
            {
            
            };
            foreach (StockItem s in stockItems)
            {
                context.StockItems.Add(s);
            }
            context.SaveChanges();
        }
    }
}
