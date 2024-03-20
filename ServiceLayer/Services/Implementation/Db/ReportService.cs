using AutoMapper;
using AutoMapper.QueryableExtensions;
using DataLayer.DbObject;
using DataLayer.Enums;
using Microsoft.EntityFrameworkCore;
using RepoLayer.Interface;
using ServiceLayer.DTOs;
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

        public IQueryable<T> GetReportList<T>()
        {
           var list = repos.Reports.GetList()
                .Include(r=>r.Sender)
                .Include(r=>r.Account)
                .Include(r=>r.Group)
                .Include(r=>r.File)
                .Include(r=>r.Discussion);
            if(list == null || !list.Any()) {
                return null;
            }
            var mapped = list.ProjectTo<T>(mapper.ConfigurationProvider);
            return mapped;
        }

        public async Task CreateReport(ReportCreateDto dto, int senderId)
        {
            Report report = new Report()
            {
                SenderId = senderId,
                Detail = dto.Detail,
                AccountId = dto.AccountId,
                DiscussionId = dto.DiscussionId,
                FileId = dto.FileId,
                GroupId = dto.GroupId,
                State = RequestStateEnum.Waiting,
            };
            await repos.Reports.CreateAsync(report);
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
