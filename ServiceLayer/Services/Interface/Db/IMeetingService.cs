﻿using DataLayer.DbObject;
using ServiceLayer.DTOs;

namespace ServiceLayer.Services.Interface.Db
{
    public interface IMeetingService
    {
        public Task<bool> AnyAsync(int id);
        public IQueryable<PastMeetingGetDto> GetPastMeetingsForGroup(int groupId);
        public IQueryable<T> GetScheduleMeetingsForGroup<T>(int groupId);
        public IQueryable<LiveMeetingGetDto> GetLiveMeetingsForGroup(int groupId);
        public IQueryable<PastMeetingGetDto> GetPastMeetingsForStudent(int studentId);
        public IQueryable<PastMeetingGetDto> GetPastMeetingsForStudentByMonth(int studentId, DateTime month);
        public IQueryable<ScheduleMeetingForMemberGetDto> GetScheduleMeetingsForStudent(int studentId);
        public IQueryable<ScheduleMeetingForMemberGetDto> GetScheduleMeetingsForStudentByDate(int studentId, DateTime date);
        public IQueryable<LiveMeetingGetDto> GetLiveMeetingsForStudent(int studentId);
        public Task<T> GetByIdAsync<T>(int id);
        public Task CreateScheduleMeetingAsync(ScheduleMeetingCreateDto dto);
        public Task<T> MassCreateScheduleMeetingAsync<T>(ScheduleMeetingMassCreateDto dto);
        public Task<T> CreateInstantMeetingAsync<T>(InstantMeetingCreateDto dto);
        public Task UpdateScheduleMeetingAsync(ScheduleMeetingUpdateDto dto);
        public Task StartScheduleMeetingAsync(Meeting meeting);
        public Task DeleteScheduleMeetingAsync(Meeting meeting);
        public IQueryable<ScheduleGetDto> GetSchedulesForGroup(int groupId);
        //public IQueryable<ChildrenLiveMeetingGetDto> GetChildrenLiveMeetings(int parentId);
    }
}