﻿using DataLayer.DbContext;
using DataLayer.DbObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface IGroupRepository   : IBaseRepo<Group> 
    {
    }
}
