
using Models;

namespace Core.InterFaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRespository<Product> Products { get; }
        void Save();
    }
}
