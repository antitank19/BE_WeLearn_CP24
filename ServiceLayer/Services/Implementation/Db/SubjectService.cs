using DataLayer.DbObject;
using RepositoryLayer.Interface;
using ServiceLayer.Services.Interface.Db;

namespace ServiceLayer.Services.Implementation.Db
{
    internal class SubjectService : ISubjectService
    {
        private IRepoWrapper repos;

        public SubjectService(IRepoWrapper repos)
        {
            this.repos = repos;
        }

        public IQueryable<Subject> GetList()
        {
            return repos.Subjects.GetList();
        }
    }
}