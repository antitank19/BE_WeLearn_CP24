using API.Extension.ClaimsPrinciple;
using API.SwaggerOption.Const;
using APIExtension.Validator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTOs;
using ServiceLayer.Services.Interface;
using System.Diagnostics.Metrics;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentFilesController : ControllerBase
    {
        private readonly IServiceWrapper services;
        //private readonly IMapper mapper;
        //private readonly IValidatorWrapper validators;

        public DocumentFilesController(
            //IValidatorWrapper validators,
            IServiceWrapper services
        )
        {
            this.services = services;
            //this.validators = validators;
        }

        [Authorize(Roles = Actor.Student)]
        [HttpGet("api/Document/Get/{groupId}")]
        public async Task<IActionResult> GetDocumentFilesInGroup(int groupId)
        {
            ValidatorResult valResult = new ValidatorResult();
            try
            {
                var documentFiles = await services.Documents.GetDocumentFilesByGroupId(groupId);
                return Ok(documentFiles);
            }
            catch (Exception ex)
            {
                valResult.Add(ex.ToString());
                return BadRequest(valResult);
            }
        }

        [Authorize(Roles = Actor.Student)]
        [HttpPost("api/Document/Upload")]
        public async Task<IActionResult> UploadDocumentFile(IFormFile file, int groupId, int accountId)
        {
            ValidatorResult valResult = new ValidatorResult();
            try
            {
                int studentId = HttpContext.User.GetUserId();
                bool isLeader = await services.Groups.IsStudentLeadingGroupAsync(studentId, groupId);

                var doc = await services.Documents.UploadDocumentFIle(file, groupId, accountId, isLeader);
                return Ok(doc);
            }
            catch (Exception ex)
            {
                valResult.Add(ex.ToString());
                return BadRequest(valResult);
            }
        }

        [Authorize(Roles = Actor.Student)]
        [HttpPost("api/Document/AproveOrReject")]
        public async Task<IActionResult> ApproveRejectDocumentFile(int documentId, int groupId, Boolean check)
        {
            ValidatorResult valResult = new ValidatorResult();
            try
            {
                int studentId = HttpContext.User.GetUserId();
                bool isLeader = await services.Groups.IsStudentLeadingGroupAsync(studentId, groupId);
                if (!isLeader)
                {
                    return Unauthorized("Bạn không phải nhóm trưởng của nhóm này");
                }
                var doc = await services.Documents.ApproveRejectFile(documentId, check);
                return Ok(doc);
            }
            catch (Exception ex)
            {
                valResult.Add(ex.ToString());
                return BadRequest(valResult);
            }
        }
    }
}
