using DataLayer.DbContext;
using DataLayer.DbObject;
using RepoLayer.Interface;

namespace RepoLayer.Implemention
{
    internal class ReportRepository : BaseRepo<Report>, IReportRepository
    {
        public ReportRepository(WeLearnContext dbContext) : base(dbContext)
        {
        }
    }
}