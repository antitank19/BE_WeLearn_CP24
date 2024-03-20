using DataLayer.Enums;
using ServiceLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interface.Db
{
    public interface IReportService
    {
        public IQueryable<T> GetReportList<T>();
        public Task ResolveReport(int reportId, RequestStateEnum newState);
        public Task CreateReport(ReportCreateDto dto, int reporterId);
        public Task<bool> IsReportExist(int reportId);

    }
}
