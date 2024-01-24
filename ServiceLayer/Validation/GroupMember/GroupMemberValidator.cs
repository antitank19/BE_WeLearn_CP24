using DataLayer.DbObject;
using ServiceLayer.DTOs;
using ServiceLayer.Services.Interface;

namespace APIExtension.Validator
{
    public interface IGroupMemberValidator
    {

    }

    public class GroupMemberValidator  : BaseValidator ,IGroupMemberValidator
    {
        private IServiceWrapper services;

        public GroupMemberValidator(IServiceWrapper services)
        {
            this.services = services;
        }
    }
}