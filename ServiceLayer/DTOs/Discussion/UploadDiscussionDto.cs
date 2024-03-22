using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.DTOs.Discussion
{
    public class UploadDiscussionDto
    {
        public string? Question { get; set; }
        public string? Content { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
