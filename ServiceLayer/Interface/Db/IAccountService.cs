using DataLayer.DbObject;
using ServiceLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interface.Db
{
    public interface IAccountService 
    {
        public IQueryable<T> GetList<T>();
        public Task<T> GetByIdAsync<T>(int id);
        /// <summary>
        /// Create a group and add group leader
        /// </summary>
        /// <param name="account"></param>
        /// <param name="creatorId">id of creator account id</param>
        /// <returns></returns>
        public Task CreateAsync(Account account);
        public Task UpdateAsync(AccountUpdateDto account);
        public Task UpdatePasswordAsync(AccountChangePasswordDto dto);
        public Task RemoveAsync(int id);
        public Task<Account> GetAccountByUserNameAsync(string userName);
        public Task<Account> GetAccountByEmailAsync(string email);
        public Task<T> GetProfileByIdAsync<T>(int id);
        public IQueryable<T> SearchStudents<T>(string search, int? groupId, int? parentId);
        public Task<bool> ExistAsync(int id);
        public Task<bool> ExistUsernameAsync(string username);
        public Task<bool> ExistEmailAsync(string email);
    
    }
}
