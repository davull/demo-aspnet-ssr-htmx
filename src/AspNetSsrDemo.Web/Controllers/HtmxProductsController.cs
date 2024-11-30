using AspNetSsrDemo.Web.Data;
using AspNetSsrDemo.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetSsrDemo.Web.Controllers;

// HTMX: https://htmx.org

public class HtmxProductsController : Controller
{
    public IActionResult Index()
    {
        var model = new ProductsViewModel { Products = Repository.GetAll() };
        return View(model);
    }

    public IActionResult Search(string query)
    {
        var products = Repository.GetAll();

        if (!string.IsNullOrEmpty(query))
        {
            products = products.Where(p =>
                    p.Name.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                    p.Sku.Contains(query, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        var model = new ProductsViewModel { Products = products };

        return PartialView("_HtmxProductsTable", model);
    }
}