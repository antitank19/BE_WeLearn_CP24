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
    public class AnswerDiscussionRepository : BaseRepo<AnswerDiscussion>, IAnswerDiscussionRepository
    {
        private readonly WeLearnContext dbContext;

        public AnswerDiscussionRepository(WeLearnContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<AnswerDiscussion>> GetDocumentFilesByGroupId(int discussionId)
        {
            return await dbContext.AnswerDiscussions
                .Include(e => e.Account)
                .Include(e => e.Discussion)
                .Where(x => x.DiscussionId == discussionId).ToListAsync();
        }
    }
}
