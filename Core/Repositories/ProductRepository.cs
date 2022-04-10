
using Core.Data;
using Core.InterFaces;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Core.Repositories
{
    public class ProductRepository: IBaseRespository<Product>
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context) 
        {
            _context = context;
        }

        

        public async Task<IEnumerable<Product>> GetByAll()
        {
            return await _context.Products
               .Include(p => p.ProductBrand)
               .Include(p => p.ProductType).ToListAsync();

        }
    }
}
