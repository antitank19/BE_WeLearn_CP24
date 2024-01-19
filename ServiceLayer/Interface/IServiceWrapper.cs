using ServiceLayer.Interface.Auth;
using ServiceLayer.Interface.Db;
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
    }
}
