using Core.Data;
using Core.InterFaces;
using Models;

namespace Core.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IBaseRespository<Product> Products { get; private set; }
        public UnitOfWork(ApplicationDbContext conetxt)
        {
            _context = conetxt;
            Products=new ProductRepository(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
