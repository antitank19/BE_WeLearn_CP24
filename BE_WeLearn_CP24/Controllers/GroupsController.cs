using API.Extension.ClaimsPrinciple;
using API.SwaggerOption.Const;
using API.SwaggerOption.Descriptions;
using API.SwaggerOption.Endpoints;
using APIExtension.Validator;
using DataLayer.DbObject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTOs;
using ServiceLayer.Services.Interface;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IServiceWrapper services;
        //private readonly IMapper mapper;
        //private readonly IValidatorWrapper validators;

        public GroupsController(
            IServiceWrapper services 
            //IValidatorWrapper validators
        )
        {
            this.services = services;
            //this.validators = validators;
        }

        // GET: api/Groups/Join
        [SwaggerOperation(
           Summary = GroupsEndpoints.SearchGroup,
           Description = GroupsDescriptions.SearchGroup
       )]
        [Authorize(Roles = Actor.Student)]
        [HttpGet("Search")]
        public async Task<IActionResult> SearchGroup(string search, bool newGroup = true)
        {
            int studentId = HttpContext.User.GetUserId();
            //IQueryable<Group> list = await services.Groups.SearchGroups(search, studentId, newGroup);
            //if (list == null || !list.Any())
            //{
            //    return NotFound();
            //}
            //var mapped = list.ProjectTo<GroupGetListDto>(mapper.ConfigurationProvider);
            IQueryable<GroupGetListDto> mapped = await services.Groups.SearchGroups<GroupGetListDto>(search, studentId, newGroup);
            return Ok(mapped);
        }

      //  [SwaggerOperation(
      //    Summary = GroupsEndpoints.SearchGroupByClass,
      //    Description = GroupsDescriptions.SearchGroupByClassa
      //)]
      //  [Authorize(Roles = Actor.Student)]
      //  [HttpGet("Search/Class")]
      //  public async Task<IActionResult> SearchGroupByClass(string Class, bool newGroup = true)
      //  {
      //      int studentId = HttpContext.User.GetUserId();
      //      //IQueryable<Group> list = await services.Groups.SearchGroupsByClass(Class, studentId, newGroup);
      //      //if (list == null || !list.Any())
      //      //{
      //      //    return NotFound();
      //      //}
      //      //var mapped = list.ProjectTo<GroupGetListDto>(mapper.ConfigurationProvider);
      //      IQueryable<GroupGetListDto> mapped = await services.Groups.SearchGroupsByClass<GroupGetListDto>(Class, studentId, newGroup);
      //      return Ok(mapped);
      //  }

        [SwaggerOperation(
          Summary = GroupsEndpoints.SearchGroupBySubject,
          Description = GroupsDescriptions.SearchGroupBySubject
      )]
        [Authorize(Roles = Actor.Student)]
        [HttpGet("Search/Subject")]
        public async Task<IActionResult> SearchGroupBySubject(string subject, bool newGroup = true)
        {
            int studentId = HttpContext.User.GetUserId();
            //IQueryable<Group> list = await services.Groups.SearchGroupsBySubject(subject, studentId, newGroup);
            //if (list == null || !list.Any())
            //{
            //    return NotFound();
            //}
            //var mapped = list.ProjectTo<GroupGetListDto>(mapper.ConfigurationProvider);
            IQueryable<GroupGetListDto> mapped = await services.Groups.SearchGroupsBySubject<GroupGetListDto>(subject, studentId, newGroup);
            return Ok(mapped);
        }

        // GET: api/Groups/Join
        [SwaggerOperation(
           Summary = GroupsEndpoints.GetJoinedGroups,
           Description = GroupsDescriptions.GetJoinedGroups
       )]
        [Authorize(Roles = Actor.Student)]
        [HttpGet("Join")]
        public async Task<IActionResult> GetJoinedGroups()
        {
            int studentId = HttpContext.User.GetUserId();
            //IQueryable<Group> list = await services.Groups.GetJoinGroupsOfStudentAsync(studentId);
            //if (list == null || !list.Any())
            //{
            //    return NotFound();
            //}
            //var mapped = list.ProjectTo<GroupGetListDto>(mapper.ConfigurationProvider);
            IQueryable<GroupGetListDto> mapped = await services.Groups.GetJoinGroupsOfStudentAsync<GroupGetListDto>(studentId);
            return Ok(mapped);
        }

        // GET: api/Groups/Member
        [SwaggerOperation(
           Summary = GroupsEndpoints.GetMemberGroups,
           Description = GroupsDescriptions.GetMemberGroups
       )]
        [Authorize(Roles = Actor.Student)]
        [HttpGet("Member")]
        public async Task<IActionResult> GetMemberGroups()
        {
            int studentId = HttpContext.User.GetUserId();
            //IQueryable<Group> list = await services.Groups.GetMemberGroupsOfStudentAsync(studentId);
            //if (list == null || !list.Any())
            //{
            //    return NotFound();
            //}
            //var mapped = list.ProjectTo<GroupGetListDto>(mapper.ConfigurationProvider);
            IQueryable<GroupGetListDto> mapped = await services.Groups.GetMemberGroupsOfStudentAsync<GroupGetListDto>(studentId);
            return Ok(mapped);
        }

        // GET: api/Groups/Member
        [SwaggerOperation(
           Summary = GroupsEndpoints.GetGroupDetailForMember,
           Description = GroupsDescriptions.GetGroupDetailForMember
       )]
        [Authorize(Roles = Actor.Student)]
        [HttpGet("Member/{groupId}")]
        public async Task<IActionResult> GetGroupDetailForMember(int groupId)
        {
            //ValidatorResult valResult=new ValidatorResult();
            //try
            //{
            //    int studentId = HttpContext.User.GetUserId();
            //    bool isLeader = await services.Groups.IsStudentMemberGroupAsync(studentId, groupId);
            //    if (!isLeader)
            //    {
            //        return Unauthorized("Bạn không phải là thành viên nhóm này");
            //    }
            //    //Group group = await services.Groups.GetFullByIdAsync<Group>(groupId);
            //    GroupGetDetailForMemberDto group = await services.Groups.GetFullByIdAsync<GroupGetDetailForMemberDto>(groupId);

            //    if (group == null)
            //    {
            //        valResult.Add("Không tìm thấy group", ValidateErrType.NotFound);
            //        return NotFound(valResult);
            //    }
            //    //GroupGetDetailForMemberDto dto = mapper.Map<GroupGetDetailForMemberDto>(group);
            //    return Ok(group);
            //}
            //catch (Exception ex) {
            //    valResult.Add(ex.ToString());
            //    return BadRequest(valResult);
            //}

            ValidatorResult valResult = new ValidatorResult();
            try
            {
                int studentId = HttpContext.User.GetUserId();
                bool isLeader = await services.Groups.IsStudentLeadingGroupAsync(studentId, groupId);
                //if (!isLeader)
                //{
                //     return Unauthorized("Bạn không phải nhóm trưởng của nhóm này");
                //}
                bool isJoining = await services.Groups.IsStudentJoiningGroupAsync(studentId, groupId);
                if (!isJoining)
                {
                    return Unauthorized("Bạn không phải thành viên của nhóm này");
                }
                //Group group = await services.Groups.GetFullByIdAsync(id);

                if (isLeader)
                {
                    //GroupDetailForLeaderGetDto dto = mapper.Map<GroupDetailForLeaderGetDto>(group);
                    GroupDetailForLeaderGetDto group = await services.Groups.GetFullByIdAsync<GroupDetailForLeaderGetDto>(groupId);
                    if (group == null)
                    {
                        valResult.Add("Không tìm thấy group", ValidateErrType.NotFound);
                        return NotFound(valResult);
                    }
                    return Ok(group);
                }
                else
                {
                    //GroupGetDetailForMemberDto dto = mapper.Map<GroupGetDetailForMemberDto>(group);
                    GroupDetailForLeaderGetDto group = await services.Groups.GetFullByIdAsync<GroupDetailForLeaderGetDto>(groupId);
                    if (group == null)
                    {
                        valResult.Add("Không tìm thấy group", ValidateErrType.NotFound);
                        return NotFound(valResult);
                    }
                    return Ok(group);
                }
            }
            catch (Exception ex)
            {
                valResult.Add(ex.ToString());
                return BadRequest(valResult);
            }
        }

        // GET: api/Groups/Lead
        [SwaggerOperation(
           Summary = GroupsEndpoints.GetLeadGroups,
           Description = GroupsDescriptions.GetLeadGroups
       )]
        [Authorize(Roles = Actor.Student)]
        [HttpGet("Lead")]
        public async Task<IActionResult> GetLeadGroups()
        {
            int studentId = HttpContext.User.GetUserId();
            //IQueryable<Group> list = await services.Groups.GetLeaderGroupsOfStudentAsync(studentId);
            //if (list == null || !list.Any())
            //{
            //    return NotFound();
            //}
            //var mapped = list.ProjectTo<GroupGetListDto>(mapper.ConfigurationProvider);
            IQueryable<GroupGetListDto> mapped = await services.Groups.GetLeaderGroupsOfStudentAsync<GroupGetListDto>(studentId);
            return Ok(mapped);
        }

        // GET: api/Groups/Lead/5
        [SwaggerOperation(
            Summary = GroupsEndpoints.GetGroupDetailForLeader,
           Description = GroupsDescriptions.GetGroupDetailForLeader
        )]
        [Authorize(Roles = Actor.Student)]
        [HttpGet("Lead/{id}")]
        public async Task<IActionResult> GetGroupDetailForLeader(int id)
        {
            ValidatorResult valResult = new ValidatorResult();
            try
            {
                int studentId = HttpContext.User.GetUserId();
                bool isLeader = await services.Groups.IsStudentLeadingGroupAsync(studentId, id);
                //if (!isLeader)
                //{
                //     return Unauthorized("Bạn không phải nhóm trưởng của nhóm này");
                //}
                bool isJoining = await services.Groups.IsStudentJoiningGroupAsync(studentId, id);
                if (!isJoining)
                {
                    return Unauthorized("Bạn không phải thành viên của nhóm này");
                }
                //Group group = await services.Groups.GetFullByIdAsync(id);

                if (isLeader)
                {
                    //GroupDetailForLeaderGetDto dto = mapper.Map<GroupDetailForLeaderGetDto>(group);
                    GroupDetailForLeaderGetDto group = await services.Groups.GetFullByIdAsync<GroupDetailForLeaderGetDto>(id);
                    if (group == null)
                    {
                        valResult.Add("Không tìm thấy group", ValidateErrType.NotFound);
                        return NotFound(valResult);
                    }
                    return Ok(group);
                }
                else
                {
                    //GroupGetDetailForMemberDto dto = mapper.Map<GroupGetDetailForMemberDto>(group);
                    GroupDetailForLeaderGetDto group = await services.Groups.GetFullByIdAsync<GroupDetailForLeaderGetDto>(id);
                    if (group == null)
                    {
                        valResult.Add("Không tìm thấy group", ValidateErrType.NotFound);
                        return NotFound(valResult);
                    }
                    return Ok(group);
                }
            }
            catch (Exception ex)
            {
                valResult.Add(ex.ToString());
                return BadRequest(valResult);
            }

        }

        // POST: api/Groups
        [SwaggerOperation(
           Summary = GroupsEndpoints.CreateGroup,
           Description = GroupsDescriptions.CreateGroup
       )]
        [Authorize(Roles = Actor.Student)]
        [HttpPost]
        public async Task<ActionResult<Group>> CreateGroup([FromForm] GroupCreateDto dto)
        {
            ValidatorResult valResult = new ValidatorResult();
            try
            {
                int creatorId = HttpContext.User.GetUserId();
                await valResult.ValidateParams(services, dto);
                if (!valResult.IsValid)
                {
                    return BadRequest(valResult);
                }
                //Group group = mapper.Map<Group>(dto);
                var group = await services.Groups.CreateAsync(dto, creatorId);

                return Ok(group);
            }
            catch (Exception ex)
            {
                valResult.Add(ex.ToString());
                return BadRequest(valResult);
            }
        }

        // PUT: api/Groups/5
        [SwaggerOperation(
         Summary = GroupsEndpoints.UpdateGroup,
         Description = GroupsDescriptions.UpdateGroup
        )]
        [Authorize(Roles = Actor.Student)]
        [HttpPut("{groupId}")]
        public async Task<IActionResult> UpdateGroup(int groupId, [FromForm] GroupUpdateDto dto)
        {
            ValidatorResult valResult = new ValidatorResult();
            try
            {
                //if (groupId != dto.Id)
                //{
                //    valResult.Add("Group Id không trùng", ValidateErrType.IdNotMatch);
                //    return BadRequest(valResult);
                //}
                int studentId = HttpContext.User.GetUserId();
                //List<int> leadGroupIds = (await services.Groups.GetLeaderGroupsIdAsync(studentId));

                if (!await services.Groups.IsStudentLeadingGroupAsync(studentId, groupId))
                {
                    valResult.Add("You can't update other's group", ValidateErrType.Unauthorized);
                    return Unauthorized(valResult);
                }
                await valResult.ValidateParams(services, dto);
                if (!valResult.IsValid)
                {
                    return BadRequest(valResult);
                }

                //Group group = await services.Groups.GetFullByIdAsync<Group>(groupId);
                var group = await services.Groups.GetFullByIdAsync<GroupDetailForLeaderGetDto>(groupId);
                if (group == null)
                {
                    valResult.Add("Không tìm thấy group", ValidateErrType.NotFound);
                    return NotFound(valResult);
                }
                try
                {
                    var obj = await services.Groups.UpdateAsync(groupId, dto);
                    //var mapped = mapper.Map<GroupDetailForLeaderGetDto>(group);
                    return Ok(obj);
                }
                catch (Exception ex)
                {
                    if (!await GroupExists(groupId))
                    {
                        valResult.Add("Không tìm thấy Id nhóm", ValidateErrType.NotFound);
                        return NotFound(valResult);
                    }
                    else
                    {
                        throw;
                    }
                }
            } 
            catch (Exception ex)
            {
                valResult.Add(ex.ToString());
                return BadRequest(valResult);
            }
        }

        // GET: api/Groups
        [Authorize(Roles = Actor.Student)]
        [SwaggerOperation(
           Summary = GroupsEndpoints.GetGroups,
           Description = GroupsDescriptions.GetAllGroups
       )]
        [HttpGet]
        public async Task<IActionResult> GetGroups()
        {
            //IQueryable<Group> list = services.Groups.GetList();
            //if (list == null || !list.Any())
            //{
            //    return NotFound();
            //}
            //var mapped = list.ProjectTo<GroupGetListDto>(mapper.ConfigurationProvider);
            var mapped = services.Groups.GetList<GroupGetListDto>();
            return Ok(mapped);
        }

        [Tags(Actor.Test)]
        [SwaggerOperation(
        Summary = GroupsEndpoints.GetGroup,
        Description = GroupsDescriptions.GetGroup
    )]
        // GET: api/Groups/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGroup(int id)
        {
            //Group group = await services.Groups.GetFullByIdAsync<Group>(id);

            //if (group == null)
            //{
            //    return NotFound();
            //}
            //GroupDetailForLeaderGetDto dto = mapper.Map<GroupDetailForLeaderGetDto>(group);
            GroupDetailForLeaderGetDto group = await services.Groups.GetFullByIdAsync<GroupDetailForLeaderGetDto>(id);
            return Ok(group);
        }

        private async Task<bool> GroupExists(int id)
        {
            return (await services.Groups.GetFullByIdAsync<Group>(id)) is not null;
        }
    }
}
