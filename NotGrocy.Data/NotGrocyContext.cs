using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using NotGrocy.Models;

#nullable disable

namespace NotGrocy
{
    public partial class NotGrocyContext : DbContext
    {
        public NotGrocyContext()
        {
        }

        public NotGrocyContext(DbContextOptions<NotGrocyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ApiKey> ApiKeys { get; set; }
        public virtual DbSet<Battery> Batteries { get; set; }
        public virtual DbSet<BatteryChargeCycle> BatteryChargeCycles { get; set; }
        public virtual DbSet<Chore> Chores { get; set; }
        public virtual DbSet<ChoresLog> ChoresLogs { get; set; }
        public virtual DbSet<Equipment> Equipment { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<MealPlan> MealPlans { get; set; }
        public virtual DbSet<PermissionHierarchy> PermissionHierarchies { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductBarcode> ProductBarcodes { get; set; }
        public virtual DbSet<ProductGroup> ProductGroups { get; set; }
        public virtual DbSet<QuantityUnit> QuantityUnits { get; set; }
        public virtual DbSet<QuantityUnitConversion> QuantityUnitConversions { get; set; }
        public virtual DbSet<Recipe> Recipes { get; set; }
        public virtual DbSet<RecipesNesting> RecipesNestings { get; set; }
        public virtual DbSet<RecipesPo> RecipesPos { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<ShoppingList> ShoppingLists { get; set; }
        public virtual DbSet<ShoppingList1> ShoppingLists1 { get; set; }
        public virtual DbSet<ShoppingLocation> ShoppingLocations { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }
        public virtual DbSet<StockLog> StockLogs { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<TaskCategory> TaskCategories { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserPermission> UserPermissions { get; set; }
        public virtual DbSet<UserSetting> UserSettings { get; set; }
        public virtual DbSet<Userentity> Userentities { get; set; }
        public virtual DbSet<Userfield> Userfields { get; set; }
        public virtual DbSet<UserfieldValue> UserfieldValues { get; set; }
        public virtual DbSet<Userobject> Userobjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApiKey>(entity =>
            {
                entity.Property(e => e.KeyType).HasDefaultValueSql("'default'");
            });

            modelBuilder.Entity<Battery>(entity =>
            {
                entity.Property(e => e.Active).HasDefaultValueSql("1");
            });

            modelBuilder.Entity<Chore>(entity =>
            {
                entity.Property(e => e.Active).HasDefaultValueSql("1");

                entity.Property(e => e.PeriodInterval).HasDefaultValueSql("1");

                entity.Property(e => e.Rollover).HasDefaultValueSql("0");

                entity.Property(e => e.TrackDateOnly).HasDefaultValueSql("0");
            });

            modelBuilder.Entity<MealPlan>(entity =>
            {
                entity.Property(e => e.ProductAmount).HasDefaultValueSql("0");

                entity.Property(e => e.RecipeServings).HasDefaultValueSql("1");

                entity.Property(e => e.Type).HasDefaultValueSql("'recipe'");
            });
          
            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.Property(e => e.BaseServings).HasDefaultValueSql("1");

                entity.Property(e => e.DesiredServings).HasDefaultValueSql("1");

                entity.Property(e => e.Type).HasDefaultValueSql("'normal'");
            });

            modelBuilder.Entity<RecipesNesting>(entity =>
            {
                entity.Property(e => e.Servings).HasDefaultValueSql("1");
            });

            modelBuilder.Entity<RecipesPo>(entity =>
            {
                entity.Property(e => e.PriceFactor).HasDefaultValueSql("1");
            });

            modelBuilder.Entity<ShoppingList>(entity =>
            {
                entity.Property(e => e.Amount).HasDefaultValueSql("0");

                entity.Property(e => e.Done).HasDefaultValueSql("0");

                entity.Property(e => e.ShoppingListId).HasDefaultValueSql("1");
            });

            modelBuilder.Entity<StockLog>(entity =>
            {
                entity.Property(e => e.UserId).HasDefaultValueSql("1");
            });

            modelBuilder.Entity<Userentity>(entity =>
            {
                entity.Property(e => e.ShowInSidebarMenu).HasDefaultValueSql("1");
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
