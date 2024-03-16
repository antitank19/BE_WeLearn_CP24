using DataLayer.DbObject;

namespace ServiceLayer.Services.Interface.Db
{
    public interface ISubjectService
    {
        IQueryable<T> GetList<T>();
        public Task<bool> IsExistAsync(int id);
    }
}