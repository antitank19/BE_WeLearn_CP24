using DataLayer.DbObject;
using DataLayer.Enums;
using ServiceLayer.DTOs;
using ServiceLayer.Services.Interface;

namespace APIExtension.Validator
{
    public interface IGroupMemberValidator
    {
        public Task<ValidatorResult> ValidateParamsAsync(GroupMemberInviteCreateDto? dto, int leaderId);
        public Task<ValidatorResult> ValidateParamsAsync(GroupMemberRequestCreateDto? dto);

    }

    public class GroupMemberValidator : BaseValidator, IGroupMemberValidator
    {
        private IServiceWrapper services;

        public GroupMemberValidator(IServiceWrapper services)
        {
            this.services = services;
        }

        public async Task<ValidatorResult> ValidateParamsAsync(GroupMemberInviteCreateDto? dto, int leaderId)
        {
            try
            {
                if (!await services.Groups.IsStudentLeadingGroupAsync(leaderId, dto.GroupId))
                {
                    validatorResult.Failures.Add("Bạn không phải nhóm trưởng nhóm này");
                }
                GroupMember exsited = await services.GroupMembers.GetGroupMemberOfStudentAndGroupAsync<GroupMember>(dto.AccountId, dto.GroupId);
                if (exsited != null)
                {
                    switch (exsited.MemberRole)
                    {
                        case GroupMemberRole.Leader:
                            {
                                validatorResult.Failures.Add("Học sinh đã tham gia nhóm này");
                                break;
                            }
                        case GroupMemberRole.Member:
                            {
                                validatorResult.Failures.Add("Học sinh đã tham gia nhóm này");
                                break;
                            }
                        default:
                            {
                                validatorResult.Failures.Add("Học sinh đã có liên quan đến nhóm");
                                break;
                            }
                    }
                    if (await services.GroupMembers.AnyInviteAsync(dto.AccountId, dto.GroupId))
                    {
                        validatorResult.Failures.Add("Học sinh đã được mời vào nhóm");
                    }
                    if (await services.GroupMembers.AnyRequestAsync(dto.AccountId, dto.GroupId))
                    {
                        validatorResult.Failures.Add("Học sinh đã xin vào nhóm");
                    }
                }
            }
            catch (Exception ex)
            {
                validatorResult.Failures.Add(ex.Message);
            }
            return validatorResult;
        }

        public async Task<ValidatorResult> ValidateParamsAsync(GroupMemberRequestCreateDto? dto)
        {
            try
            {
                if (await services.Groups.IsStudentJoiningGroupAsync(dto.AccountId, dto.GroupId))
                {
                    validatorResult.Failures.Add("Bạn đã tham gia nhóm này");
                }
                GroupMember exsited = await services.GroupMembers.GetGroupMemberOfStudentAndGroupAsync<GroupMember>(dto.AccountId, dto.GroupId);
                if (exsited != null)
                {
                    switch (exsited.MemberRole)
                    {
                        case GroupMemberRole.Leader:
                            {
                                validatorResult.Failures.Add("Học sinh đã tham gia nhóm này");
                                break;
                            }
                        case GroupMemberRole.Member:
                            {
                                validatorResult.Failures.Add("Học sinh đã tham gia nhóm này");
                                break;
                            }
                        default:
                            {
                                validatorResult.Failures.Add("Học sinh đã có liên quan đến nhóm");
                                break;
                            }
                    }
                    if (await services.GroupMembers.AnyInviteAsync(dto.AccountId, dto.GroupId))
                    {
                        validatorResult.Failures.Add("Học sinh đã được mời vào nhóm");
                    }
                    if (await services.GroupMembers.AnyRequestAsync(dto.AccountId, dto.GroupId))
                    {
                        validatorResult.Failures.Add("Học sinh đã xin vào nhóm");
                    }
                    if (await services.GroupMembers.AnyInviteAsync(dto.AccountId, dto.GroupId))
                    {
                        validatorResult.Failures.Add("Học sinh đã được mời vào nhóm");
                    }
                    if (await services.GroupMembers.AnyRequestAsync(dto.AccountId, dto.GroupId))
                    {
                        validatorResult.Failures.Add("Học sinh đã xin vào nhóm");
                    }
                }
            }
            catch (Exception ex)
            {
                validatorResult.Failures.Add(ex.Message);
            }
            return validatorResult;
        }
    }
}