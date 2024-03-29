﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using DataLayer.DbObject;
using DataLayer.Enums;
using Microsoft.EntityFrameworkCore;
using RepoLayer.Interface;
using ServiceLayer.DTOs;
using ServiceLayer.Services.Interface.Db;
using ServiceLayer.Utils;

namespace ServiceLayer.Services.Implementation.Db
{
    internal class MeetingService : IMeetingService
    {
        private IRepoWrapper repos;
        private IMapper mapper;

        public MeetingService(IRepoWrapper repos, IMapper mapper)
        {
            this.repos = repos;
            this.mapper = mapper;
        }

        public async Task<bool> AnyAsync(int id)
        {
            return await repos.Meetings.GetList().AnyAsync(e => e.Id == id);
        }

        public async Task<T> CreateInstantMeetingAsync<T>(InstantMeetingCreateDto dto)
        {
            Schedule schedule = new Schedule()
            {
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Name = dto.Name,
                GroupId = dto.GroupId,
                StartTime = DateTime.Now.TimeOfDay,
                DaysOfWeek = "Chủ Nhật, Thứ Hai,Thứ Ba,Thứ Tư,Thứ Năm,Thứ Sáu,Thứ Bảy"
            };

            Meeting meeting = mapper.Map<Meeting>(dto);
            meeting.Schedule = schedule;
            await repos.Meetings.CreateAsync(meeting);
            //await repos.Schedules.CreateAsync(schedule);
            var mapped = mapper.Map<T>(meeting);
            return mapped;
        }

        public async Task CreateScheduleMeetingAsync(ScheduleMeetingCreateDto dto)
        {
            Schedule schedule = new Schedule()
            {
                StartDate = dto.Date,
                EndDate = dto.Date,
                Name = dto.Name,
                GroupId = dto.GroupId,
                StartTime = dto.ScheduleStartTime,
                EndTime = dto.ScheduleEndTime,
            };
            Meeting meeting = mapper.Map<Meeting>(dto);
            meeting.Schedule = schedule;
            await repos.Meetings.CreateAsync(meeting);
        }

        public async Task<T> MassCreateScheduleMeetingAsync<T>(ScheduleMeetingMassCreateDto dto)
        {
            DateTime[] dates = Enumerable.Range(0, 1 + dto.ScheduleRangeEnd.Subtract(dto.ScheduleRangeStart).Days)
                .Select(offset => dto.ScheduleRangeStart.AddDays(offset))
                .Where(date => dto.DayOfWeeks.Contains(date.DayOfWeek + 1))
                .ToArray();
            List<Meeting> creatingMeetings = dates.Select(date => new Meeting
            {
                Name = dto.Name + " " + date.ToString("d/M"),
                Content = dto.Content,
                ScheduleStart = date.Add(dto.ScheduleStartTime),
                ScheduleEnd = date.Add(dto.ScheduleEndTime),
            }).ToList();
            string daysOfWeek = daysOfWeekToString(dto.DayOfWeeks);
            Console.WriteLine($"+++===+++===+++===+++===+++===+++===\n{daysOfWeek}");
            Schedule schedule = new Schedule
            {
                GroupId = dto.GroupId,
                Name = dto.Name,
                DaysOfWeek = daysOfWeek,
                StartDate = dto.ScheduleRangeStart,
                EndDate = dto.ScheduleRangeEnd,
                StartTime = dto.ScheduleStartTime,
                EndTime = dto.ScheduleEndTime,
                Meetings = creatingMeetings
            };
            schedule.ScheduleSubjects = dto.SubjectIds.Select(sId => new ScheduleSubject() { SubjectId = (int)sId }).ToList();
            //return await repos.Meetings.MassCreateAsync(creatingMeetings);
            await repos.Schedules.CreateAsync(schedule);
            //return creatingMeetings;
            var mapped = mapper.Map<T>(schedule);
            return mapped;
            string daysOfWeekToString(ICollection<DayOfWeek> daysOfWeek)
            {
                //var sorted = daysOfWeek.Select(dayInt => (int)dayInt == 1 ? 8 : (int)dayInt).AsEnumerable().ToImmutableSortedSet();
                var sorted = daysOfWeek.Cast<int>().ToList();
                sorted.Sort();
                if (sorted[0] == 1)
                {
                    sorted.RemoveAt(0);
                    sorted.Add(8);
                }
                string daysOfWeekString = "" + dayOfWeekConvert(sorted[0]);
                for (int i = 1; i < sorted.Count; i++)
                {
                    daysOfWeekString += $", {dayOfWeekConvert(sorted[i])}";
                }
                return daysOfWeekString;

            }
            string dayOfWeekConvert(int intDay)
            {
                switch (intDay)
                {
                    case 1:
                        return "Chủ Nhật";
                    case 2:
                        return "Thứ Hai";
                    case 3:
                        return "Thứ Ba";
                    case 4:
                        return "Thứ Tư";
                    case 5:
                        return "Thứ Năm";
                    case 6:
                        return "Thứ Sáu";
                    case 7:
                        return "Thứ Bảy";
                    case 8:
                        return "Chủ Nhật";
                }
                return "";
            }
        }

