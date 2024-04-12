using API.SwaggerOption.Const;
using APIExtension.Validator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTOs;
using ServiceLayer.Services.Interface;

namespace API.Controllers
{
    public class AnswerDiscussionsController : Controller
    {
        private readonly IServiceWrapper services;
        //private readonly IMapper mapper;
        //private readonly IValidatorWrapper validators;

        public AnswerDiscussionsController(
            //IValidatorWrapper validators,
            IServiceWrapper services
        )
        {
            this.services = services;
            //this.validators = validators;
        }

        [Authorize(Roles = Actor.Student)]
        [HttpGet("api/AnswerDiscussion/Get")]
        public async Task<IActionResult> GetAnswerDiscussionByDiscussionId(int discussionId)
        {
            ValidatorResult valResult = new ValidatorResult();
            try
            {
                var discussions = await services.AnswersDiscussions.GetAnswerDiscussionByDiscussionId(discussionId);
                return Ok(discussions);
            }
            catch (Exception ex)
            {
                valResult.Add(ex.ToString());
                return BadRequest(valResult);
            }
        }

        [Authorize(Roles = Actor.Student)]
        [HttpPost("api/AnswerDiscussion/Upload")]
        public async Task<IActionResult> UploadAnswerDiscussion(int accountId, int discussionId, UploadAnswerDiscussionDto dto)
        {
            ValidatorResult valResult = new ValidatorResult();
            try
            {
                var ansDis = await services.AnswersDiscussions.UploadAnswerDiscussion(accountId, discussionId, dto);
                return Ok(ansDis);
            }
            catch (Exception ex)
            {
                valResult.Add(ex.ToString());
                return BadRequest(valResult);
            }
        }

        [Authorize(Roles = Actor.Student)]
        [HttpPut("api/AnswerDiscussion/Update")]
        public async Task<IActionResult> UpdateAnswerDiscussion(int discussionId, UploadAnswerDiscussionDto dto)
        {
            ValidatorResult valResult = new ValidatorResult();
            try
            { 
                var ansDis = await services.AnswersDiscussions.UpdateAnswerDiscussion(discussionId, dto);
                return Ok(ansDis);
            }
            catch (Exception ex)
            {
                valResult.Add(ex.ToString());
                return BadRequest(valResult);
            }
        }
    }
}
