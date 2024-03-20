using API.Extension.ClaimsPrinciple;
using APIExtension.Validator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTOs;
using ServiceLayer.Services.Interface;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IServiceWrapper services;

        public ReportsController(IServiceWrapper services)
        {
            this.services = services;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetReports()
        {
            ValidatorResult valResult = new ValidatorResult();
            try
            {
                var mapped = services.Reports.GetReportList<ReportGetListDto>();
                if(mapped == null || !mapped.Any()) { 
                valResult.Add("Không có báo cáo nào hết", ValidateErrType.NotFound);
                    return NotFound(valResult);
                }
                return Ok(mapped);
            }
            catch (Exception ex)
            {
                valResult.Add(ex.ToString());
                return BadRequest(valResult);
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateReport(ReportCreateDto dto)
        {
            ValidatorResult valResult = new ValidatorResult();
            try
            {
                //valResult.ValidateParams(dto);
                int reporterId = HttpContext.User.GetUserId();
                services.Reports.CreateReport(dto, reporterId);
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