        public async Task<T> GetByIdAsync<T>(int id)
        {
            return mapper.Map<T>(await repos.Meetings.GetByIdAsync(id));
        }

        public IQueryable<PastMeetingGetDto> GetPastMeetingsForGroup(int groupId)
        {
            return repos.Meetings.GetList()
                .Include(m => m.Chats).ThenInclude(c => c.Account)
               //.Where(e => e.GroupId == groupId && (e.End != null || (e.ScheduleStart != null && e.ScheduleStart.Value.Date < DateTime.Today && e.Start == null)))
               .Where(e => e.Schedule.GroupId == groupId && (e.End != null || e.ScheduleStart != null && e.ScheduleStart.Value.Date < DateTime.Today))
               .ProjectTo<PastMeetingGetDto>(mapper.ConfigurationProvider);
        }

        public IQueryable<LiveMeetingGetDto> GetLiveMeetingsForGroup(int groupId)
        {
            //var liveMeetings = repos.Meetings.GetList()
            //    .Where(e => e.Start != null && e.End == null);
            return repos.Meetings.GetList()
                .Where(e => e.Schedule.GroupId == groupId && e.Start != null && e.End == null)
                .ProjectTo<LiveMeetingGetDto>(mapper.ConfigurationProvider);
        }

        public IQueryable<T> GetScheduleMeetingsForGroup<T>(int groupId)
        {
            //if()
            var list = repos.Meetings.GetList()
                //.Where(e => e.GroupId == groupId && (e.End != null || (e.ScheduleStart != null && e.ScheduleStart.Value.Date >= DateTime.Today)))
                .Where(e => e.Schedule.GroupId == groupId
                    && e.ScheduleStart != null
                    && e.ScheduleStart.Value.Date >= DateTime.Today && e.Start == null);
            //.ProjectTo<ScheduleMeetingForMemberGetDto>(mapper.ConfigurationProvider);
            var mapped = list.ProjectTo<T>(mapper.ConfigurationProvider);
            return mapped;
        }
        public IQueryable<PastMeetingGetDto> GetPastMeetingsForStudent(int studentId)
        {
            //Nếu tháng này thì chỉ lấy past meeting
            IQueryable<Meeting> allMeetingsOfJoinedGroups = repos.Meetings.GetList()
                .Include(m => m.Chats).ThenInclude(c => c.Account)
                .Include(c => c.Connections)
                .Include(m => m.Schedule).ThenInclude(a => a.Group).ThenInclude(g => g.GroupMembers)
                .Where(e => e.Schedule.Group.GroupMembers.Any(gm => gm.AccountId == studentId)
                    //lấy past meeting
                    && (e.End != null || e.ScheduleStart != null && e.ScheduleStart.Value.Date < DateTime.Today));
            return allMeetingsOfJoinedGroups.ProjectTo<PastMeetingGetDto>(mapper.ConfigurationProvider);
        }

        public IQueryable<PastMeetingGetDto> GetPastMeetingsForStudentByMonth(int studentId, DateTime month)
        {
            DateTime start = new DateTime(month.Year, month.Month, 1);
            DateTime end = start.AddMonths(1);
            //Nếu tháng này thì chỉ lấy past meeting
            IQueryable<Meeting> allMeetingsOfJoinedGroups = month.Month == DateTime.Now.Month
                ? repos.Meetings.GetList()
                .Include(c => c.Connections)
                .Include(a => a.Schedule).ThenInclude(m => m.Group).ThenInclude(g => g.GroupMembers)
                .Where(e => ((e.ScheduleStart >= start && e.ScheduleStart.Value.Date < end) || (e.Start >= start && e.Start.Value.Date < end))
                    && e.Schedule.Group.GroupMembers.Any(gm => gm.AccountId == studentId)
                    //lấy past meeting
                    && (e.End != null || e.ScheduleStart != null && e.ScheduleStart.Value.Date < DateTime.Today))
                : repos.Meetings.GetList()
                .Include(c => c.Connections)
                .Include(m => m.Schedule).ThenInclude(a => a.Group).ThenInclude(g => g.GroupMembers)
                .Where(c => c.Start >= start && c.Start.Value.Date < end
                    && c.Schedule.Group.GroupMembers.Any(gm => gm.AccountId == studentId));
            return allMeetingsOfJoinedGroups.ProjectTo<PastMeetingGetDto>(mapper.ConfigurationProvider);
        }

