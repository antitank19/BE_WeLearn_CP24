﻿using DataLayer.Enums;
using Microsoft.AspNetCore.Http;

namespace ServiceLayer.DTOs
{
    public class GroupUpdateDto : BaseUpdateDto
    {
        public int Id { get; set; }
        private string? name;

        public string? Name
        {
            get { return name; }
            set { name = value.Trim(); }
        }
        public IFormFile? Image { get; set; }
        //public int? ClassId { get; set; }
        public virtual ICollection<SubjectEnum>? SubjectIds { get; set; }
    }
}
