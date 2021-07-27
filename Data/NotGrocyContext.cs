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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("Data Source=hello.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApiKey>(entity =>
            {
                entity.Property(e => e.KeyType).HasDefaultValueSql("'default'");

                entity.Property(e => e.RowCreatedTimestamp).HasDefaultValueSql("datetime('now', 'localtime')");
            });

            modelBuilder.Entity<Battery>(entity =>
            {
                entity.Property(e => e.Active).HasDefaultValueSql("1");

                entity.Property(e => e.RowCreatedTimestamp).HasDefaultValueSql("datetime('now', 'localtime')");
            });

            modelBuilder.Entity<BatteryChargeCycle>(entity =>
            {
                entity.Property(e => e.RowCreatedTimestamp).HasDefaultValueSql("datetime('now', 'localtime')");
            });

            modelBuilder.Entity<Chore>(entity =>
            {
                entity.Property(e => e.Active).HasDefaultValueSql("1");

                entity.Property(e => e.PeriodInterval).HasDefaultValueSql("1");

                entity.Property(e => e.Rollover).HasDefaultValueSql("0");

                entity.Property(e => e.RowCreatedTimestamp).HasDefaultValueSql("datetime('now', 'localtime')");

                entity.Property(e => e.TrackDateOnly).HasDefaultValueSql("0");
            });

            modelBuilder.Entity<ChoresLog>(entity =>
            {
                entity.Property(e => e.RowCreatedTimestamp).HasDefaultValueSql("datetime('now', 'localtime')");
            });

            modelBuilder.Entity<Equipment>(entity =>
            {
                entity.Property(e => e.RowCreatedTimestamp).HasDefaultValueSql("datetime('now', 'localtime')");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.RowCreatedTimestamp).HasDefaultValueSql("datetime('now', 'localtime')");
            });

            modelBuilder.Entity<MealPlan>(entity =>
            {
                entity.Property(e => e.ProductAmount).HasDefaultValueSql("0");

                entity.Property(e => e.RecipeServings).HasDefaultValueSql("1");

                entity.Property(e => e.RowCreatedTimestamp).HasDefaultValueSql("datetime('now', 'localtime')");

                entity.Property(e => e.Type).HasDefaultValueSql("'recipe'");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
