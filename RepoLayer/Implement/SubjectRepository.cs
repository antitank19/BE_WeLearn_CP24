using DataLayer.DbContext;
using DataLayer.DbObject;
using RepositoryLayer.Interface;

namespace RepositoryLayer.ClassImplement
{
    internal class SubjectRepository : ISubjectRepository
    {
        private WeLearnContext dbContext;

        public SubjectRepository(WeLearnContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IQueryable<Subject> GetList()
        {
           return dbContext.Subjects.AsQueryable();
        }
    }
}