using DataLayer.DbContext;
using DataLayer.DbObject;
using Microsoft.EntityFrameworkCore;
using RepoLayer.Implemention;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoLayer.Implement
{
    public class DiscussionRepository : BaseRepo<Discussion>, IDiscussionRepository
    {
        private readonly WeLearnContext dbContext;

        public DiscussionRepository(WeLearnContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
        public override Task<Discussion> GetByIdAsync(int id)
        {
            return base.GetByIdAsync(id);
        }
        public override Task CreateAsync(Discussion entity)
        {
            return base.CreateAsync(entity);
        }

        public async Task<List<Discussion>> GetDocumentFilesByGroupId(int groupId)
        {
            return await dbContext.Discussions
                .Include(e => e.Account)
                .Include(e => e.Group)
                .Include(e => e.AnswerDiscussion)
                .Where(x => x.GroupId == groupId).ToListAsync();
        }
    }
}
