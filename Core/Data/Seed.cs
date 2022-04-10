
using Core.Data;
using Models;
using System.Text.Json;

namespace Infrastructure.Data
{
    public class Seed
    {
        public static async Task SeedAsync(ApplicationDbContext context)
        {

            
            if (!context.ProductTypes.Any())
            {
                var typeData = File.ReadAllText(@"../Core/Data/SeedData/types.json");
                var types = JsonSerializer.Deserialize<List<ProductType>>(typeData);
                foreach (var type in types) { context.ProductTypes.Add(type); }
                await context.SaveChangesAsync();
            }
            if (!context.ProductBrands.Any())
            {
                var brandsData = File.ReadAllText(@"../Core/Data/SeedData/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                foreach (var brand in brands) { context.ProductBrands.Add(brand); }
                await context.SaveChangesAsync();
            }
            if (!context.Products.Any())
            {
                var productData = File.ReadAllText(@"../Core/Data/SeedData/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productData);
                foreach (var product in products) { context.Products.Add(product); }
                await context.SaveChangesAsync();
            }

        }
    }
}
