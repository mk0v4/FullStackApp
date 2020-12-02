﻿using System;
using System.Linq;
using System.Linq.Expressions;
using Tasker.Common.Find.Interface;

namespace Tasker.Common.Find
{
    public class Sort<T> : ISort<T>
    {
        public IQueryable<T> SortData(IFindParams filterElements, IQueryable<T> data)
        {
            string sortBy = filterElements.SortBy;
            string sortDirection = filterElements.SortDirection;
            if (String.IsNullOrEmpty(sortBy) || String.IsNullOrEmpty(sortDirection))
            {
                sortBy = "Id";
                sortDirection = "asc";
            }
            var param = Expression.Parameter(typeof(T), "item");

            var sortExpression = Expression.Lambda<Func<T, object>>
                (Expression.Convert(Expression.Property(param, sortBy), typeof(object)), param);
            switch (sortDirection.ToLower())
            {
                case "asc":
                    return data.OrderBy<T, object>(sortExpression);
                default:
                    return data.OrderByDescending<T, object>(sortExpression);
            }
        }
    }
}