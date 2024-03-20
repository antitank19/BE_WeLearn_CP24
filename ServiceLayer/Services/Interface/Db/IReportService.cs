using DataLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interface.Db
{
    public interface IReportService
    {
        public Task ResolveReport(int reportId, RequestStateEnum newState);
        public Task<bool> IsReportExist(int reportId);

    }
}
