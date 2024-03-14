using API.Extension.ClaimsPrinciple;
using API.SignalRHub;
using API.SwaggerOption.Const;
using API.SwaggerOption.Descriptions;
using API.SwaggerOption.Endpoints;
using APIExtension.Validator;
using AutoMapper;
using DataLayer.DbObject;
using DataLayer.Enums;
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
    public class GroupMembersController : ControllerBase
    {
        private readonly IServiceWrapper services;
        //private readonly IValidatorWrapper validators;
        //private readonly IMapper mapper;
        private readonly IHubContext<GroupHub> groupHub;

        public GroupMembersController(
            IServiceWrapper services, 
            //IValidatorWrapper validators, 
            //IMapper mapper, 
            IHubContext<GroupHub> groupHub
        )
        {
            this.services = services;
            //this.validators = validators;
            //this.mapper = mapper;
            this.groupHub = groupHub;
        }

        //GET: api/GroupMember/Group/{groupId}
        [SwaggerOperation(
            Summary = GroupMembersEndpoints.GetJoinMembersForGroup
        )]
        [Authorize(Roles = Actor.Student)]
        [HttpGet("Group/{groupId}")]
        public async Task<IActionResult> GetJoinMembersForGroup(int groupId)
        {
            int studentId = HttpContext.User.GetUserId();
            bool isJoined = await services.Groups.IsStudentJoiningGroupAsync(studentId, groupId);
            if (!isJoined)
            {
                return Unauthorized("Bạn không phải là thành viên nhóm này");
            }
            IQueryable<AccountProfileDto> mapped = services.GroupMembers.GetMembersJoinForGroup(groupId);
            if (mapped == null || !mapped.Any())
            {
                return NotFound();
            }

            return Ok(mapped);
        }

        //GET: api/GroupMember/Invite/Group/groupId
        [SwaggerOperation(
            Summary = GroupMembersEndpoints.GetInviteForGroup
        )]
        [Authorize(Roles = Actor.Student)]
        [HttpGet("Invite/Group/{groupId}")]
        public async Task<IActionResult> GetInviteForGroup(int groupId)
        {
            int studentId = HttpContext.User.GetUserId();
            bool isLead = await services.Groups.IsStudentLeadingGroupAsync(studentId, groupId);
            if (!isLead)
            {
                return Unauthorized("Bạn không phải nhóm trưởng của nhóm này");
            }
            IQueryable<JoinInviteForGroupGetDto> mapped = services.GroupMembers.GetJoinInviteForGroup(groupId);
            if (mapped == null || !mapped.Any())
            {
                return NotFound();
            }

            return Ok(mapped);
        }

        //GET: api/GroupMember/Request/Group/groupId
        [SwaggerOperation(
            Summary = GroupMembersEndpoints.GetRequestForGroup
        )]
        [Authorize(Roles = Actor.Student)]
        [HttpGet("Request/Group/{groupId}")]
        public async Task<IActionResult> GetRequestForGroup(int groupId)
        {
            int studentId = HttpContext.User.GetUserId();
            bool isLead = await services.Groups.IsStudentLeadingGroupAsync(studentId, groupId);
            if (!isLead)
            {
                return Unauthorized("Bạn không phải nhóm trưởng của nhóm này");
            }
            IQueryable<JoinRequestForGroupGetDto> mapped = services.GroupMembers.GetJoinRequestForGroup(groupId);
            if (mapped == null || !mapped.Any())
            {
                return NotFound();
            }

            return Ok(mapped);
        }

        //Post: api/GroupMember/Invite
        [SwaggerOperation(
            Summary = GroupMembersEndpoints.CreateInvite
            , Description = GroupMembersDescriptions.CreateInvite
        )]
        [Authorize(Roles = Actor.Student)]
        [HttpPost("Invite")]
        public async Task<IActionResult> CreateInvite(GroupMemberInviteCreateDto dto)
        {
            ValidatorResult valResult = new ValidatorResult();
            try
            {
                int studentId = HttpContext.User.GetUserId();
                bool isLead = await services.Groups.IsStudentLeadingGroupAsync(studentId, dto.GroupId);
                if (!isLead)
                {
                    return Unauthorized("Bạn không phải nhóm trưởng của nhóm này");
                }
                #region unused code
                //if (await services.Groups.IsStudentJoiningGroupAsync(dto.AccountId, dto.GroupId))
                //{
                //    //validatorResult.Failures.Add("Học sinh đã tham gia nhóm này");
                //    return BadRequest(new { Message = "Học sinh đã tham gia nhóm này" });
                //}
                //if (await services.Groups.IsStudentInvitedToGroupAsync(dto.AccountId, dto.GroupId))
                //{
                //    //validatorResult.Failures.Add("Học sinh đã được mời tham gia nhóm này từ trước");
                //    GroupMemberInviteGetDto inviteGetDto = mapper.Map<GroupMemberInviteGetDto>( 
                //        await services.GroupMembers.GetGroupMemberOfStudentAndGroupAsync(dto.AccountId, dto.GroupId));
                //    return BadRequest(new { Message = "Học sinh đã được mời tham gia nhóm này từ trước", Previous = inviteGetDto });
                //}
                //if (await services.Groups.IsStudentRequestingToGroupAsync(dto.AccountId, dto.GroupId))
                //{
                //    //validatorResult.Failures.Add("Học sinh đã yêu cầu tham gia nhóm này từ trước");
                //    GroupMemberRequestGetDto requestGetDto = mapper.Map<GroupMemberRequestGetDto>(
                //        await services.GroupMembers.GetGroupMemberOfStudentAndGroupAsync(dto.AccountId, dto.GroupId));
                //    return BadRequest(new { Message = "Học sinh đã yêu cầu tham gia nhóm này từ trước", Previous = requestGetDto });
                //}
                //if (await services.Groups.IsStudentDeclinedToGroupAsync(dto.AccountId, dto.GroupId))
                //{
                //    //validatorResult.Failures.Add("Học sinh đã từ chối/bị từ chối tham gia nhóm này từ trước");
                //    GroupMemberGetDto getDto = mapper.Map<GroupMemberGetDto>(
                //        await services.GroupMembers.GetGroupMemberOfStudentAndGroupAsync(dto.AccountId, dto.GroupId));
                //    return BadRequest(new { 
                //        Message = "Học sinh đã từ chối/bị từ chối tham gia nhóm này từ trước. Hãy đợi tới tháng sau để thử lại", 
                //        Previous = getDto 
                //    });
                //}
                #endregion
                GroupMemberGetDto exsited = await services.GroupMembers.GetGroupMemberOfStudentAndGroupAsync<GroupMemberGetDto>(dto.AccountId, dto.GroupId);
                if (exsited != null)
                {
                    if (!exsited.IsActive)
                    {
                        //GroupMemberGetDto getDto = mapper.Map<GroupMemberGetDto>(
                        //          await services.GroupMembers.GetGroupMemberOfStudentAndGroupAsync(dto.AccountId, dto.GroupId));
                        //GroupMemberGetDto getDto = await services.GroupMembers.GetGroupMemberOfStudentAndGroupAsync(dto.AccountId, dto.GroupId);
                        return BadRequest(new
                        {
                            Message = "Học sinh đã từ chối/bị từ chối tham gia nhóm này từ trước. Hãy đợi tới tháng sau để thử lại",
                            Previous = exsited
                        });
                    }
                    switch (exsited.MemberRole)
                    {
                        case GroupMemberRole.Leader:
                            {
                                return BadRequest(new { Message = "Học sinh đã tham gia nhóm này" });
                            }
                        case GroupMemberRole.Member:
                            {
                                return BadRequest(new { Message = "Học sinh đã tham gia nhóm này" });
                            }
                        //Fix later
                        //case GroupMemberState.Inviting:
                        //    {
                        //        GroupMemberInviteGetDto inviteGetDto = mapper.Map<GroupMemberInviteGetDto>(
                        //            await services.GroupMembers.GetGroupMemberOfStudentAndGroupAsync(dto.AccountId, dto.GroupId));
                        //        return BadRequest(new { Message = "Học sinh đã được mời tham gia nhóm này từ trước", Previous = inviteGetDto });
                        //    }
                        //case GroupMemberState.Requesting:
                        //    {
                        //        GroupMemberRequestGetDto requestGetDto = mapper.Map<GroupMemberRequestGetDto>(
                        //            await services.GroupMembers.GetGroupMemberOfStudentAndGroupAsync(dto.AccountId, dto.GroupId));
                        //        return BadRequest(new { Message = "Học sinh đã yêu cầu tham gia nhóm này từ trước", Previous = requestGetDto });
                        //    }
                        //case GroupMemberRole.Banned:
                        //    {

                        //    }
                        default:
                            {
                                //GroupMemberGetDto getDto = mapper.Map<GroupMemberGetDto>(
                                //    await services.GroupMembers.GetGroupMemberOfStudentAndGroupAsync(dto.AccountId, dto.GroupId));
                                return BadRequest(new
                                {
                                    Message = "Học sinh đã có liên quan đến nhóm",
                                    Previous = exsited
                                });
                            }
                    }
                }
                await valResult.ValidateParamsAsync(services, dto, studentId);
                if (!valResult.IsValid)
                {
                    return BadRequest(valResult.Failures);
                }
                await services.GroupMembers.CreateJoinInvite(dto);

                return Ok();
            }
            catch (Exception ex)
            {
                valResult.Add(ex.ToString());
                return BadRequest(valResult);
            }
        }

        //Put: api/GroupMember/Request/{requestId}/Accept"
        [SwaggerOperation(
            Summary = GroupMembersEndpoints.AcceptRequest
            , Description = GroupMembersDescriptions.AcceptRequest
        )]
        [Authorize(Roles = Actor.Student)]
        [HttpPut("Request/{requestId}/Accept")]
        public async Task<IActionResult> AcceptRequest(int requestId)
        {
            int studentId = HttpContext.User.GetUserId();
            Request existedRequest = await services.GroupMembers.GetRequestByIdAsync(requestId);
            if (existedRequest == null)
            {
                return BadRequest("Yêu cầu tham gia không tồn tại");
            }
            if (existedRequest.State == RequestStateEnum.Approved)
            {
                return BadRequest("Yêu cầu tham gia đã được chấp nhận");
            }
            if (existedRequest.State == RequestStateEnum.Decline)
            {
                return BadRequest("Yêu cầu tham gia đã bị từ chối");
            }
            GroupMember existedMember = await services.GroupMembers
                .GetGroupMemberOfStudentAndGroupAsync<GroupMember>(existedRequest.AccountId, existedRequest.GroupId);
            if (existedMember != null)
            {
                if (!existedMember.IsActive)
                {
                    return BadRequest("Học sinh đã bị đuổi khỏi nhóm");
                }
                return BadRequest("Học sinh đã tham gia nhóm nhóm");
            }
            if (!await services.Groups.IsStudentLeadingGroupAsync(studentId, existedRequest.GroupId))
            {
                return BadRequest("Bạn không phải trưởng nhóm này");
            }
            //if (existed.State != GroupMemberState.Requesting)
            //{
            //    return BadRequest("Đây không phải yêu cầu");
            //}
            await services.GroupMembers.AcceptOrDeclineRequestAsync(existedRequest, true);
            return Ok();
        }


        //Put: api/GroupMember/Request/{requestId}/Decline"
        [SwaggerOperation(
            Summary = GroupMembersEndpoints.DeclineRequest
            , Description = GroupMembersDescriptions.DeclineRequest
        )]
        [Authorize(Roles = Actor.Student)]
        [HttpPut("Request/{requestId}/Decline")]
        public async Task<IActionResult> DeclineRequest(int requestId)
        {
            int studentId = HttpContext.User.GetUserId();
            Request existedRequest = await services.GroupMembers.GetRequestByIdAsync(requestId);
            if (existedRequest == null)
            {
                return BadRequest("Yêu cầu tham gia không tồn tại");
            }
            if (existedRequest.State == RequestStateEnum.Approved)
            {
                return BadRequest("Yêu cầu tham gia đã được chấp nhận");
            }
            if (existedRequest.State == RequestStateEnum.Decline)
            {
                return BadRequest("Yêu cầu tham gia đã bị từ chối");
            }
            GroupMember existedMember = await services.GroupMembers
                .GetGroupMemberOfStudentAndGroupAsync<GroupMember>(existedRequest.AccountId, existedRequest.GroupId);
            if (existedMember != null)
            {
                if (!existedMember.IsActive)
                {
                    return BadRequest("Học sinh đã bị đuổi khỏi nhóm");
                }
                return BadRequest("Học sinh đã tham gia nhóm nhóm");
            }
            if (!await services.Groups.IsStudentLeadingGroupAsync(studentId, existedRequest.GroupId))
            {
                return BadRequest("Bạn không phải trưởng nhóm này");
            }
            //if (existed.State != GroupMemberState.Requesting)
            //{
            //    return BadRequest("Đây không phải yêu cầu");
            //}
            await services.GroupMembers.AcceptOrDeclineRequestAsync(existedRequest, false);
            return Ok();
        }

        //GET: api/GroupMember/Invite/Student/{studentId}
        [SwaggerOperation(
            Summary = GroupMembersEndpoints.GetInviteForStudent
        )]
        [Authorize(Roles = Actor.Student)]
        [HttpGet("Invite/Student")]
        public async Task<IActionResult> GetInviteForStudent()
        {
            int studentId = HttpContext.User.GetUserId();
            IQueryable<JoinInviteForStudentGetDto> mapped = services.GroupMembers.GetJoinInviteForStudent(studentId);
            if (mapped == null || !mapped.Any())
            {
                return NotFound();
            }

            return base.Ok(mapped);
        }

        //GET: api/GroupMember/Request/Student/{studentId}
        [SwaggerOperation(
            Summary = GroupMembersEndpoints.GetRequestForStudent
        )]
        [Authorize(Roles = Actor.Student)]
        [HttpGet("Request/Student")]
        public async Task<IActionResult> GetRequestForStudent()
        {
            int studentId = HttpContext.User.GetUserId();
            IQueryable<JoinRequestForStudentGetDto> mapped = services.GroupMembers.GetJoinRequestForStudent(studentId);
            if (mapped == null || !mapped.Any())
            {
                return NotFound();
            }

            return Ok(mapped);
        }

        //POST: api/GroupMember/Request
        [SwaggerOperation(
            Summary = GroupMembersEndpoints.CreateRequest
            , Description = GroupMembersDescriptions.CreateRequest
        )]
        [Authorize(Roles = Actor.Student)]
        [HttpPost("Request")]
        public async Task<IActionResult> CreateRequest(GroupMemberRequestCreateDto dto)
        {
            ValidatorResult valResult = new ValidatorResult();
            try
            {
                int studentId = HttpContext.User.GetUserId();
                bool isLead = await services.Groups.IsStudentLeadingGroupAsync(studentId, dto.GroupId);
                if (studentId != dto.AccountId)
                {
                    return Unauthorized("Bạn không thể yêu cầu tham gia dùm người khác");
                }
                GroupMemberGetDto exsitedGroupMember = await services.GroupMembers.GetGroupMemberOfStudentAndGroupAsync<GroupMemberGetDto>(dto.AccountId, dto.GroupId);
                if (exsitedGroupMember != null)
                {
                    if (!exsitedGroupMember.IsActive)
                    {
                        return BadRequest(new
                        {
                            Message = "Bạn đã từ chối/bị từ chối tham gia nhóm này từ trước. Hãy đợi tới tháng sau để thử lại",
                            Previous = exsitedGroupMember
                        });
                    }
                    switch (exsitedGroupMember.MemberRole)
                    {
                        case GroupMemberRole.Leader:
                            {
                                return BadRequest(new { Message = "Bạn đã tham gia nhóm này" });
                            }
                        case GroupMemberRole.Member:
                            {
                                return BadRequest(new { Message = "Bạn đã tham gia nhóm này" });
                            }
                        //Fix later
                        //case GroupMemberState.Inviting:
                        //    {
                        //        GroupMemberInviteGetDto inviteGetDto = mapper.Map<GroupMemberInviteGetDto>(
                        //            await services.GroupMembers.GetGroupMemberOfStudentAndGroupAsync(dto.AccountId, dto.GroupId));
                        //        return BadRequest(new { Message = "Bạn đã được mời tham gia nhóm này từ trước", Previous = inviteGetDto });
                        //    }
                        //case GroupMemberState.Requesting:
                        //    {
                        //        GroupMemberRequestGetDto requestGetDto = mapper.Map<GroupMemberRequestGetDto>(
                        //            await services.GroupMembers.GetGroupMemberOfStudentAndGroupAsync(dto.AccountId, dto.GroupId));
                        //        return BadRequest(new { Message = "Bạn đã yêu cầu tham gia nhóm này từ trước", Previous = requestGetDto });
                        //    }
                        //case GroupMemberRole.Banned:
                        //    {
                        //        GroupMemberGetDto getDto = mapper.Map<GroupMemberGetDto>(
                        //            await services.GroupMembers.GetGroupMemberOfStudentAndGroupAsync(dto.AccountId, dto.GroupId));
                        //        return BadRequest(new
                        //        {
                        //            Message = "Bạn đã từ chối/bị từ chối tham gia nhóm này từ trước. Hãy đợi tới tháng sau để thử lại",
                        //            Previous = getDto
                        //        });
                        //    }
                        default:
                            {
                                return BadRequest(new
                                {
                                    Message = "Bạn đã có liên quan đến nhóm",
                                    Previous = exsitedGroupMember
                                });
                            }
                    }
                }
                JoinInviteForGroupGetDto exsitedInvite = await services.GroupMembers.GetInviteOfStudentAndGroupAsync<JoinInviteForGroupGetDto>(dto.AccountId, dto.GroupId);
                if (exsitedInvite != null)
                {
                    return BadRequest(new { Message = "Bạn đã được mời tham gia nhóm này từ trước", Previous = exsitedInvite });
                }
                Request exsitedRequest = await services.GroupMembers.GetRequestOfStudentAndGroupAsync(dto.AccountId, dto.GroupId);
                if (exsitedRequest != null)
                {
                    return BadRequest(new { Message = "Bạn đã yêu cầu tham gia nhóm này từ trước", Previous = exsitedInvite });
                }

                await valResult.ValidateParamsAsync(services, dto);
                if (!valResult.IsValid)
                {
                    return BadRequest(valResult.Failures);
                }
                await services.GroupMembers.CreateJoinRequest(dto);
                await groupHub.Clients.Group(dto.GroupId.ToString()).SendAsync(GroupHub.OnReloadMeetingMsg);
                return Ok();
            }
            catch (Exception ex) {
                valResult.Add(ex.ToString());
                return BadRequest(valResult);
            }
        }

        //Put: api/GroupMember/Invite/{inviteId}/Accept"
        [SwaggerOperation(
            Summary = GroupMembersEndpoints.AcceptInvite
            , Description = GroupMembersDescriptions.AcceptInvite
        )]
        [Authorize(Roles = Actor.Student)]
        [HttpPut("Invite/{inviteId}/Accept")]
        public async Task<IActionResult> AcceptInvite(int inviteId)
        {
            int studentId = HttpContext.User.GetUserId();
            Invite existedInvite = await services.GroupMembers.GetInviteByIdAsync(inviteId);
            if (existedInvite == null)
            {
                return BadRequest("Lời mời tham gia không tồn tại");
            }
            if (existedInvite.State == RequestStateEnum.Approved)
            {
                return BadRequest("Lời mời tham gia đã được chấp nhận");
            }
            if (existedInvite.State == RequestStateEnum.Decline)
            {
                return BadRequest("Lời mời tham gia đã bị từ chối");
            }
            GroupMember existedMember = await services.GroupMembers
                .GetGroupMemberOfStudentAndGroupAsync<GroupMember>(existedInvite.AccountId, existedInvite.GroupId);
            if (existedMember != null)
            {
                if (!existedMember.IsActive)
                {
                    return BadRequest("Học sinh đã bị đuổi khỏi nhóm");
                }
                return BadRequest("Học sinh đã tham gia nhóm nhóm");
            }
            if (existedInvite.AccountId != studentId)
            {
                return BadRequest("Đây không phải lời mời cho bạn");
            }
            await services.GroupMembers.AcceptOrDeclineInviteAsync(existedInvite, true);
            await groupHub.Clients.Group(existedInvite.GroupId.ToString()).SendAsync(GroupHub.OnReloadMeetingMsg);
            return Ok();
        }


        //Put: api/GroupMember/Invite/{inviteId}/Decline"
        [SwaggerOperation(
           Summary = GroupMembersEndpoints.DeclineInvite
           , Description = GroupMembersDescriptions.DeclineInvite
       )]
        [Authorize(Roles = Actor.Student)]
        [HttpPut("Invite/{inviteId}/Decline")]
        public async Task<IActionResult> DeclineInvite(int inviteId)
        {
            int studentId = HttpContext.User.GetUserId();
            Invite existedInvite = await services.GroupMembers.GetInviteByIdAsync(inviteId);
            if (existedInvite == null)
            {
                return BadRequest("Lời mời tham gia không tồn tại");
            }
            if (existedInvite.State == RequestStateEnum.Approved)
            {
                return BadRequest("Lời mời tham gia đã được chấp nhận");
            }
            if (existedInvite.State == RequestStateEnum.Decline)
            {
                return BadRequest("Lời mời tham gia đã bị từ chối");
            }
            GroupMember existedMember = await services.GroupMembers
                .GetGroupMemberOfStudentAndGroupAsync<GroupMember>(existedInvite.AccountId, existedInvite.GroupId);
            if (existedMember != null)
            {
                if (!existedMember.IsActive)
                {
                    return BadRequest("Học sinh đã bị đuổi khỏi nhóm");
                }
                return BadRequest("Học sinh đã tham gia nhóm nhóm");
            }
            if (existedInvite.AccountId != studentId)
            {
                return BadRequest("Đây không phải lời mời cho bạn");
            }
            await services.GroupMembers.AcceptOrDeclineInviteAsync(existedInvite, false);
            return Ok();
        }
        //Delete
        //: api/GroupMember/Invite/{inviteId}/Decline"
        [SwaggerOperation(
           Summary = GroupMembersEndpoints.BanMember
           , Description = GroupMembersDescriptions.BanMember
        )]
        [Authorize(Roles = Actor.Student)]
        [HttpDelete("Group/{groupId}/Account/{banAccId}")]
        public async Task<IActionResult> BanMember(int groupId, int banAccId)
        {
            int studentId = HttpContext.User.GetUserId();
            bool isLead = await services.Groups.IsStudentLeadingGroupAsync(studentId, groupId);
            if (!isLead)
            {
                return Unauthorized("Bạn không phải nhóm trưởng của nhóm này");
            }
            if (studentId == banAccId)
            {
                return Unauthorized("Bạn không thể đuổi chính mình");
            }
            GroupMember exited = await services.GroupMembers.GetGroupMemberOfStudentAndGroupAsync<GroupMember>(banAccId, groupId);
            if (exited == null)
            {
                return BadRequest("Học sinh không có tham gia nhóm này");
            }
            if (!exited.IsActive)
            {
                return BadRequest("Học sinh đã bị đuổi khỏi nhóm này");
            }
            await services.GroupMembers.BanUserFromGroupAsync(exited);
            await groupHub.Clients.Group(groupId.ToString()).SendAsync(GroupHub.OnReloadMeetingMsg);
            return Ok();
        }
        private async Task<bool> GroupMemberExists(int id)
        {
            return (await services.GroupMembers.AnyAsync(id));
        }
        private async Task<bool> InviteExists(int studentId, int groupId)
        {
            return (await services.GroupMembers.AnyInviteAsync(studentId, groupId));
        }
        private async Task<bool> RequestExists(int studentId, int groupId)
        {
            return (await services.GroupMembers.AnyRequestAsync(studentId, groupId));
        }
    }
}
