using DataLayer.DbContext;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Interface;
using DataLayer.DbObject;

namespace RepositoryLayer.ClassImplement
{
    internal class MeetingRepository : BaseRepo<Meeting>, IMeetingRepository 
    {
        private readonly WeLearnContext context;

        public MeetingRepository(WeLearnContext context)
            : base(context)
        {
            this.context = context;
        }

        public override Task CreateAsync(Meeting entity)
        {
            return base.CreateAsync(entity);
        }

        public async Task<IEnumerable<Meeting>> MassCreateAsync(IEnumerable<Meeting> creatingMeetings)
        {
            //await dbContext.Meetings.AddRangeAsync(creatingMeetings);
            foreach (var item in creatingMeetings)
            {
                await dbContext.Meetings.AddAsync(item);
            }
            await dbContext.SaveChangesAsync();
            return creatingMeetings;
        }

        public override Task<Meeting> GetByIdAsync(int id)
        {
            return base.GetByIdAsync(id);
        }

        public override IQueryable<Meeting> GetList()
        {
            return base.GetList();
        }
        
        public override Task RemoveAsync(int id)
        {
            return base.RemoveAsync(id);
        }
        
        public async override Task UpdateAsync(Meeting entity)
        {
            dbContext.Meetings.Update(entity);
            await dbContext.SaveChangesAsync();
        }
    }
}