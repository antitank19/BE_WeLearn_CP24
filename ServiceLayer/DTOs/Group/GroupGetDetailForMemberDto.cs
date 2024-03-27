﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.DTOs
{
    public class GroupGetDetailForMemberDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? ImagePath { get; set; }

        //public int ClassId { get; set; }

        public ICollection<StudentGetDto> Members { get; set; }
        public virtual ICollection<LiveMeetingGetDto> LiveMeetings { get; set; }
        public virtual ICollection<ScheduleMeetingGetDto> ScheduleMeetings { get; set; }
        public ICollection<SubjectGetDto> Subjects { get; set; }
    }
}
