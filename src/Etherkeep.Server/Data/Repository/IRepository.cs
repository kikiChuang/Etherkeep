﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Server.Data.Repository
{
    public interface IRepository<TEntity, TKey> where TEntity : class
    {
    }
}
