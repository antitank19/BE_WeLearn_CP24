using DataLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.DTO
{
    public class GroupCreateDto : BaseCreateDto
    {
        private string name;

        public string Name
        {
            get { return name.Trim(); }
            set { name = value.Trim(); }
        }

        public int ClassId { get; set; }
        public virtual ICollection<SubjectEnum> SubjectIds { get; set; }

    }
}
