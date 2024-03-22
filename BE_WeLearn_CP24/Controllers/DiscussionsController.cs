using APIExtension.Validator;
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

        [HttpGet("Get")]
        public async Task<IActionResult> GetDiscussionInGroup(int groupId)
        {
            ValidatorResult valResult = new ValidatorResult();
            try
            {
                var discussions = await services.Discussions.GetDocumentFilesByGroupId(groupId);
                return Ok(discussions);
            }
            catch (Exception ex)
            {
                valResult.Add(ex.ToString());
                return BadRequest(valResult);
            }
        }


        [HttpPost("Upload")]
        public async Task<IActionResult> UploadDiscussion(int accountId, int groupId, IFormFile? file, UploadDiscussionDto dto)
        {
            ValidatorResult valResult = new ValidatorResult();
            try
            {
                await services.Discussions.UploadDiscussion(accountId, groupId, dto, file);
                return Ok();
            }
            catch (Exception ex)
            {
                valResult.Add(ex.ToString());
                return BadRequest(valResult);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateDiscussion(int discussionId, IFormFile? file, UploadDiscussionDto dto)
        {
            ValidatorResult valResult = new ValidatorResult();
            try
            {
                await services.Discussions.UdateDiscussion(discussionId, dto, file);
                return Ok();
            }
            catch (Exception ex)
            {
                valResult.Add(ex.ToString());
                return BadRequest(valResult);
            }
        }
    }
}
