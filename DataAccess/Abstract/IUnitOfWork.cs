﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUnitOfWork
    {
        Task<bool> CommitAsync();
        bool Commit();
    }
}
