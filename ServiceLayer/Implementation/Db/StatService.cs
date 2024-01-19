using AutoMapper;
using RepositoryLayer.Interface;
using ServiceLayer.Interface;

namespace ServiceLayer.Implementation.Db
{
    public class StatService : IStatService
    {
        private IRepoWrapper repos;
        private readonly IMapper mapper;

        public StatService(IRepoWrapper repos, IMapper mapper)
        {
            this.repos = repos;
            this.mapper = mapper;
        }

       
    }
}
