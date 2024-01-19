using DataLayer.DbObject;

namespace ServiceLayer.Interface.Db
{
    public interface ISubjectService
    {
        IQueryable<Subject> GetList();
    }
}