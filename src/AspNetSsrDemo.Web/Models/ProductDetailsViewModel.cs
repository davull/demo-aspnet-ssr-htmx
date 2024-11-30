namespace AspNetSsrDemo.Web.Models;

public class ProductDetailsViewModel
{
    public required bool Edit { get; set; }
    public required int Id { get; set; }
    public required string Sku { get; set; }
    public required string Name { get; set; }
    public required decimal Price { get; set; }
}