using API.SwaggerOption.Const;
using APIExtension.Validator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTOs;
using ServiceLayer.Services.Interface;

namespace API.Controllers
{
    public class DiscussionsController : Controller
    {
        private readonly IServiceWrapper services;
        //private readonly IMapper mapper;
        //private readonly IValidatorWrapper validators;

        public DiscussionsController(
            //IValidatorWrapper validators,
            IServiceWrapper services
        )
        {
            this.services = services;
            //this.validators = validators;
        }

        [Authorize(Roles = Actor.Student)]
        [HttpGet("api/Discussion/Get/{groupId}")]
        public async Task<IActionResult> GetDiscussionInGroup(int groupId)
        {
            ValidatorResult valResult = new ValidatorResult();
            try
            {
                var discussions = await services.Discussions.GetDiscussionsByGroupId(groupId);
                return Ok(discussions);
            }
            catch (Exception ex)
            {
                valResult.Add(ex.ToString());
                return BadRequest(valResult);
            }
        }

        [Authorize(Roles = Actor.Student)]
        [HttpGet("api/Discussion/GetByDiscussionId/")]
        public async Task<IActionResult> GetDiscussionDetail(int dicussionId)
        {
            ValidatorResult valResult = new ValidatorResult();
            try
            {
                var discussions = await services.Discussions.GetDiscussionById(dicussionId);
                return Ok(discussions);
            }
            catch (Exception ex)
            {
                valResult.Add(ex.ToString());
                return BadRequest(valResult);
            }
        }


        [Authorize(Roles = Actor.Student)]
        [HttpPost("api/Discussion/Upload")]
        public async Task<IActionResult> UploadDiscussion(int accountId, int groupId, [FromForm] UploadDiscussionDto dto)
        {
            ValidatorResult valResult = new ValidatorResult();
            try
            {
                var discussion = await services.Discussions.UploadDiscussion(accountId, groupId, dto);
                return Ok(discussion);
            }
            catch (Exception ex)
            {
                valResult.Add(ex.ToString());
                return BadRequest(valResult);
            }
        }

        //[Authorize(Roles = Actor.Student)]
        public class FileInput
        {
            public IFormFile file { get; set; }
        }
        [HttpPost("api/Discussion/Upload/File")]
        public async Task<IActionResult> UploadDiscussionFile([FromForm] FileInput file)
        {
            ValidatorResult valResult = new ValidatorResult();
            try
            {
                var url = await services.Discussions.UploadDiscussionFile(file.file);
                return Ok(url);
            }
            catch (Exception ex)
            {
                valResult.Add(ex.ToString());
                return BadRequest(valResult);
            }
        }

        [Authorize(Roles = Actor.Student)]
        [HttpPut("api/Discussion/Update")]
        public async Task<IActionResult> UpdateDiscussion(int discussionId, UploadDiscussionDto dto)
        {
            ValidatorResult valResult = new ValidatorResult();
            try
            {
                var discussion = await services.Discussions.UdateDiscussion(discussionId, dto);
                return Ok(discussion);
            }
            catch (Exception ex)
            {
                valResult.Add(ex.ToString());
                return BadRequest(valResult);
            }
        }
    }
}
