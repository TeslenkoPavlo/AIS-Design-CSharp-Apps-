using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace Shop
{
    internal class DataContext : DbContext
    {
        // переписуємо метод OnConfiguring
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // тут вказаний шлях до бази даних
            optionsBuilder.UseSqlite("Data Source = UserData.db");
        }

        // створюємо таблиці, які будуть в базі даних
        public DbSet<Product> Products { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ReceiptProduct> ReceiptProduct { get; set; }

        // метод, який буде викликано при створенні бази даних
        // потрібен для того, щоб правильно сконфігурувати створення бази даних
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Receipt>().ToTable("Receipts");
            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<ReceiptProduct>().ToTable("ReceiptProduct");
        }
    }
}
