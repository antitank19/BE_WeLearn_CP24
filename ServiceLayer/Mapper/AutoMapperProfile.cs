﻿using AutoMapper;
using DataLayer.DbObject;
using DataLayer.Enums;
using ServiceLayer.DTOs;
using ServiceLayer.DTOs;

namespace ShareResource.Mapper
{
    public class AutoMapperProfile  : Profile
    {
        public AutoMapperProfile()
        {
            MapAccount();
            MapGroup();
            MapRole();
            MapGroupMember();
            MapMeeting();
            MapSubject();
            MapDocumentFile();
            MapSchedule(); 
            MapReview();
            MapChat();
            MapReport();
            MapDiscussion();
            MapAnswerDiscussion();
        }

        ///////////////////////////

        //CreateMap<src, dest>
        private void MapReport()
        {
            CreateMap<Report, ReportGetListDto>()
                .PreserveReferences();
            CreateMap<Account, ReportedAccountDto>()
               .PreserveReferences();
            CreateMap<Group, ReportedGroupDto>()
               .PreserveReferences();
            CreateMap<Discussion, ReportedDiscussionDto>()
               .PreserveReferences();
            CreateMap<DocumentFile, ReportedFileDto>()
               .PreserveReferences();
        }

        private void MapAccount()
        {
            BasicMap<Account, StudentGetDto, StudentRegisterDto, AccountUpdateDto>();
            CreateMap<Account, MemberSignalrDto>();
            CreateMap<Account, AccountProfileDto>()
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(
                    src => src.Role.Name))
                .ForMember(dest => dest.LeadGroups, opt => opt.MapFrom(
                    src => src.GroupMembers.Where(e => e.MemberRole == GroupMemberRole.Leader).Select(e => e.Group)))
                .ForMember(dest => dest.JoinGroups, opt => opt.MapFrom(
                    src => src.GroupMembers.Where(e => e.MemberRole == GroupMemberRole.Member).Select(e => e.Group)))
                //.ForMember(dest => dest.Parents, opt => opt.MapFrom(
                //    src => src.SupervisionsForStudent
                //    .Where(e => e.State == RequestStateEnum.Approved)
                //    .Select(e => e.Parent.FullName)))
                //.ForMember(dest => dest.Students, opt => opt.MapFrom(
                //    src => src.SupervisionsForParent
                //    .Where(e => e.State == RequestStateEnum.Approved)
                //    .Select(e => e.Student.FullName)))
                .PreserveReferences();
            CreateMap<Account, LoginInfoDto>()
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(
                    src => src.Role.Name))
                .ForMember(dest => dest.LeadGroups, opt => opt.MapFrom(
                    src => src.GroupMembers.Where(e => e.MemberRole == GroupMemberRole.Leader).Select(e => e.Group)))
                .ForMember(dest => dest.JoinGroups, opt => opt.MapFrom(
                    src => src.GroupMembers.Where(e => e.MemberRole == GroupMemberRole.Member).Select(e => e.Group)))
                //.ForMember(dest => dest.Parents, opt => opt.MapFrom(
                //    src => src.SupervisionsForStudent
                //    .Where(e => e.State == RequestStateEnum.Approved)
                //    .Select(e => e.Parent.FullName)))
                //.ForMember(dest => dest.Students, opt => opt.MapFrom(
                //    src => src.SupervisionsForParent
                //    .Where(e => e.State == RequestStateEnum.Approved)
                //    .Select(e => e.Student.FullName)))
                .PreserveReferences();
        }
        private void MapGroup()
        {
            CreateMap<GroupCreateDto, Group>()
                .ForMember(dest => dest.GroupSubjects, opt => opt.MapFrom(
                    src => src.SubjectIds.Select(id => new GroupSubject { SubjectId = (int)id })
                ));
            CreateMap<Group, GroupGetListDto>()
                .ForMember(dest => dest.MemberCount, opt => opt.MapFrom<int>(
                    src => src.GroupMembers
                        .Where(e => e.MemberRole == GroupMemberRole.Leader || e.MemberRole == GroupMemberRole.Member)
                        .Count()))
                .ForMember(dest => dest.Subjects, opt => opt.MapFrom(
                    src => src.GroupSubjects.Select(gs => gs.Subject.Name)))
                .PreserveReferences();

            CreateMap<Group, GroupDetailForLeaderGetDto>()
                .ForMember(dest => dest.Members, opt => opt.MapFrom(
                    src => src.GroupMembers
                        .Where(e => e.MemberRole == GroupMemberRole.Leader || e.MemberRole == GroupMemberRole.Member)
                        .Select(e => e.Account)))

                .ForMember(dest => dest.JoinRequest, opt => opt.MapFrom(
                    src => src.JoinRequests
                        .Where(e => e.State == RequestStateEnum.Waiting)))
                .ForMember(dest => dest.JoinInvite, opt => opt.MapFrom(
                    src => src.JoinInvites
                        .Where(e => e.State == RequestStateEnum.Waiting)))

                .ForMember(dest => dest.DeclineRequest, opt => opt.MapFrom(
                    src => src.JoinRequests
                        .Where(e => e.State == RequestStateEnum.Decline)))
                .ForMember(dest => dest.Subjects, opt => opt.MapFrom(
                    src => src.GroupSubjects.Select(gs => gs.Subject)))

                //Past
                .ForMember(dest => dest.PastMeetings, opt => opt.MapFrom(
                    src => src.Schedules.SelectMany(s => s.Meetings)
                        .Where(e => (e.End != null || (e.ScheduleStart != null && e.ScheduleStart.Value.Date < DateTime.Today)))))
                //Live
                .ForMember(dest => dest.LiveMeetings, opt => opt.MapFrom(
                    src => src.Schedules.SelectMany(s => s.Meetings)
                        .Where(e => e.Start != null && e.End == null)))
                //Schedule
                .ForMember(dest => dest.ScheduleMeetings, opt => opt.MapFrom(
                    src => src.Schedules.SelectMany(s => s.Meetings)
                        .Where(e => (e.ScheduleStart != null && e.ScheduleStart.Value.Date >= DateTime.Today && e.Start == null))))
                .PreserveReferences();

            CreateMap<Group, GroupGetDetailForMemberDto>()
                .ForMember(dest => dest.Members, opt => opt.MapFrom(
                    src => src.GroupMembers
                        .Where(e => e.MemberRole == GroupMemberRole.Leader || e.MemberRole == GroupMemberRole.Member)
                        .Select(e => e.Account)))
                .ForMember(dest => dest.Subjects, opt => opt.MapFrom(
                    src => src.GroupSubjects.Select(gs => gs.Subject)))
                //Live
                .ForMember(dest => dest.LiveMeetings, opt => opt.MapFrom(
                    src => src.Schedules.SelectMany(s => s.Meetings)
                        .Where(e => e.Start != null && e.End == null)))
                //Schedule
                .ForMember(dest => dest.ScheduleMeetings, opt => opt.MapFrom(
                    src => src.Schedules.SelectMany(s => s.Meetings)
                        .Where(e => e.ScheduleStart != null && e.ScheduleStart.Value.Date >= DateTime.Today && e.Start == null)))
                .PreserveReferences();
        }
        private void MapRole()
        {
            CreateMap<Role, RoleGetDto>()
                .PreserveReferences();
        }
        private void MapGroupMember()
        {
            CreateMap<GroupMember, GroupMemberGetDto>()
                .ForMember(dest => dest.GroupName, opt => opt.MapFrom(
                    src => src.Group.Name))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(
                    src => src.Account.Username))
                .PreserveReferences();
            //Invite
            CreateMap<Invite, JoinInviteForGroupGetDto>()
                .ForMember(dest => dest.GroupName, opt => opt.MapFrom(
                    src => src.Group.Name))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(
                    src => src.Account.Username))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(
                    src => src.Account.Email))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(
                    src => src.Account.FullName))
                .ForMember(dest => dest.Schhool, opt => opt.MapFrom(
                    src => src.Account.Career))
                //.ForMember(dest => dest.Class, opt => opt.MapFrom(
                //    src => src.Account.ClassId))
                //.ForMember(dest => dest.Email, opt => opt.MapFrom(
                //    src => src.Account.Username))
                .PreserveReferences();
            CreateMap<Invite, JoinInviteForStudentGetDto>()
                .ForMember(dest => dest.GroupName, opt => opt.MapFrom(
                    src => src.Group.Name))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(
                    src => src.Account.Username))
                //.ForMember(dest => dest.Class, opt => opt.MapFrom(
                //    src => src.Group.ClassId))
                .ForMember(dest => dest.MemberCount, opt => opt.MapFrom<int>(
                    src => src.Group.GroupMembers
                        .Where(e => e.MemberRole == GroupMemberRole.Leader || e.MemberRole == GroupMemberRole.Member)
                        .Count()))
                .ForMember(dest => dest.Subjects, opt => opt.MapFrom(
                    src => src.Group.GroupSubjects.Select(gs => gs.Subject.Name)))
                //.ForMember(dest => dest.Email, opt => opt.MapFrom(
                //    src => src.Account.Username))
                .PreserveReferences();

            //CreateMap<GroupMemberInviteCreateDto, GroupMember>()
            //    .ForMember(dest => dest.State, opt => opt.MapFrom(src => GroupMemberState.Inviting));
            CreateMap<GroupMemberInviteCreateDto, Invite>()
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => RequestStateEnum.Waiting));

            //Request

            //CreateMap<GroupMember, JoinRequestGetDto>()
            CreateMap<Request, JoinRequestForGroupGetDto>()
                .ForMember(dest => dest.GroupName, opt => opt.MapFrom(
                    src => src.Group.Name))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(
                    src => src.Account.Username))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(
                    src => src.Account.Email))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(
                    src => src.Account.FullName))
                .ForMember(dest => dest.Schhool, opt => opt.MapFrom(
                    src => src.Account.Career))
                //.ForMember(dest => dest.Class, opt => opt.MapFrom(
                //    src => src.Account.ClassId))
                .PreserveReferences();

            CreateMap<Request, JoinRequestForStudentGetDto>()
                .ForMember(dest => dest.GroupName, opt => opt.MapFrom(
                    src => src.Group.Name))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(
                    src => src.Account.Username))
                //.ForMember(dest => dest.Class, opt => opt.MapFrom(
                //    src => src.Group.ClassId))
                .ForMember(dest => dest.MemberCount, opt => opt.MapFrom<int>(
                    src => src.Group.GroupMembers
                        .Where(e => e.MemberRole == GroupMemberRole.Leader || e.MemberRole == GroupMemberRole.Member)
                        .Count()))
                .ForMember(dest => dest.Subjects, opt => opt.MapFrom(
                    src => src.Group.GroupSubjects.Select(gs => gs.Subject.Name)))
                .PreserveReferences();
            //CreateMap<GroupMemberRequestCreateDto, GroupMember>()   
            //    .ForMember(dest => dest.State, opt => opt.MapFrom(src => GroupMemberState.Requesting));
            CreateMap<GroupMemberRequestCreateDto, Request>()
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => RequestStateEnum.Waiting));
        }
        private void MapMeeting()
        {
            CreateMap<Meeting, ScheduleMeetingGetDto>()
               .ForMember(dest => dest.GroupName, opt => opt.MapFrom(
                   src => src.Schedule.Group.Name))
               .PreserveReferences();
            CreateMap<Meeting, ScheduleMeetingForMemberGetDto>()
                .ForMember(dest => dest.GroupName, opt => opt.MapFrom(
                    src => src.Schedule.Group.Name))
                .PreserveReferences();
            CreateMap<Meeting, ScheduleMeetingForLeaderGetDto>()
                .ForMember(dest => dest.GroupName, opt => opt.MapFrom(
                    src => src.Schedule.Group.Name))
                .PreserveReferences();

            CreateMap<Meeting, LiveMeetingGetDto>()
                .ForMember(dest => dest.GroupName, opt => opt.MapFrom(
                    src => src.Schedule.Group.Name))
                .PreserveReferences();
            CreateMap<Meeting, PastMeetingGetDto>()
                .ForMember(dest => dest.GroupName, opt => opt.MapFrom(
                    src => src.Schedule.Group.Name))
                .PreserveReferences();

            CreateMap<ScheduleMeetingCreateDto, Meeting>()
                .ForMember(dest => dest.ScheduleStart, opt => opt.MapFrom(
                    src => src.Date.Add(src.ScheduleStartTime)))
                .ForMember(dest => dest.ScheduleEnd, opt => opt.MapFrom(
                    src => src.Date.Add(src.ScheduleEndTime)));
            CreateMap<InstantMeetingCreateDto, Meeting>()
                .ForMember(dest => dest.Start, opt => opt.MapFrom(
                    src => DateTime.Now));

            CreateMap<Account, ChildrenLiveMeetingGetDto>()
                .ForMember(dest => dest.ChildId, opt => opt.MapFrom(
                    src => src.Id))
                .ForMember(dest => dest.ChildUsername, opt => opt.MapFrom(
                    src => src.Username))
                .ForMember(dest => dest.ChildFullName, opt => opt.MapFrom(
                    src => src.FullName))
                 .ForMember(dest => dest.LiveMeetings, opt => opt.MapFrom(
                    src => src.Connections
                        .Where(e => e.End == null)
                        .Select(e => e.Meeting)))
                .PreserveReferences();
        }
        private void MapSubject()
        {
            CreateMap<Subject, SubjectGetDto>().PreserveReferences();
            CreateMap<SubjectGetDto, Subject>().PreserveReferences();
        }
        private void MapDiscussion()
        {
            CreateMap<Discussion, DiscussionDto>()
                .ForMember(dest => dest.AnswerDiscussions, opt => opt.MapFrom(src => src.AnswerDiscussion));

            CreateMap<DiscussionDto, Discussion>()
                .ForMember(dest => dest.AnswerDiscussion, opt => opt.MapFrom(src => src.AnswerDiscussions));

            CreateMap<Discussion, DiscussionInGroupDto>()
               .ForMember(dest => dest.AnswerDiscussions, opt => opt.MapFrom(src => src.AnswerDiscussion))
               .PreserveReferences();

            CreateMap<Discussion, UploadDiscussionDto>();
            CreateMap<UploadDiscussionDto, Discussion>();
        }
        private void MapAnswerDiscussion()
        {
            CreateMap<AnswerDiscussion, AnswerDiscussionDto>().PreserveReferences();
            CreateMap<AnswerDiscussionDto, AnswerDiscussion>().PreserveReferences();
            CreateMap<AnswerDiscussion, UploadAnswerDiscussionDto>().PreserveReferences();
            CreateMap<UploadAnswerDiscussionDto, AnswerDiscussion>().PreserveReferences();
        }

        private void MapDocumentFile()
        {
            CreateMap<DocumentFile, DocumentFileDto>()
                .ForMember(dest => dest.AccountName, opt => opt.MapFrom(
                    src => src.Account.Username))
                .ForMember(dest => dest.GroupName, opt => opt.MapFrom(
                    src => src.Group.Name))
                .PreserveReferences();
        }
        private void MapSchedule()
        {
            CreateMap<Schedule, ScheduleGetDto>()
                 //Live
                 .ForMember(dest => dest.CurrentLiveMeeting, opt => opt.MapFrom(
                     src => src.Meetings
                         .FirstOrDefault(e => e.Start != null && e.End == null)))
                 //Schedule
                 .ForMember(dest => dest.ScheduleMeetings, opt => opt.MapFrom(
                     src => src.Meetings
                         .Where(e => (e.ScheduleStart != null && e.ScheduleStart.Value.Date >= DateTime.Today && e.Start == null))))
                 .PreserveReferences();
        }
        private void MapReview()
        {
            CreateMap<Review, ReviewSignalrDTO>()
                .ForMember(dest => dest.RevieweeUsername, opt => opt.MapFrom(
                    src => src.Reviewee.Username))
                .ForMember(dest => dest.ReviewerUsernames, opt => opt.MapFrom(
                    src => src.Details.Select(d => d.Reviewer.Username)))
                .ForMember(dest => dest.ReviewerIds, opt => opt.MapFrom(
                    src => src.Details.Select(d => d.ReviewerId)))
                .ForMember(dest => dest.Average, opt => opt.MapFrom(
                    src => src.Details.Count > 0 ? src.Details.Select(d => (int)d.Result).Average() : 0.0))
                .PreserveReferences();
            CreateMap<ReviewDetail, ReviewDetailSignalrGetDto>()
                .PreserveReferences();
        }
        private void MapChat()
        {
            CreateMap<Chat, ChatGetDto>()
                 .PreserveReferences();
        }
        ///////////////////////
        private void BasicMap<TDbEntity, TGetDto, TCreateDto, TUpdateDto>()
         where TGetDto : BaseGetDto
         where TCreateDto : BaseCreateDto
         where TUpdateDto : BaseUpdateDto
        {
            CreateMap<TDbEntity, TGetDto>()
                .PreserveReferences()  //Tránh bị đè lặp
                .ReverseMap();
            CreateMap<TCreateDto, TDbEntity>();
            CreateMap<TUpdateDto, TDbEntity>();
        }
        private void BasicMap<TDbEntity, TGetDto, TCreateDto, TUpdateDto, TOdataDto>()
            where TGetDto : BaseGetDto
            where TCreateDto : BaseCreateDto
            where TUpdateDto : BaseUpdateDto
            where TOdataDto : BaseOdataDto
        {
            //CreateMap<TDbEntity, TGetDto>()
            //    .PreserveReferences()//Tránh bị đè
            //    .ReverseMap();
            //CreateMap<TCreateDto, TDbEntity>();
            //CreateMap<TUpdateDto, TDbEntity>();
            BasicMap<TDbEntity, TGetDto, TCreateDto, TUpdateDto>();
            CreateMap<TDbEntity, TOdataDto>()
                .ForAllMembers(o => o.ExplicitExpansion());
        }
    }
}
