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
    public class DocumentFileRepository : BaseRepo<DocumentFile>, IDocumentFileReposity
    {
        private readonly WeLearnContext dbContext;

        public DocumentFileRepository(WeLearnContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<DocumentFile>> GetDocumentFilesByGroupId(int groupId)
        {
            return await dbContext.DocumentFiles
                .Include(e => e.Account)
                .Include(e => e.Group)
                .Where(x => x.GroupId == groupId).ToListAsync();
        }
        public override Task CreateAsync(DocumentFile entity)
        {
            return base.CreateAsync(entity);
        }

        public Task ApproveRejectAsync(DocumentFile entity)
        {
            return base.UpdateAsync(entity);
        }
    }
}
