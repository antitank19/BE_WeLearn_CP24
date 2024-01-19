using DataLayer.DbObject;
using ServiceLayer.Interface;
using ServiceLayer.DTO;

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