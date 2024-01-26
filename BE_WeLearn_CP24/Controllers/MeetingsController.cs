using API.Descriptions;
using API.Extension.ClaimsPrinciple;
using API.SignalRHub;
using API.SwaggerOption.Const;
using API.SwaggerOption.Endpoints;
using APIExtension.Validator;
using AutoMapper;
using DataLayer.DbObject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using ServiceLayer.DTOs;
using ServiceLayer.Services.Interface;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingsController : ControllerBase
    {
        private readonly IServiceWrapper services;
        private readonly IValidatorWrapper validators;
        //private readonly IMapper mapper;
        private readonly IHubContext<GroupHub> groupHub;

        public MeetingsController(IServiceWrapper services, IValidatorWrapper validators, IMapper mapper, IHubContext<GroupHub> groupHub)
        {
            this.services = services;
            this.validators = validators;
            //this.mapper = mapper;
            this.groupHub = groupHub;
        }

        //GET: api/Meetings/Past/Group/id
        [SwaggerOperation(
            Summary = MeetingsEndpoints.GetPastMeetingForGroup
        )]
        [Authorize(Roles = Actor.Student)]
        [HttpGet("Past/Group/{groupId}")]
        public async Task<IActionResult> GetPastMeetingForGroup(int groupId)
        {
            int studentId = HttpContext.User.GetUserId();
            bool isLeader = await services.Groups.IsStudentLeadingGroupAsync(studentId, groupId);
            if (!isLeader)
            {
                return Unauthorized("Bạn không phải nhóm trưởng của nhóm này");
            }
            var mapped = services.Meetings.GetPastMeetingsForGroup(groupId);
            return Ok(mapped);
        }

        //GET: api/Meetings/Schedule/Group/id
        [SwaggerOperation(
            Summary = MeetingsEndpoints.GetScheduleMeetingForGroup
        )]
        [Authorize(Roles = Actor.Student)]
        [HttpGet("Schedule/Group/{groupId}")]
        public async Task<IActionResult> GetScheduleMeetingForGroup(int groupId)
        {
            int studentId = HttpContext.User.GetUserId();
            bool isJoined = await services.Groups.IsStudentJoiningGroupAsync(studentId, groupId);
            if (!isJoined)
            {
                return Unauthorized("Bạn không phải là thành viên nhóm này");
            }
            //IQueryable<Meeting> list = services.Meetings.GetScheduleMeetingsForGroup(groupId);
            if (await services.Groups.IsStudentLeadingGroupAsync(studentId, groupId))
            {
                //IQueryable<ScheduleMeetingForLeaderGetDto> mapped = list.ProjectTo<ScheduleMeetingForLeaderGetDto>(mapper.ConfigurationProvider);
                IQueryable<ScheduleMeetingForLeaderGetDto> mapped = services.Meetings.GetScheduleMeetingsForGroup<ScheduleMeetingForLeaderGetDto>(groupId);
                return Ok(mapped);
            }
            else
            {
                //return Ok(list);
                //IQueryable<ScheduleMeetingGetDto> mapped = list.ProjectTo<ScheduleMeetingGetDto>(mapper.ConfigurationProvider);
                IQueryable<ScheduleMeetingForMemberGetDto> mapped = services.Meetings.GetScheduleMeetingsForGroup<ScheduleMeetingForMemberGetDto>(groupId);
                return Ok(mapped);
            }
        }

        //GET: api/Meetings/Schedule/Group/id
        [SwaggerOperation(
            Summary = MeetingsEndpoints.GetLiveMeetingForGroup
        )]
        [Authorize(Roles = Actor.Student)]
        [HttpGet("Live/Group/{groupId}")]
        public async Task<IActionResult> GetLiveMeetingForGroup(int groupId)
        {
            int studentId = HttpContext.User.GetUserId();
            bool isJoined = await services.Groups.IsStudentJoiningGroupAsync(studentId, groupId);
            if (!isJoined)
            {
                return Unauthorized("Bạn không phải là thành viên nhóm này");
            }
            var mapped = services.Meetings.GetLiveMeetingsForGroup(groupId);
            return Ok(mapped);
        }

        //GET: api/Meetings/Past/Student
        [SwaggerOperation(
            Summary = MeetingsEndpoints.GetAllMeetingForStudent
        )]
        [Authorize(Roles = Actor.Student)]
        [HttpGet("All/Student")]
        public async Task<IActionResult> GetAllMeetingForStudent()
        {
            int studentId = HttpContext.User.GetUserId();
            var mappedPast = services.Meetings.GetPastMeetingsForStudent(studentId);
            var mappedLive = services.Meetings.GetLiveMeetingsForStudent(studentId);
            var mappedSchedule = services.Meetings.GetScheduleMeetingsForStudent(studentId);

            return Ok(new { Past = mappedPast, Live = mappedLive, Schedule = mappedSchedule });
        }
        //GET: api/Meetings/Past/Student
        [SwaggerOperation(
            Summary = MeetingsEndpoints.GetPastMeetingForStudent
        )]
        [Authorize(Roles = Actor.Student)]
        [HttpGet("Past/Student")]
        public async Task<IActionResult> GetPastMeetingForStudent()
        {
            int studentId = HttpContext.User.GetUserId();
            var mapped = services.Meetings.GetPastMeetingsForStudent(studentId);
            return Ok(mapped);
        }

        //GET: api/Meetings/Past/Student/month
        [SwaggerOperation(
            Summary = MeetingsEndpoints.GetPastMeetingForStudentByMonth
            , Description = MeetingDescriptions.GetPastMeetingForStudentByMonth

        )]
        [Authorize(Roles = Actor.Student)]
        [HttpGet("Past/Student/{month}")]
        public async Task<IActionResult> GetPastMeetingForStudentByMonth(DateTime month)
        {
            int studentId = HttpContext.User.GetUserId();
            var mapped = services.Meetings.GetPastMeetingsForStudentByMonth(studentId, month);
            return Ok(mapped);
        }


        //GET: api/Meetings/Schedule/Student
        [SwaggerOperation(
            Summary = MeetingsEndpoints.GetScheduleMeetingForStudent
        )]
        [Authorize(Roles = Actor.Student)]
        [HttpGet("Schedule/Student")]
        public async Task<IActionResult> GetScheduleMeetingForStudent()
        {
            int studentId = HttpContext.User.GetUserId();
            var mapped = services.Meetings.GetScheduleMeetingsForStudent(studentId);
            return Ok(mapped);
        }

        //GET: api/Meetings/Schedule/Student/{date}
        [SwaggerOperation(
            Summary = MeetingsEndpoints.GetScheduleMeetingForStudent
        )]
        [Authorize(Roles = Actor.Student)]
        [HttpGet("Schedule/Student/{date}")]
        public async Task<IActionResult> GetScheduleMeetingForStudent(DateTime date)
        {
            int studentId = HttpContext.User.GetUserId();
            var mapped = services.Meetings.GetScheduleMeetingsForStudentByDate(studentId, date);
            return Ok(mapped);
        }

        //GET: api/Meetings/Live/Student
        [SwaggerOperation(
            Summary = MeetingsEndpoints.GetLiveMeetingForStudent
        )]
        [Authorize(Roles = Actor.Student)]
        [HttpGet("Live/Student")]
        public async Task<IActionResult> GetLiveMeetingForStudent()
        {
            int studentId = HttpContext.User.GetUserId();
            var mapped = services.Meetings.GetLiveMeetingsForStudent(studentId);
            return Ok(mapped);
        }

        [SwaggerOperation(
          Summary = MeetingsEndpoints.CreateInstantMeeting
        )]
        [Authorize(Roles = Actor.Student)]
        [HttpPost("Instant")]
        public async Task<IActionResult> CreateInstantMeeting(InstantMeetingCreateDto dto)
        {
            int studentId = HttpContext.User.GetUserId();
            bool isJoining = await services.Groups.IsStudentJoiningGroupAsync(studentId, dto.GroupId);
            if (!isJoining)
            {
                return Unauthorized("Bạn không phải thành viên của nhóm này");
            }
            ValidatorResult valResult = await validators.Meetings.ValidateParams(dto, studentId);
            if (!valResult.IsValid)
            {
                return BadRequest(valResult.Failures);
            }
            //Meeting created= await services.Meetings.CreateInstantMeetingAsync(dto);
            //LiveMeetingGetDto mappedCreated = mapper.Map<LiveMeetingGetDto>(created);
            LiveMeetingGetDto mappedCreated = await services.Meetings.CreateInstantMeetingAsync<LiveMeetingGetDto>(dto);
            await groupHub.Clients.Group(dto.GroupId.ToString()).SendAsync(GroupHub.OnReloadMeetingMsg, $"{HttpContext.User.GetUsername()} bắt đầu cuộc họp {dto.Name}");
            return Ok(mappedCreated);
        }

        [SwaggerOperation(
            Summary = MeetingsEndpoints.MassCreateScheduleMeeting,
            Description = MeetingDescriptions.MassCreateScheduleMeeting
        )]
        //[Authorize(Roles = Actor.Student)]
        [HttpPost("Mass-schedule")]
        public async Task<IActionResult> MassCreateScheduleMeeting(ScheduleMeetingMassCreateDto dto)
        {
            int studentId = HttpContext.User.GetUserId();
            bool isLeader = await services.Groups.IsStudentLeadingGroupAsync(studentId, dto.GroupId);
            if (!isLeader)
            {
                return Unauthorized("Bạn không phải nhóm trưởng của nhóm này");
            }
            ValidatorResult valResult = await validators.Meetings.ValidateParams(dto, studentId);
            if (!valResult.IsValid)
            {
                return BadRequest(valResult.Failures);
            }


            //Schedule schedule = await services.Meetings.MassCreateScheduleMeetingAsync(dto);
            //var mapped = mapper.Map<ScheduleGetDto>(schedule);
            ScheduleGetDto mapped = await services.Meetings.MassCreateScheduleMeetingAsync<ScheduleGetDto>(dto);
            //schedule.ScheduleSubjects = dto.SubjectIds.Select(sId => new ScheduleSubject() { SubjectId = (int)sId }).ToList();
            //await services.Meetings.CreateScheduleMeetingAsync(dto);
            await groupHub.Clients.Group(dto.GroupId.ToString()).SendAsync(GroupHub.OnReloadMeetingMsg, $"{HttpContext.User.GetUsername()} tạo cuộc họp {mapped.Name} mới");
            return Ok(mapped);
        }

        [SwaggerOperation(
           Summary = MeetingsEndpoints.CreateScheduleMeeting
       )]
        [Authorize(Roles = Actor.Student)]
        [HttpPost("Schedule")]
        public async Task<IActionResult> CreateScheduleMeeting(ScheduleMeetingCreateDto dto)
        {
            int studentId = HttpContext.User.GetUserId();
            bool isLeader = await services.Groups.IsStudentLeadingGroupAsync(studentId, dto.GroupId);
            if (!isLeader)
            {
                return Unauthorized("Bạn không phải nhóm trưởng của nhóm này");
            }
            ValidatorResult valResult = await validators.Meetings.ValidateParams(dto, studentId);
            if (!valResult.IsValid)
            {
                return BadRequest(valResult.Failures);
            }
            await services.Meetings.CreateScheduleMeetingAsync(dto);
            await groupHub.Clients.Group(dto.GroupId.ToString()).SendAsync(GroupHub.OnReloadMeetingMsg, $"{HttpContext.User.GetUsername()} tạo cuộc họp mới {dto.Name}");
            return Ok(dto);
        }

        [SwaggerOperation(
           Summary = MeetingsEndpoints.StartSchdeuleMeeting
       )]
        [Authorize(Roles = Actor.Student)]
        [HttpPut("Schedule/{id}/Start")]
        public async Task<IActionResult> StartSchdeuleMeeting(int id)
        {
            int studentId = HttpContext.User.GetUserId();
            Meeting meeting = await services.Meetings.GetByIdAsync<Meeting>(id);
            bool isJoining = await services.Groups.IsStudentJoiningGroupAsync(studentId, meeting.Schedule.GroupId);
            if (!isJoining)
            {
                return Unauthorized("Bạn không phải nhóm trưởng của nhóm này");
            }
            if (meeting.End != null)
            {
                return BadRequest("Meeting đã kết thúc");
            }
            if (meeting.Start != null)
            {
                return BadRequest("Meeting đã bắt đầu");
            }
            bool isLeader = await services.Groups.IsStudentLeadingGroupAsync(studentId, meeting.Schedule.GroupId);
            //phải bắt đầu trong ngày schedule
            if (meeting.ScheduleStart.Value.Date > DateTime.Today)
            {
                return BadRequest($"Meeting được hẹn vào ngày {meeting.ScheduleStart.Value.Date.ToString("dd/MM")} Nếu muốn bắt đầu vào ngày hôm nay, hãy {(isLeader ? "cập nhật lại ngày hẹn" : "yêu  cầu nhóm trưởng cập nhật lại ngày hẹn")}");
            }
            //Member ko dc bắt sớm hơn
            if (meeting.ScheduleStart.Value > DateTime.Now && !isLeader)
            {
                return BadRequest($"Thành viên không thể bắt đầu meeting sớm hơn giờ hẹn. Nếu muốn bắt đầu ngay, hãy yêu  cầu nhóm trưởng bắt đầu cuộc họp");
            }
            meeting.Start = DateTime.Now;
            await services.Meetings.StartScheduleMeetingAsync(meeting);
            //LiveMeetingGetDto mapped = mapper.Map<LiveMeetingGetDto>(meeting);
            LiveMeetingGetDto mapped = new LiveMeetingGetDto
            {
                CountMember = meeting.CountMember,
                GroupId = meeting.Schedule.GroupId,
                GroupName = meeting.Schedule.Group.Name,
                Id = meeting.Id,
                ScheduleEnd = meeting.ScheduleEnd,
                ScheduleStart = meeting.ScheduleStart,
                Start = meeting.Start.Value,
                Content = meeting.Content,
                Name = meeting.Name,
            };
            await groupHub.Clients.Group(mapped.GroupId.ToString()).SendAsync(GroupHub.OnReloadMeetingMsg, $"{HttpContext.User.GetUsername()} bắt đầu cuộc họp {meeting.Name}");
            return Ok(mapped);
        }

        [SwaggerOperation(
           Summary = MeetingsEndpoints.UpdateScheduleMeeting
        )]
        [Authorize(Roles = Actor.Student)]
        [HttpPut("Schedule/{id}")]
        public async Task<IActionResult> UpdateScheduleMeeting(int id, ScheduleMeetingUpdateDto dto)
        {
            int studentId = HttpContext.User.GetUserId();
            Meeting meeting = await services.Meetings.GetByIdAsync<Meeting>(id);
            bool isLeader = await services.Groups.IsStudentLeadingGroupAsync(studentId, meeting.Schedule.GroupId);
            if (!isLeader)
            {
                return Unauthorized("Bạn không phải thành viên của nhóm này");
            }
            //dto.Date=dto.Date.AddDays(1);
            ValidatorResult valResult = await validators.Meetings.ValidateParams(dto, studentId);
            if (!valResult.IsValid)
            {
                return BadRequest(valResult.Failures);
            }
            await services.Meetings.UpdateScheduleMeetingAsync(dto);
            //Meeting updated = await services.Meetings.GetByIdAsync(id);
            //var updatedDto = mapper.Map<ScheduleMeetingGetDto>(updated);
            ScheduleMeetingGetDto mappedUpdated = await services.Meetings.GetByIdAsync<ScheduleMeetingGetDto>(id);
            await groupHub.Clients.Group(mappedUpdated.GroupId.ToString()).SendAsync(GroupHub.OnReloadMeetingMsg, $"{HttpContext.User.GetUsername()} cập nhật cuộc họp {mappedUpdated.Name}");
            return Ok(mappedUpdated);
        }


        [SwaggerOperation(
           Summary = MeetingsEndpoints.DeleteSchdeuleMeeting
       )]
        [Authorize(Roles = Actor.Student)]
        [HttpDelete("Schedule/{id}")]
        public async Task<IActionResult> DeleteSchdeuleMeeting(int id)
        {
            int studentId = HttpContext.User.GetUserId();
            Meeting meeting = await services.Meetings.GetByIdAsync<Meeting>(id);
            bool isLeader = await services.Groups.IsStudentLeadingGroupAsync(studentId, meeting.Schedule.GroupId);
            if (!isLeader)
            {
                return Unauthorized("Bạn không phải nhóm trưởng của nhóm này");
            }
            if (meeting.End != null)
            {
                return BadRequest("Meeting đã kết thúc, không xóa được");
            }
            if (meeting.Start != null)
            {
                return BadRequest("Meeting đã bắt đầu, không xóa được");
            }
            //phải bắt đầu trong ngày schedule
            if (meeting.ScheduleStart.Value.Date < DateTime.Today)
            {
                return BadRequest("Meeting đã qua, không xóa được");
            }
            await services.Meetings.DeleteScheduleMeetingAsync(meeting);
            return Ok("Đã xóa meeting");
        }

       // [SwaggerOperation(
       //    Summary = MeetingsEndpoints.GetChildrenLiveMeeting
       //)]
       // [Authorize(Roles = Actor.Parent)]
       // [HttpGet("Children")]
       // public async Task<IActionResult> GetChildrenLiveMeeting()
       // {
       //     int parentid = HttpContext.User.GetUserId();
       //     var list = services.Meetings.GetChildrenLiveMeetings(parentid);
       //     return Ok(list);
       // }

        private async Task<bool> MeetingExists(int id)
        {
            return (await services.Meetings.AnyAsync(id));
        }
    }
}
