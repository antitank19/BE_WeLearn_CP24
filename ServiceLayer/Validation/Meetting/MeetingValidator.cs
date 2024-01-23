using DataLayer.DbObject;
using ServiceLayer.Interface;
using ServiceLayer.DTOs;

namespace APIExtension.Validator
{
    public interface IMeetingValidator
    {
    }
    public class MeetingValidator : BaseValidator, IMeetingValidator
    {
        private IServiceWrapper services;

        public MeetingValidator(IServiceWrapper services)
        {
            this.services = services;
        }

       
    }
}
