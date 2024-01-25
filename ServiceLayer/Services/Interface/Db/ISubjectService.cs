using DataLayer.DbObject;

namespace ServiceLayer.Services.Interface.Db
{
    public interface ISubjectService
    {
        IQueryable<T> GetList<T>();
    }
}