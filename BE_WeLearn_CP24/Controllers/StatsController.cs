using API.Extension.ClaimsPrinciple;
using API.SwaggerOption.Const;
using API.SwaggerOption.Endpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTOs;
using ServiceLayer.Services.Interface;
using Swashbuckle.AspNetCore.Annotations;
using API.SwaggerOption.Descriptions;
using APIExtension.Validator;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatsController : ControllerBase
    {
        private readonly IServiceWrapper services;

        public StatsController(IServiceWrapper services)
        {
            this.services = services;
        }

        [SwaggerOperation(
            Summary = StatsEndpoints.GetStatForStudentInMonthNew
            , Description = StatsDescriptions.GetStatForStudentInMonthNew
        )]
        [HttpGet("{studentId}/{month}")]
        [Authorize(Roles = Actor.Student_Parent)]
        public async Task<IActionResult> GetStatForStudentInMonthNew(int studentId, DateTime month)
        {
            ValidatorResult valResult = new ValidatorResult();
            try
            {
                if (studentId < 0)
                {
                    return NotFound();
                }
                if (HttpContext.User.IsInRole(Actor.Student) && HttpContext.User.GetUserId() != studentId)
                {
                    return Unauthorized("Bạn không thể xem dữ liệu của học sinh khác");
                }
                StatGetDto mappedStat = await services.Stats.GetStatForStudentInMonth(studentId, month);
                return Ok(mappedStat);
            }
            catch (Exception ex)
            {
                valResult.Add(ex.ToString());
                return BadRequest(valResult);
            }
        }

        [SwaggerOperation(
            Summary = StatsEndpoints.GetStatForStudent
            , Description = StatsDescriptions.GetStatForStudent
        )]
        [HttpGet("{studentId}")]
        [Authorize(Roles = Actor.Student_Parent)]
        public async Task<IActionResult> GetStatForStudent(int studentId)
        {
            ValidatorResult valResult = new ValidatorResult();
            try
            {
                if (studentId < 0)
                {
                    return NotFound();
                }
                if (HttpContext.User.IsInRole(Actor.Student) && HttpContext.User.GetUserId() != studentId)
                {
                    return Unauthorized("Bạn không thể xem dữ liệu của học sinh khác");
                }
                IList<StatGetListDto> mappedStat = await services.Stats.GetStatsForStudent(studentId);
                return Ok(mappedStat);
            }
            catch (Exception ex)
            {
                valResult.Add(ex.ToString());
                return BadRequest(valResult);
            }
        }
    }
}
