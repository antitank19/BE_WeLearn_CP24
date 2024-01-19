using AutoMapper;
using RepositoryLayer.Interface;
using ServiceLayer.Interface.Db;

namespace ServiceLayer.Implementation.Db
{
    internal class MeetingService : IMeetingService
    {
        private IRepoWrapper repos;
        private IMapper mapper;

        public MeetingService(IRepoWrapper repos, IMapper mapper)
        {
            this.repos = repos;
            this.mapper = mapper;
        }

    }
}