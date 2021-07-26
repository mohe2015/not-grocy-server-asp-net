using Microsoft.EntityFrameworkCore;

namespace StockApi.Models
{
    public class StockContext : DbContext
    {
        public StockContext(DbContextOptions<StockContext> options)
            : base(options)
        {
        }

        public DbSet<StockItem> StockItems { get; set; }
    }
}
