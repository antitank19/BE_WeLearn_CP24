using DataLayer.DbContext;
using DataLayer.DbContext;
using DataLayer.DbObject;
using RepoLayer.Interface;

namespace RepoLayer.Implemention
{
    internal class GroupMemberReposity : BaseRepo<GroupMember>, IGroupMemberReposity
    {
        public GroupMemberReposity(WeLearnContext dbContext) : base(dbContext)
        {
        }

        public override Task CreateAsync(GroupMember entity)
        {
            return base.CreateAsync(entity);
        }

        public override async Task<GroupMember> GetByIdAsync(int id)
        {
            return await base.GetByIdAsync(id);
        }

        public override IQueryable<GroupMember> GetList()
        {
            return base.GetList();
        }

        public override Task RemoveAsync(int id)
        {
            return base.RemoveAsync(id);
        }

        public override Task UpdateAsync(GroupMember entity)
        {
            return base.UpdateAsync(entity);
        }
    }
}