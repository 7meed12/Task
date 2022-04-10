
namespace Core.InterFaces
{
    public interface IBaseRespository<T> where T : class
    {
       Task<IEnumerable<T>> GetByAll();
    }
}
