using DataLayer.DbContext;
using DataLayer.DbObject;

namespace RepositoryLayer.Interface
{
    public interface IAccountRepo : IBaseRepo<Account>
    {
        Task<Account> GetByUsernameAsync(string email);
        Task<Account> GetByUsernameOrEmailAndPasswordAsync(string usernameOrEmail, string password);
        Task<Account> GetProfileByIdAsync(int id);
        Task<Account> GetByEmailAsync(string email);
    }
}