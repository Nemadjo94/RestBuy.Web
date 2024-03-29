﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using RestBuy.Entities;

namespace RestBuy.Application.Services.Queries
{
    class BaseQuery<T> : IQuery<T> where T : BaseEntity
    {
        public virtual Expression<Func<T, bool>> Criteria => null;

        public virtual Expression<Func<T, object>> OrderBy => null;

        public virtual Expression<Func<T, object>> ThenBy => null;

        public virtual Expression<Func<T, object>> OrderByDescending => null;

        public virtual Expression<Func<T, object>> ThenByDescending => null;

        public virtual int Take { get; protected set; } = 0;

        public virtual int Skip { get; protected set; } = 0;
    }
}
