using DataLayer.DbObject;
using Microsoft.AspNetCore.Http;
using ServiceLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interface.Db
{
    public interface IDiscussionService
    {
        public Task<List<DiscussionDto>> GetDocumentFilesByGroupId(int groupId);
        public Task UploadDiscussion(int accountId, int groupId, UploadDiscussionDto discussionDto);
        public Task UdateDiscussion(int discussionId, UploadDiscussionDto discussionDto);
    }
}
