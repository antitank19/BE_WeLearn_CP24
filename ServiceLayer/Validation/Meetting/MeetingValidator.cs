﻿using DataLayer.DbObject;
using ServiceLayer.DTOs;
using ServiceLayer.Services.Interface;

namespace APIExtension.Validator
{
    public interface IMeetingValidator
    {
        public Task<ValidatorResult> ValidateParams(ScheduleMeetingCreateDto? dto, int studentId);
        public Task<ValidatorResult> ValidateParams(InstantMeetingCreateDto? dto, int studentId);
        public Task<ValidatorResult> ValidateParams(ScheduleMeetingUpdateDto? dto, int studentId);
        public Task<ValidatorResult> ValidateParams(ScheduleMeetingMassCreateDto? dto, int studentId);
    }
    public class MeetingValidator : BaseValidator, IMeetingValidator
    {
        private IServiceWrapper services;

        public MeetingValidator(IServiceWrapper services)
        {
            this.services = services;
        }

        public async Task<ValidatorResult> ValidateParams(InstantMeetingCreateDto? dto, int studentId)
        {
            try
            {
                if (!await services.Groups.ExistsAsync(dto.GroupId))
                {
                    //validatorResult.Failures.Add("Nhóm không tồn tại");
                    validatorResult.Add("Nhóm không tồn tại", nameof(dto.GroupId));
                }
                if (!await services.Groups.IsStudentJoiningGroupAsync(studentId, dto.GroupId))
                {
                    //validatorResult.Failures.Add("Bạn không phải thành viên của nhóm này");
                    validatorResult.Add("Bạn không phải thành viên của nhóm này", ValidateErrType.Role);
                }
                if (dto.Name.Trim().Length == 0)
                {
                    //validatorResult.Failures.Add("Thiếu tên buổi học");
                    validatorResult.Add("Thiếu tên buổi học", nameof(dto.Name));
                }
                if (dto.Name.Trim().Length > 50)
                {
                    //validatorResult.Failures.Add("Tên buổi học quá dài");
                    validatorResult.Add("Tên buổi học quá dài", nameof(dto.Name));
                }

            }
            catch (Exception ex)
            {
                //validatorResult.Failures.Add(ex.Message);
                validatorResult.Add(ex.Message);
            }
            return validatorResult;
        }

        public async Task<ValidatorResult> ValidateParams(ScheduleMeetingCreateDto? dto, int studentId)
        {
            try
            {
                if (!await services.Groups.IsStudentLeadingGroupAsync(studentId, dto.GroupId))
                {
                    //validatorResult.Failures.Add("Bạn không phải nhóm trưởng của nhóm này");
                    validatorResult.Add("Bạn không phải nhóm trưởng của nhóm này", ValidateErrType.Role);
                }
                if (dto.Name.Trim().Length == 0)
                {
                    //validatorResult.Failures.Add("Thiếu tên buổi học");
                    validatorResult.Add("Thiếu tên buổi học", nameof(dto.Name));
                }
                if (dto.Name.Trim().Length > 50)
                {
                    //validatorResult.Failures.Add("Tên buổi học quá dài");
                    validatorResult.Add("Tên buổi học quá dài", nameof(dto.Name));
                }
                //Validate Date
                if (dto.Date.Date == DateTime.Today && dto.ScheduleStartTime < DateTime.Now.TimeOfDay)
                {
                    //validatorResult.Failures.Add("Thời gian bắt đầu buổi học không hợp lí");
                    validatorResult.Add("Thời gian bắt đầu buổi học không hợp lí", nameof(dto.Date));
                }
                else if (dto.Date.Date < DateTime.Now.Date)
                {
                    //validatorResult.Failures.Add("Ngày không hợp lí");
                    validatorResult.Add("Ngày không hợp lí", nameof(dto.Date));
                }
                //validate time
                if (dto.ScheduleEndTime <= dto.ScheduleStartTime)
                {
                    //validatorResult.Failures.Add("Thời gian kết thúc buổi học không hợp lí");
                    validatorResult.Add("Thời gian kết thúc buổi học không hợp lí", nameof(dto.ScheduleEndTime));
                }
                //if (dto.ScheduleStart < DateTime.Now)
                //{
                //    validatorResult.Add("Thời gian bắt đầu buổi học không hợp lí");
                //}
                //if (dto.ScheduleEnd < dto.ScheduleStart)
                //{
                //    validatorResult.Add("Thời gian kết thúc buổi học không hợp lí");
                //}
                //else if(dto.ScheduleStart.Date!=dto.ScheduleEnd.Date)
                //{
                //    validatorResult.Add("Cuộc họp phải diễn ra và kết thúc trong 1 ngày");
                //}

            }
            catch (Exception ex)
            {
                validatorResult.Add(ex.Message);
                //validatorResult.Failures.Add(ex.Message);
            }
            return validatorResult;
        }

