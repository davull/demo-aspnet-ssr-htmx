using AspNetSsrDemo.Web.Data;
using AspNetSsrDemo.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetSsrDemo.Web.Controllers;

public class ProductsController : Controller
{
    public IActionResult Index()
    {
        var model = new ProductsViewModel { Products = Repository.GetAll() };
        return View(model);
    }

    public IActionResult Details(int id, bool edit = false)
    {
        var product = Repository.Get(id);
        if (product is null)
        {
            return NotFound();
        }

        var model = new ProductDetailsViewModel
        {
            Edit = edit,
            Id = product.Id,
            Sku = product.Sku,
            Name = product.Name,
            Price = product.Price,
        };

        return View(model);
    }

    [HttpPost("Details")]
    public IActionResult SaveDetails(ProductDetailsViewModel model)
    {
        var product = Repository.Get(model.Id);
        if (product is null)
        {
            return NotFound();
        }

        product = product with
        {
            Name = model.Name,
            Price = model.Price,
            Sku = model.Sku,
        };
        Repository.Save(product);

        return RedirectToAction("Index");
    }
}