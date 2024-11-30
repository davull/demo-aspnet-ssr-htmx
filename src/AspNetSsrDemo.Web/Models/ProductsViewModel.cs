using AspNetSsrDemo.Web.Data;

namespace AspNetSsrDemo.Web.Models;

public class ProductsViewModel
{
    public required IReadOnlyCollection<Product> Products { get; init; }

    public decimal AveragePrice => Products.Count == 0 ? 0 : Products.Average(p => p.Price);

    public decimal MinPrice => Products.Count == 0 ? 0 : Products.Min(p => p.Price);

    public decimal MaxPrice => Products.Count == 0 ? 0 : Products.Max(p => p.Price);
}