        public async Task<ValidatorResult> ValidateParams(ScheduleMeetingUpdateDto? dto, int studentId)
        {
            try
            {
                Meeting meeting = await services.Meetings.GetByIdAsync<Meeting>(dto.Id);
                if (meeting == null)
                {
                    //validatorResult.Failures.Add("Buổi học không tồn tại");
                    validatorResult.Add("Buổi học không tồn tại", ValidateErrType.NotFound);
                }
                else if (!await services.Groups.IsStudentLeadingGroupAsync(studentId, meeting.Schedule.GroupId))
                {
                    //validatorResult.Failures.Add("Bạn không phải nhóm trưởng của nhóm này");
                    validatorResult.Add("Bạn không phải nhóm trưởng của nhóm này", ValidateErrType.Role);
                }
                if (dto.Name.Trim().Length == 0)
                {
                    //validatorResult.Failures.Add("Thiếu tên buổi học");
                    validatorResult.Add("Thiếu tên buổi học", nameof(dto.Name));
                }
                if (dto.Name.Trim().Length > 50)
                {
                    //validatorResult.Failures.Add("Tên buổi học quá dài");
                    validatorResult.Add("Tên buổi học quá dài", nameof(dto.Name));
                }
                //Validate Date
                if (dto.Date.Date == DateTime.Today && dto.ScheduleStartTime < DateTime.Now.TimeOfDay)
                {
                    //validatorResult.Failures.Add("Thời gian bắt đầu buổi học không hợp lí");
                    validatorResult.Add("Thời gian bắt đầu buổi học không hợp lí", nameof(dto.Date));
                }
                else if (dto.Date.Date < DateTime.Now.Date)
                {
                    //validatorResult.Failures.Add("Ngày không hợp lí");
                    validatorResult.Add("Ngày không hợp lí", nameof(dto.Date));
                }
                //validate time
                if (dto.ScheduleEndTime <= dto.ScheduleStartTime)
                {
                    //validatorResult.Failures.Add("Thời gian kết thúc buổi học không hợp lí");
                    validatorResult.Add("Thời gian kết thúc buổi học không hợp lí", nameof(dto.ScheduleEndTime));
                }
                //if (dto.ScheduleStart < DateTime.Now)
                //{
                //    validatorResult.Add("Thời gian bắt đầu buổi học không hợp lí");
                //}
                //if (dto.ScheduleEnd < dto.ScheduleStart)
                //{
                //    validatorResult.Add("Thời gian kết thúc buổi học không hợp lí");
                //}
            }
            catch (Exception ex)
            {
                //validatorResult.Failures.Add(ex.Message);
                validatorResult.Add(ex.Message);
            }
            return validatorResult;
        }

        public async Task<ValidatorResult> ValidateParams(ScheduleMeetingMassCreateDto? dto, int studentId)
        {
            try
            {
                if (!await services.Groups.IsStudentLeadingGroupAsync(studentId, dto.GroupId))
                {
                    //validatorResult.Failures.Add("Bạn không phải nhóm trưởng của nhóm này");
                    validatorResult.Add("Bạn không phải nhóm trưởng của nhóm này", ValidateErrType.Role);
                }
                if (dto.Name.Trim().Length == 0)
                {
                    //validatorResult.Failures.Add("Thiếu tên buổi học");
                    validatorResult.Add("Thiếu tên buổi học", nameof(dto.Name));
                }
                if (dto.Name.Trim().Length > 50)
                {
                    //validatorResult.Failures.Add("Tên buổi học quá dài");
                    validatorResult.Add("Tên buổi học quá dài", nameof(dto.Name));
                }
                //validate weekdays
                if (!dto.DayOfWeeks.Any())
                {
                    //validatorResult.Failures.Add("Chưa chọn ngày trong tuần");
                    validatorResult.Add("Chưa chọn ngày trong tuần", nameof(dto.DayOfWeeks));
                }
                if (dto.DayOfWeeks.Any(day => (int)day < 1 || (int)day > 7))
                {
                    //validatorResult.Failures.Add("Ngày trong tuần không hợp lí");
                    validatorResult.Add("Ngày trong tuần không hợp lí", nameof(dto.DayOfWeeks));
                }
                //Validate range
                if (dto.ScheduleRangeStart.Date == DateTime.Today && dto.ScheduleStartTime < DateTime.Now.TimeOfDay)
                {
                    //validatorResult.Failures.Add("Thời gian bắt đầu buổi học không hợp lí");
                    validatorResult.Add("Thời gian bắt đầu buổi học không hợp lí", nameof(dto.ScheduleStartTime));
                }
                else if (dto.ScheduleRangeStart < DateTime.Now.Date)
                {
                    //validatorResult.Failures.Add("Khoảng thời gian bắt đầu kế hoạch không hợp lí");
                    validatorResult.Add("Khoảng thời gian bắt đầu kế hoạch không hợp lí", nameof(dto.ScheduleRangeStart));
                }
                if (dto.ScheduleRangeEnd < dto.ScheduleRangeStart)
                {
                    //validatorResult.Failures.Add("Khoảng thời gian lên kế hoạch không hợp lí");
                    validatorResult.Add("Khoảng thời gian lên kế hoạch không hợp lí", nameof(dto.ScheduleRangeEnd));
                }
                //validate time
                if (dto.ScheduleEndTime < dto.ScheduleStartTime)
                {
                    //validatorResult.Failures.Add("Thời gian kết thúc buổi học không hợp lí");
                    validatorResult.Add("Thời gian kết thúc buổi học không hợp lí", nameof(dto.ScheduleEndTime));
                }

            }
            catch (Exception ex)
            {
                //validatorResult.Failures.Add(ex.Message);
                validatorResult.Add(ex.Message);
            }
            return validatorResult;
        }
    }
}
