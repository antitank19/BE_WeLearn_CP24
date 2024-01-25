using AutoMapper;
using AutoMapper.QueryableExtensions;
using DataLayer.DbObject;
using RepositoryLayer.Interface;
using ServiceLayer.Services.Interface.Db;

namespace ServiceLayer.Services.Implementation.Db
{
    internal class SubjectService : ISubjectService
    {
        private IRepoWrapper repos;
        private IMapper mapper;

        public SubjectService(IRepoWrapper repos, IMapper mapper)
        {
            this.repos = repos;
            this.mapper = mapper;
        }

        public IQueryable<T> GetList<T>()
        {
            return repos.Subjects.GetList().ProjectTo<T>(mapper.ConfigurationProvider);
        }
    }
}