using DataLayer.DbContext;
using DataLayer.DbObject;

namespace RepositoryLayer.Interface
{
    public interface IAccountRepo : IBaseRepo<Account>
    {
    }
}