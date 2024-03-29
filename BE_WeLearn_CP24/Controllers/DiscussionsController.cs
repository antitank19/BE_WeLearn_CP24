﻿using APIExtension.Validator;
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

        [HttpGet("api/Discussion/Get/{groupId}")]
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


        [HttpPost("api/Discussion/Upload")]
        public async Task<IActionResult> UploadDiscussion(int accountId, int groupId, [FromForm] UploadDiscussionDto dto)
        {
            ValidatorResult valResult = new ValidatorResult();
            try
            {
                await services.Discussions.UploadDiscussion(accountId, groupId, dto);
                return Ok();
            }
            catch (Exception ex)
            {
                valResult.Add(ex.ToString());
                return BadRequest(valResult);
            }
        }

        [HttpPut("api/Discussion/Update")]
        public async Task<IActionResult> UpdateDiscussion(int discussionId, UploadDiscussionDto dto)
        {
            ValidatorResult valResult = new ValidatorResult();
            try
            {
                await services.Discussions.UdateDiscussion(discussionId, dto);
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
