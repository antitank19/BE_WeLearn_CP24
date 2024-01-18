using DataLayer.DbContext;
using DataLayer.DbObject;

namespace RepositoryLayer.Interface
{
    public interface ISubjectRepository
    {
        IQueryable<Subject> GetList();
    }
}