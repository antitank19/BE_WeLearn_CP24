using DataLayer.DbContext;
using DataLayer.DbObject;
using Microsoft.EntityFrameworkCore;
using RepoLayer.Interface;

namespace RepoLayer.Implemention
{
    internal class ConnectionRepository : IConnectionRepository
    {
        private readonly WeLearnContext dbContext;
        public ConnectionRepository(WeLearnContext dbContext) 
        {
            this.dbContext = dbContext;
        }

        public async Task CreateAsync(Connection entity)
        {
            dbContext.Connections.Add(entity);
            dbContext.SaveChanges();
        }

        public Task<Connection> GetByIdAsync(string id)
        {
            return dbContext.Connections.FirstOrDefaultAsync(x => x.Id == id);
        }

        public IQueryable<Connection> GetList()
        {
            return dbContext.Connections;
        }

        public Task<bool> IdExistAsync(string id)
        {
            return dbContext.Connections.AnyAsync(x => x.Id == id);
        }

        public async Task RemoveAsync(string id)
        {
            var entity = await dbContext.Connections.FirstOrDefaultAsync(x => x.Id == id);
            dbContext.Connections.Remove(entity);
            dbContext.SaveChanges();
        }

        public Task UpdateAsync(Connection entity)
        {
            throw new NotImplementedException();
        }

        public async Task CreateConnectionSignalrAsync(Connection connection)
        {
            dbContext.Connections.Add(connection);
            await dbContext.SaveChangesAsync();
        }
    }
}