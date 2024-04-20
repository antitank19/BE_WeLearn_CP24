﻿using API.Extension.ClaimsPrinciple;
using APIExtension.Validator;
using DataLayer.DbObject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Web;
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

        //[Authorize]
        [HttpGet("All Report")]
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

        //[Authorize]
        [HttpGet("PendingReport")]
        public async Task<IActionResult> GetUresolvedReports()
        {
            ValidatorResult valResult = new ValidatorResult();
            try
            {
                var mapped = services.Reports.GetUnresolvedReportList<ReportGetListDto>();
                if (mapped == null || !mapped.Any())
                {
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


        //[Authorize]
        [HttpGet("Account")]
        public async Task<IActionResult> GetReportedAccount()
        {
            ValidatorResult valResult = new ValidatorResult();
            try
            {
                var mapped = services.Reports.GetReportedAccountList<ReportedAccountDto>();
                if (mapped == null || !mapped.Any())
                {
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

        //[Authorize]
        [HttpGet("Group")]
        public async Task<IActionResult> GetReportedGroup()
        {
            ValidatorResult valResult = new ValidatorResult();
            try
            {
                var mapped = services.Reports.GetReportedGroupList<ReportedGroupDto>();
                if (mapped == null || !mapped.Any())
                {
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

        //[Authorize]
        [HttpGet("Discussion")]
        public async Task<IActionResult> GetReportedDiscussion()
        {
            ValidatorResult valResult = new ValidatorResult();
            try
            {
                var mapped = services.Reports.GetReportedDiscussionList<ReportedDiscussionDto>();
                if (mapped == null || !mapped.Any())
                {
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

        //[Authorize]
        [HttpGet("File")]
        public async Task<IActionResult> GetReportedFile()
        {
            ValidatorResult valResult = new ValidatorResult();
            try
            {
                var mapped = services.Reports.GetReportedFileList<ReportedFileDto>();
                if (mapped == null || !mapped.Any())
                {
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

        [Authorize(Roles = "Student, Parent")]
        [HttpPost("SendReport")]
        public async Task<IActionResult> CreateReport(ReportCreateDto dto)
        {
            ValidatorResult valResult = new ValidatorResult();
            try
            {
                //valResult.ValidateParams(dto);
                int reporterId = HttpContext.User.GetUserId();
                var report = await services.Reports.CreateReport(dto, reporterId);
                return Ok(report);
            }
            catch (Exception ex)
            {
                valResult.Add(ex.ToString());
                return BadRequest(valResult);
            }
        }

        [HttpPut("AdminSolveReport")]
        public async Task<IActionResult> SolveReport(int reportId, bool isApproved)
        {
            ValidatorResult valResult = new ValidatorResult();
            try
            {
                await services.Reports.ResolveReport(reportId, isApproved);
                return Ok(isApproved);
            }
            catch (Exception ex)
            {
                valResult.Add(ex.ToString());
                return BadRequest(valResult);
            }
        }
    }
}
