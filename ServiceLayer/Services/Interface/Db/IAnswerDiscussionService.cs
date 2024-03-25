using DataLayer.DbObject;
using Microsoft.AspNetCore.Http;
using ServiceLayer.DTOs;
using ServiceLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interface.Db
{
    public interface IAnswerDiscussionService
    {
        public Task<List<AnswerDiscussion>> GetAnswerDiscussionByDiscussionId(int discussionId);
        public Task UploadAnswerDiscussion(int accountId, int discussionId, UploadAnswerDiscussionDto answerDiscussionDto);
        public Task UpdateAnswerDiscussion(int discussionId, UploadAnswerDiscussionDto answerDiscussionDto);

    }
}
