using AutoMapper;
using DataLayer.DbObject;
using DataLayer.Enums;
using RepoLayer.Interface;
using ServiceLayer.Services.Interface.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Implementation.Db
{
    public class ReportService : IReportService
    {
        private IRepoWrapper repos;
        private IMapper mapper;

        public ReportService(IRepoWrapper repos, IMapper mapper)
        {
            this.repos = repos;
            this.mapper = mapper;
        }

        public async Task<bool> IsReportExist(int reportId)
        {
            return await repos.Requests.IdExistAsync(reportId);
        }

        public async Task ResolveReport(int reportId, RequestStateEnum newState)
        {
            Report report = await repos.Reports.GetByIdAsync(reportId);
            report.State = newState;
            await repos.Reports.UpdateAsync(report);
        }
    }
}
