using ServiceLayer.Interface.Auth;
using ServiceLayer.Interface.Db;
using ServiceLayer.Interface.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interface
{
    public interface IServiceWrapper
    {
        public IAccountService Accounts { get; }
        public IAuthService Auth { get; }
        public IAutoMailService Mails { get; }
        public IGroupService Groups { get; }
    }
}
