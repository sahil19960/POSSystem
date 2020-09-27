using Microsoft.EntityFrameworkCore;
using PosSystem.Models;
using System;

namespace PosSystem.DataAcessLayer
{
    public class PosDbContext : DbContext
    {
        public PosDbContext(DbContextOptions<PosDbContext> options): base(options){}

        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Invoice> Invoices { get; set; }

        public DbSet<ItemInSalesTransaction> SalesTransactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
               .HasIndex(user => user.UserEmailId)
               .IsUnique();

            modelBuilder.Entity<User>().HasData(
               new User
               {
                   UserId = 1,
                   UserName = "test",
                   UserEmailId = "test@gmail.com",
                   Password = "testpass" 
               }
           );

            modelBuilder.Entity<Product>().HasData(
              new Product
              {
                  ProductId = 1,
                  ProductName = "Grapes",
                  AvailableQuantity = 2,
                  UnitPrice = 2.00,
                  ImageUrl = "/images/grapes.jpeg",
                  Category = (int) CategoryEnum.FRUITS
              });

            modelBuilder.Entity<Product>().HasData(
              new Product
              {
                  ProductId = 2,
                  ProductName = "Strawberries",
                  AvailableQuantity = 3,
                  UnitPrice = 2.00,
                  ImageUrl = "/images/strawberries.jpeg",
                  Category = (int)CategoryEnum.FRUITS
              });

            modelBuilder.Entity<Product>().HasData(
              new Product
              {
                  ProductId = 3,
                  ProductName = "Clothing",
                  AvailableQuantity = 3,
                  UnitPrice = 2.00,
                  ImageUrl = "/images/clothing.jpg",
                  Category = (int)CategoryEnum.CLOTHING
              });

            modelBuilder.Entity<Product>().HasData(
              new Product
              {
                  ProductId = 4,
                  ProductName = "Compute Repair",
                  AvailableQuantity = 3,
                  UnitPrice = 2.00,
                  ImageUrl = "/images/computer_repair.jpeg",
                  Category = (int)CategoryEnum.COMPUTERS
              });

            modelBuilder.Entity<Product>().HasData(
             new Product
             {
                 ProductId = 5,
                 ProductName = "Computer",
                 AvailableQuantity = 3,
                 UnitPrice = 2.00,
                 ImageUrl = "/images/comuter.jpg",
                 Category = (int)CategoryEnum.COMPUTERS
             });

            modelBuilder.Entity<Product>().HasData(
             new Product
             {
                 ProductId = 6,
                 ProductName = "Gift Folding",
                 AvailableQuantity = 3,
                 UnitPrice = 2.00,
                 ImageUrl = "/images/gift_folding.jpeg",
                 Category = (int)CategoryEnum.SERVICES
             });

            modelBuilder.Entity<Product>().HasData(
             new Product
             {
                 ProductId = 7,
                 ProductName = "Headphone",
                 AvailableQuantity = 3,
                 UnitPrice = 2.00,
                 ImageUrl = "/images/headphone.jpg",
                 Category = (int)CategoryEnum.COMPUTERS
             });

            modelBuilder.Entity<Product>().HasData(
            new Product
            {
                ProductId = 8,
                ProductName = "motherboard",
                AvailableQuantity = 20,
                UnitPrice = 200.00,
                ImageUrl = "/images/motherboard.jpg",
                Category = (int)CategoryEnum.COMPUTERS
            });

            modelBuilder.Entity<Product>().HasData(
           new Product
           {
               ProductId = 9,
               ProductName = "Mouse",
               AvailableQuantity = 20,
               UnitPrice = 200.00,
               ImageUrl = "/images/mouse.jpg",
               Category = (int)CategoryEnum.COMPUTERS
           });

            modelBuilder.Entity<Product>().HasData(
          new Product
          {
              ProductId = 10,
              ProductName = "Notebook",
              AvailableQuantity = 20,
              UnitPrice = 200.00,
              ImageUrl = "/images/notebook.jpg",
              Category = (int)CategoryEnum.SERVICES
          });

            modelBuilder.Entity<Product>().HasData(
         new Product
         {
             ProductId = 11,
             ProductName = "Tie",
             AvailableQuantity = 200,
             UnitPrice = 19.00,
             ImageUrl = "/images/tie.jpeg",
             Category = (int)CategoryEnum.CLOTHING
         });

        }
    }
}
