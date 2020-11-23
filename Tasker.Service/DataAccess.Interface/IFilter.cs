﻿using System.Linq;

namespace Tasker.Service.DataAccess.Interface
{
    public interface IFilter<T>
    {
        IQueryable<T> FilterData(FindParams findParams, IQueryable<T> data);
    }
}