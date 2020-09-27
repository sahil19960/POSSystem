using Microsoft.AspNetCore.Http;
using PosSystem.DataAcessLayer;
using PosSystem.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace PosSystem.Services
{
    public class DatabaseAccessService : IDatabaseAccessService
    {
        private readonly PosDbContext _posDbContext;

        public DatabaseAccessService(PosDbContext posDbContext)
        {
            _posDbContext = posDbContext;
        }

        public List<Product> GetProducts()
        {
            return _posDbContext.Products.Where(p => (p.AvailableQuantity > 0)).ToList<Product>();
        }

        public List<Product> GetProductsByCategory(int category, List<int> cartProducts)
        {
            List<Product> productsByCategory =  new List<Product>();

            var productsAlreadyInCart = _posDbContext.Products.Where(p => cartProducts.Contains(p.ProductId) && (p.AvailableQuantity > 0));

            if (category <= 0)
            {
                productsByCategory = GetProducts()
                    .Except(productsAlreadyInCart).ToList<Product>();
            }
            else
            {

                productsByCategory = _posDbContext.Products.Where(product => product.Category == category && product.AvailableQuantity > 0)
                    .Except(productsAlreadyInCart).ToList<Product>();
            }

            return productsByCategory;
        }

        public User GetUserByEmailIdAndPassword(string emailId, string password)
        {
            return _posDbContext.Users.SingleOrDefault(user => user.UserEmailId == emailId && user.Password == password);
        }

        public User GetUserByUserId(int id)
        {
            return _posDbContext.Users.SingleOrDefault(user => user.UserId == id);
        }

        public List<Product> GetPosStoreItemsByNameInitials(string nameInitials, int categorySelected, List<int> cartProducts)
        {
            var productsByCategory = GetProductsByCategory(categorySelected, cartProducts);

            return productsByCategory.Where(product => product.ProductName.ToUpper().StartsWith(nameInitials)).ToList<Product>();
        }

        public Product GetPosStoreItemById(int productId)
        {
            return GetProducts().Where(p => p.ProductId == productId).SingleOrDefault();
        }

        public Invoice InsertTransactionDetails(CartItem transactionDetails, List<SalesDetails> invoiceItemDetails)
        {
            var invoice = new Invoice()
            {
                EmployeeId = GetUserByUserId(1),
                DateOfSale = DateTime.Now,
                Discount = Convert.ToDouble(transactionDetails.Discount.Split(" ")[0]),
                Vat = Convert.ToDouble(transactionDetails.Vat.Split(" ")[0])
            };

            _posDbContext.Add<Invoice>(invoice);
            _posDbContext.SaveChanges();

            var invoiceItems = new List<ItemInSalesTransaction>();

            foreach(var invoiceItem in invoiceItemDetails)
            {
                var invoiceTransactionItem = new ItemInSalesTransaction()
                {
                    InvoiceReferenceNumber = invoice,
                    ProductReferenceId = _posDbContext.Products.Where(p => p.ProductId == Convert.ToInt32(invoiceItem.ProductId)).SingleOrDefault(),
                    ConsumedQuantity = Convert.ToInt32(invoiceItem.ConsumedQuantity),
                    TotalPrice = Convert.ToDouble(invoiceItem.TotalPrice.Split(" ")[0])
                };

                invoiceItems.Add(invoiceTransactionItem);

                var product = GetPosStoreItemById(Convert.ToInt32(invoiceItem.ProductId));
                product.AvailableQuantity -= Convert.ToInt32(invoiceItem.ConsumedQuantity);
                _posDbContext.SaveChanges();

            }

            _posDbContext.SalesTransactions.AddRange(invoiceItems);
            _posDbContext.SaveChanges();

            return invoice;
        }
    }
}
