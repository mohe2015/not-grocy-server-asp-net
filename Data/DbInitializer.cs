using NotGrocy.Models;
using System;
using System.Linq;

namespace NotGrocy.Data
{
    public static class DbInitializer
    {
        public static void Initialize(NotGrocyContext context)
        {
            // Look for any stock items.
            if (context.Stocks.Any())
            {
                return;   // DB has been seeded
            }

            var stockItems = new Stock[]
            {
            
            };
            foreach (Stock s in stockItems)
            {
                context.Stocks.Add(s);
            }
            context.SaveChanges();
        }
    }
}