        public IQueryable<ScheduleMeetingForMemberGetDto> GetScheduleMeetingsForStudent(int studentId)
        {
            IQueryable<Meeting> scheduleMeetingsOfJoinedGroups = repos.Meetings.GetList()
                .Include(c => c.Connections)
                .Include(a => a.Schedule).ThenInclude(m => m.Group).ThenInclude(g => g.GroupMembers)
                .Where(e => e.Schedule.Group.GroupMembers.Any(gm => gm.AccountId == studentId)
                    //lấy past meeting
                    && (e.ScheduleStart != null && e.ScheduleStart.Value.Date >= DateTime.Today && e.Start == null));
            return scheduleMeetingsOfJoinedGroups.ProjectTo<ScheduleMeetingForMemberGetDto>(mapper.ConfigurationProvider);
        }

        public IQueryable<ScheduleMeetingForMemberGetDto> GetScheduleMeetingsForStudentByDate(int studentId, DateTime date)
        {
            IQueryable<Meeting> scheduleMeetingsOfJoinedGroups = repos.Meetings.GetList()
                .Include(c => c.Connections)
                .Include(a => a.Schedule).ThenInclude(m => m.Group).ThenInclude(g => g.GroupMembers)
                .Where(e => e.Schedule.Group.GroupMembers.Any(gm => gm.AccountId == studentId)
                    //lấy schedule meeting
                    && (e.ScheduleStart != null && e.ScheduleStart.Value.Date >= DateTime.Today && e.Start == null)
                    && e.ScheduleStart.Value.Date == date);
            return scheduleMeetingsOfJoinedGroups.ProjectTo<ScheduleMeetingForMemberGetDto>(mapper.ConfigurationProvider);
        }

        public IQueryable<LiveMeetingGetDto> GetLiveMeetingsForStudent(int studentId)
        {
            IQueryable<Meeting> scheduleMeetingsOfJoinedGroups = repos.Meetings.GetList()
                .Include(c => c.Connections)
                .Include(a => a.Schedule).ThenInclude(m => m.Group).ThenInclude(g => g.GroupMembers)
                .Where(e => e.Schedule.Group.GroupMembers.Any(gm => gm.AccountId == studentId)
                //lấy live meeting
                && e.Start != null && e.End == null);
            return scheduleMeetingsOfJoinedGroups.ProjectTo<LiveMeetingGetDto>(mapper.ConfigurationProvider);
        }

        public async Task UpdateScheduleMeetingAsync(ScheduleMeetingUpdateDto dto)
        {
            Meeting existed = await repos.Meetings.GetByIdAsync(dto.Id);
            Meeting updated = new Meeting
            {
                Id = dto.Id,
                Name = dto.Name,
                Content = dto.Content,
                ScheduleStart = dto.Date.Date.Add(dto.ScheduleStartTime),
                ScheduleEnd = dto.Date.Date.Add(dto.ScheduleEndTime),
            };
            existed.PatchUpdate(updated);
            await repos.Meetings.UpdateAsync(existed);
        }

        public async Task StartScheduleMeetingAsync(Meeting meeting)
        {
            await repos.Meetings.UpdateAsync(meeting);
        }

        public async Task DeleteScheduleMeetingAsync(Meeting meeting)
        {
            await repos.Meetings.RemoveAsync(meeting.Id);
        }

        public IQueryable<ScheduleGetDto> GetSchedulesForGroup(int groupId)
        {
            IQueryable<Schedule> schedules = repos.Schedules.GetList()
                .Include(e => e.Meetings);

            return schedules.ProjectTo<ScheduleGetDto>(mapper.ConfigurationProvider);
        }

        //public IQueryable<ChildrenLiveMeetingGetDto> GetChildrenLiveMeetings(int parentId)
        //{
        //    IQueryable<Account> children = repos.Accounts.GetList()
        //        .Where(a => a.SupervisionsForStudent.Any(su => su.ParentId == parentId && su.State == RequestStateEnum.Approved))
        //        .Include(a => a.Connections).ThenInclude(c => c.Meeting);
        //    Account temp = children.FirstOrDefault();
        //    return children.ProjectTo<ChildrenLiveMeetingGetDto>(mapper.ConfigurationProvider);
        //}
    }
}