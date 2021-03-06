﻿using CoreApiGITVersion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 

namespace CoreApiGITVersion.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly CoreAPIGITVersionContext context;
        public BaseRepository(CoreAPIGITVersionContext currentContext)
        {
            context = currentContext;
        }
    }
}
