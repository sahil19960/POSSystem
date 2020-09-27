using PosSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PosSystem.Services
{
    public interface IDatabaseAccessService
    {
        public User GetUserByEmailIdAndPassword(string emailId, string password);
        public List<Product> GetProducts();
        public List<Product> GetProductsByCategory(int category, List<int> cartProducts);
        public List<Product> GetPosStoreItemsByNameInitials(string nameInitials, int categorySelected, List<int> cartProducts);
        public Product GetPosStoreItemById(int productId);
        public Invoice InsertTransactionDetails(CartItem transactionDetails, List<SalesDetails> invoiceItemDetails);
    }
}
