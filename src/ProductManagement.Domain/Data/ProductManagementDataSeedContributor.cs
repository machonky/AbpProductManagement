using ProductManagement.Categories;
using ProductManagement.Products;
using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace ProductManagement.Data;

public class ProductManagementDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Category, Guid> _categoryRepository;
    private readonly IRepository<Product, Guid> _productRepository;

    public ProductManagementDataSeedContributor(IRepository<Category, Guid> categoryRepository, IRepository<Product, Guid> productRepository)
    {
        _categoryRepository = categoryRepository;
        _productRepository = productRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        if (await _categoryRepository.CountAsync() > 0)
        {
            return;
        }

        var monitors = new Category { Name = "Monitors" };
        var printers = new Category { Name = "Printers" };
        await _categoryRepository
            .InsertManyAsync(new[] { monitors, printers });
        var monitor1 = new Product
        {
            Category = monitors,
            Name = "PHILIPS - 49\" 499P9H1 32:9 5K 5120 x 1440 HDR 400 SuperWide LED Monitor with USB-C",
            Price = 7_999.00f,
            ReleaseDate = DateTime.Parse("2023-04-23"),
            StockState = ProductStockState.InStock
        }; 
        var monitor2 = new Product
        {
            Category = monitors,
            Name = "PHILIPS - 438P1/69 4K Ultra HD LCD display with MultiView",
            Price = 5_590.00f,
            ReleaseDate = DateTime.Parse("2023-05-03"),
            StockState = ProductStockState.InStock
        };
        var printer1 = new Product
        { 
            Category = printers,
            Name = "BROTHER - HLL3280CDW Color Laser Printer (duplex print)",
            Price = 2_190.00f,
            ReleaseDate = DateTime.Parse("2023-12-01"),
            StockState = ProductStockState.InStock,
        };

        await _productRepository.InsertManyAsync(new[] { monitor1, monitor2, printer1 });
    }
}
