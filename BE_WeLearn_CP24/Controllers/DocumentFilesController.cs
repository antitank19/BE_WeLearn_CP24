using API.Extension.ClaimsPrinciple;
using API.SwaggerOption.Const;
using APIExtension.Validator;
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
        private readonly IValidatorWrapper validators;

        public DocumentFilesController(IServiceWrapper services, IValidatorWrapper validators)
        {
            this.services = services;
            this.validators = validators;
        }

        [HttpGet("DocumentFile")]
        public async Task<IActionResult> GetDocumentFilesInGroup(int groupId)
        {
            var documentFiles = await services.Documents.GetDocumentFilesByGroupId(groupId);
            return Ok(documentFiles);
        }
        // POST: DocumentFileController/Create
        [HttpPost("DocumentFile")]
        public async Task<IActionResult> UploadDocumentFile(IFormFile file, int groupId, int accountId)
        {
            await services.Documents.UploadDocumentFIle(file, groupId, accountId);
            return Ok();
        }
    }
}
