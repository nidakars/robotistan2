using System.Threading.Tasks;

namespace robotistan.Domain.Repositories
{
    public interface IUnitOfWork
    {
         Task CompleteAsync();
    }
}