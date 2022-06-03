using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class CalcContext : DbContext
    {
        public CalcContext(DbContextOptions options) : base(options) { }
        public DbSet<CalcHistory> CalcHistories { get; set; }
        public DbSet<MathOperator> MathOperators { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<MathOperator>().ToTable("MathOperator")
                .HasData(
                new { Id = 1, OperationName = "Scitani", Symbol = "+" },
                new { Id = 2, OperationName = "Odcitani", Symbol = "-" },
                new { Id = 3, OperationName = "Nasobeni", Symbol = "*" },
                new { Id = 4, OperationName = "Deleni", Symbol = "/" }
            );
            builder.Entity<CalcHistory>().ToTable("CalcHistory");
        }
    }
}
