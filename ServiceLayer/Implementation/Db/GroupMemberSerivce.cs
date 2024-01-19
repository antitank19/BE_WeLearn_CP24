using AutoMapper;
using RepositoryLayer.Interface;
using ServiceLayer.Interface.Db;

namespace ServiceLayer.Implementation.Db
{
    internal class GroupMemberSerivce : IGroupMemberSerivce
    {
        private IRepoWrapper repos;
        private IMapper mapper;

        public GroupMemberSerivce(IRepoWrapper repos, IMapper mapper)
        {
            this.repos = repos;
            this.mapper = mapper;
        }

    }
}