using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Annotations;
using AutoMapper;
using ServiceLayer.Services.Interface;
using ServiceLayer.DTOs;
using API.SwaggerOption.Const;
using API.SwaggerOption.Endpoints;
using APIExtension.Validator;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly IServiceWrapper services;
        //private readonly IMapper mapper;

        public SubjectsController(IServiceWrapper services, IMapper mapper)
        {
            this.services = services;
            //this.mapper = mapper;
        }

        // GET: api/Subjects
        [SwaggerOperation(
            Summary = SubjectsEndpoints.GetSubject
        )]
        [Authorize(Roles = Actor.Student_Admin)]
        [HttpGet]
        public async Task<IActionResult> GetSubject()
        {
            ValidatorResult valResult = new ValidatorResult();
            try
            { 
                IQueryable<SubjectGetDto> list = services.Subjects.GetList<SubjectGetDto>();
                if (list == null|| !list.Any())
                {
                   return NotFound();
                }

                return Ok(list);
            }
            catch (Exception ex)
            {
                valResult.Add(ex.ToString());
                return BadRequest(valResult);
            }
        }
    }
}
