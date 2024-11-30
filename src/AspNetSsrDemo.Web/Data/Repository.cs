namespace AspNetSsrDemo.Web.Data;

public static class Repository
{
    private static readonly List<Product> Products = Initialize();

    private static List<Product> Initialize()
    {
        return
        [
            new(1, "APL-IPH14", "Apple iPhone 14", 999.99m),
            new(2, "SMSG-GS23", "Samsung Galaxy S23", 849.99m),
            new(3, "GGL-PXL7", "Google Pixel 7", 649.99m),
            new(4, "APL-MBP16", "Apple MacBook Pro 16\"", 2499.99m),
            new(5, "DL-XPS15", "Dell XPS 15", 1999.99m),
            new(6, "SMRT-WTCH4", "Samsung Galaxy Watch 4", 199.99m),
            new(7, "SNYP-PS5", "Sony PlayStation 5", 499.99m),
            new(8, "MS-XBX", "Microsoft Xbox Series X", 499.99m),
            new(9, "BOSE-QC45", "Bose QuietComfort 45", 329.99m),
            new(10, "JBL-CHRG5", "JBL Charge 5 Bluetooth Speaker", 179.99m),
            new(11, "APL-IPAD10", "Apple iPad 10th Gen", 449.99m),
            new(12, "AMZN-KDL12", "Amazon Kindle Paperwhite", 129.99m),
            new(13, "LG-OLED65C3", "LG OLED 65\" C3", 1799.99m),
            new(14, "SNYP-WH1000XM5", "Sony WH-1000XM5 Headphones", 399.99m),
            new(15, "HP-OMEN17", "HP Omen 17 Gaming Laptop", 1599.99m),
            new(16, "NIN-SWOL", "Nintendo Switch OLED Model", 349.99m),
            new(17, "GAR-FR955", "Garmin Forerunner 955", 499.99m),
            new(18, "DY-VC15", "Dyson V15 Detect Vacuum", 749.99m),
            new(19, "STM-MB7", "Steam Deck 512GB", 649.99m),
            new(20, "RZ-KRAKENV3", "Razer Kraken V3 Pro Headset", 199.99m),
            new(21, "APL-WCHSER7", "Apple Watch Series 7", 399.99m),
            new(22, "SMSG-TAB8", "Samsung Galaxy Tab S8", 699.99m),
            new(23, "GGL-NESTHUB2", "Google Nest Hub 2nd Gen", 99.99m),
            new(24, "MS-SURF9", "Microsoft Surface Pro 9", 1299.99m),
            new(25, "RZ-DEATHADDER", "Razer DeathAdder V3 Mouse", 69.99m),
            new(26, "APL-AIRP3", "Apple AirPods 3rd Gen", 179.99m),
            new(27, "SMRT-TV55", "Samsung 55\" QLED Smart TV", 1099.99m),
            new(28, "DJI-MINI3", "DJI Mini 3 Drone", 799.99m),
            new(29, "BL-BOLT360", "Belkin Bolt 360 Power Bank", 59.99m),
            new(30, "KRK-RKT5", "KRK Rokit 5 Studio Monitor", 149.99m),
            new(31, "LG-ULTRAG34", "LG UltraGear 34\" Gaming Monitor", 899.99m),
            new(32, "LOGI-MXKEYS", "Logitech MX Keys Keyboard", 99.99m),
            new(33, "SONY-BRX4K", "Sony Blu-ray 4K Player", 249.99m),
            new(34, "MS-SFPLAT", "Microsoft Surface Laptop 5", 1199.99m),
            new(35, "TP-LINKAXE75", "TP-Link AXE75 WiFi 6E Router", 199.99m),
            new(36, "HDD-SEAGATE8T", "Seagate 8TB External Hard Drive", 179.99m),
            new(37, "HYP-XCLOUD2", "HyperX Cloud II Gaming Headset", 99.99m),
            new(38, "WD-BLACK2T", "WD Black 2TB NVMe SSD", 199.99m),
            new(39, "PHI-HUEBRI", "Philips Hue Bridge", 49.99m),
            new(40, "CRDS-RTX4070", "NVIDIA GeForce RTX 4070 GPU", 599.99m)
        ];
    }

    private static int NextId() => Products.Max(p => p.Id) + 1;

    public static IReadOnlyCollection<Product> GetAll() => Products;

    public static Product? Get(int id) => Products.Find(p => p.Id == id);

    public static void Save(Product product)
    {
        if (product.Id == 0)
        {
            product = product with { Id = NextId() };
        }

        var existingProduct = Get(product.Id);
        if (existingProduct is not null)
        {
            Products.Remove(existingProduct);
        }

        Products.Add(product);
    }
}

public record Product(int Id, string Sku, string Name, decimal Price);