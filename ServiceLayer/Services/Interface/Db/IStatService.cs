using ServiceLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interface.Db
{
    public interface IStatService
    {
        public Task<StatGetDto> GetStatForStudentInMonth(int studentId, DateTime month);

        public Task<IList<StatGetListDto>> GetStatsForStudent(int studentId);
    }
}
