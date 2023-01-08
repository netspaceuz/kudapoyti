﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kudapoyti.Service.Interfaces.Common
{
    public interface IPaginatorService
    {
        public Task<IList<T>> ToPagedAsync<T>(IQueryable<T> items, int pageNumber, int pageSize);
    }
}
