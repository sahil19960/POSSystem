using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PosSystem.Models;
using PosSystem.Services;
using System.Collections.Generic;
using System.Diagnostics;

namespace PosSystem.Controllers
{
    public class PosDashboardController : Controller
    {
        private readonly IDatabaseAccessService _databaseAccessService;

        public PosDashboardController(IDatabaseAccessService databaseAccessService)
        {
            _databaseAccessService = databaseAccessService;
        }

        public IActionResult PosDashboard()
        {
            if(HttpContext.Session.GetInt32("User") == null)
            {
                return RedirectToAction("Login", "Login");
            }

            var products = _databaseAccessService.GetProducts();

            return View(products);
        }

        [HttpPost]
        public IActionResult GetPosStoreItemsByCategory(int category, List<int> cartProducts)
        {
            var products = _databaseAccessService.GetProductsByCategory(category, cartProducts);

            return PartialView("_PosStorePartial", products);
        }

        public IActionResult GetPosStoreItemsByNameInitials(string nameInitials, int categorySelected, List<int> cartProducts)
        {
            nameInitials = nameInitials ?? "";
            var products = _databaseAccessService.GetPosStoreItemsByNameInitials(nameInitials.ToUpper(), categorySelected, cartProducts);

            return PartialView("_PosStorePartial", products);
        }

        public IActionResult GetPosStoreItemById(int productId)
        {
            var product = _databaseAccessService.GetPosStoreItemById(productId);

            return PartialView("_PosCartItemPartial", product);
        }

        [HttpPost]
        public IActionResult SaveSalesTransactionDetails(CartItem transactionDetails, List<SalesDetails> invoiceItemDetails)
        {
            var invoice =_databaseAccessService.InsertTransactionDetails(transactionDetails, invoiceItemDetails);

            return Json(invoice);
        }

    }
}
