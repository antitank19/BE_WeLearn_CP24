﻿using Microsoft.AspNetCore.Http;
using System.Collections.ObjectModel;

namespace ServiceLayer.DTOs
{
    public class GroupGetListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? ImagePath { get; set; }
        public int MemberCount { get; set; }
        //public int ClassId { get; set; }
        public ICollection<DiscussionInGroupDto> Discussions { get; set; }=new Collection<DiscussionInGroupDto>();
        public ICollection<string> Subjects { get; set; }=new Collection<string>();
    }
}
