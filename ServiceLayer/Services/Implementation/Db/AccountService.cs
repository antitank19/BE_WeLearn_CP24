using AutoMapper;
using AutoMapper.QueryableExtensions;
using DataLayer.DbObject;
using DataLayer.Enums;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Interface;
using ServiceLayer.Utils;
using ServiceLayer.DTOs;
using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using ServiceLayer.Services.Interface.Db;

namespace ServiceLayer.Services.Implementation.Db
{
    public class AccountService : IAccountService
    {
        private IRepoWrapper repos;
        private readonly IMapper mapper;

        public AccountService(IRepoWrapper repos, IMapper mapper)
        {
            this.repos = repos;
            this.mapper = mapper;
        }
        public IQueryable<T> GetList<T>()
        {
            var list = repos.Accounts.GetList();
            var mapped = list.ProjectTo<T>(mapper.ConfigurationProvider);
            return mapped;
        }
        public IQueryable<T> SearchStudents<T>(string search, int? groupId, int? parentId)
        {
            search = search.ToLower().Trim();
            if (parentId.HasValue)
            {
                var list = repos.Accounts.GetList()
               .Include(e => e.GroupMembers).ThenInclude(e => e.Group)
               .Where(e =>
                    e.RoleId == (int)RoleNameEnum.Student
                    //&& !e.SupervisionsForStudent.Any(e => e.ParentId == parentId)
                    && (EF.Functions.Like(e.Id.ToString(), search + "%")
                    || e.Email.ToLower().Contains(search)
                    || e.Username.ToLower().Contains(search)
                    || e.FullName.ToLower().Contains(search))
               );
                var mapped = list.ProjectTo<T>(mapper.ConfigurationProvider);
                return mapped;
            }
            else if (groupId.HasValue)
            {
                var list = repos.Accounts.GetList()
                .Include(e => e.GroupMembers).ThenInclude(e => e.Group)
                .Where(e =>
                    e.RoleId == (int)RoleNameEnum.Student
                    && !e.GroupMembers.Any(e => e.GroupId == groupId)
                    && (EF.Functions.Like(e.Id.ToString(), search + "%")
                    || e.Email.ToLower().Contains(search)
                    || e.Username.ToLower().Contains(search)
                    || e.FullName.ToLower().Contains(search))
                );
                var mapped = list.ProjectTo<T>(mapper.ConfigurationProvider);
                return mapped;
            }
            else
            {
                var list = repos.Accounts.GetList()
                .Include(e => e.GroupMembers).ThenInclude(e => e.Group)
                .Where(e =>
                    e.RoleId == (int)RoleNameEnum.Student
                    && (EF.Functions.Like(e.Id.ToString(), search + "%")
                    //e.Id.ToString().Contains(search)
                    //SqlFunctions.StringConvert((double)e.Id) 
                    || e.Email.ToLower().Contains(search)
                    || e.Username.ToLower().Contains(search)
                    || e.FullName.ToLower().Contains(search))
                );
                var mapped = list.ProjectTo<T>(mapper.ConfigurationProvider);
                return mapped;
            }
        }


        public async Task<T> GetByIdAsync<T>(int id)
        {
            var user = await repos.Accounts.GetByIdAsync(id);
            var mapped = mapper.Map<T>(user);
            return mapped;
        }

        public async Task<T> GetProfileByIdAsync<T>(int id)
        {
            var user = await repos.Accounts.GetProfileByIdAsync(id);
            var mapped = mapper.Map<T>(user);
            return mapped;
        }

        public async Task<Account> GetAccountByUserNameAsync(string userName)
        {
            Account account = await repos.Accounts.GetByUsernameAsync(userName);
            return account;
        }

        public async Task<Account> GetAccountByEmailAsync(string email)
        {
            Account account = await repos.Accounts.GetList()
                .Include(a => a.Role)
                .SingleOrDefaultAsync(e => e.Email == email);
            return account;
        }

        public async Task CreateAsync(Account entity)
        {
            await repos.Accounts.CreateAsync(entity);
        }

        public async Task RemoveAsync(int id)
        {
            await repos.Accounts.RemoveAsync(id);
        }

        public async Task UpdateAsync(AccountUpdateDto dto)
        {
            Account account = await repos.Accounts.GetByIdAsync(dto.Id);
            account.PatchUpdate(dto);
            await repos.Accounts.UpdateAsync(account);
        }
        public async Task UpdatePasswordAsync(AccountChangePasswordDto dto)
        {
            var account = await repos.Accounts.GetByIdAsync(dto.Id);
            account.Password = dto.Password;
            await repos.Accounts.UpdateAsync(account);
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await repos.Accounts.IdExistAsync(id);
        }

        public async Task<bool> ExistUsernameAsync(string username)
        {
            return await repos.Accounts.GetList().AnyAsync(x => x.Username == username);
        }

        public async Task<bool> ExistEmailAsync(string email)
        {
            return await repos.Accounts.GetList().AnyAsync(x => x.Email == email);
        }


    }
}
