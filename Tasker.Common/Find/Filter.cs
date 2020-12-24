using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Tasker.Common.Enums;
using Tasker.Common.Find.Interface;

namespace Tasker.Common.Find
{
    public class Filter<T> : IFilter<T>
    {
        private readonly object _filterModel;

        public Filter(object filterModel)
        {
            this._filterModel = filterModel;
        }

        public IQueryable<T> FilterData(IFindParams findParams, IQueryable<T> data)
        {
            if (_filterModel != null)
            {
                _filterModel.GetType().GetProperties().Where(x => !String.IsNullOrEmpty(findParams.FilterBy)).Select(x => x.Name).Distinct();

                foreach (PropertyInfo property in _filterModel.GetType().GetProperties().Where(x => x.Name.Equals(findParams.FilterBy)).Distinct())
                {
                    property.SetValue(_filterModel, ObjectType(property, findParams.FilterCondition));
                }

                foreach (PropertyInfo property in _filterModel.GetType().GetProperties())
                {
                    if (findParams.FilterBy.Equals(property.Name) && property.GetValue(_filterModel, null) != null)
                    {
                        return FilteringData(property.Name, property.GetValue(_filterModel, null), data);
                    }
                }
            }
            return FilteringData(null, null, data);
        }

        private static IQueryable<T> FilteringData(string property, object value, IQueryable<T> data)
        {
            if (String.IsNullOrEmpty(property))
            {
                return data;
            }
            var parameterExpr = Expression.Parameter(typeof(T), "t");
            var propertyExpr = Expression.Property(parameterExpr, property);
            var valueExpr = Expression.Constant(value);
            var convectValueExpr = Expression.Convert(valueExpr, typeof(T).GetProperty(property).PropertyType);
            Expression<Func<T, bool>> predicate = null;

            Type searchPropertyType = typeof(T).GetProperty(property).PropertyType;
            if (searchPropertyType == typeof(string))
            {
                var method = "Contains";
                var bodyExpr = Expression.Call(propertyExpr, method, null, convectValueExpr);
                predicate = Expression.Lambda<Func<T, bool>>(bodyExpr, parameterExpr);
            }
            else if (searchPropertyType.IsEnum)
            {
                var equalExpr = Expression.Equal(propertyExpr, convectValueExpr);
                predicate = Expression.Lambda<Func<T, bool>>(equalExpr, parameterExpr);
            }
            else if (searchPropertyType == typeof(Nullable<DateTime>))
            {
                var greaterThanOrEqualExpr = Expression.GreaterThanOrEqual(propertyExpr, convectValueExpr);
                predicate = Expression.Lambda<Func<T, bool>>(greaterThanOrEqualExpr, parameterExpr);
            }
            else if (searchPropertyType == typeof(bool))
            {
                var equalExpr = Expression.Equal(propertyExpr, convectValueExpr);
                predicate = Expression.Lambda<Func<T, bool>>(equalExpr, parameterExpr);
            }
            else if (searchPropertyType == typeof(Nullable<TimeSpan>) || searchPropertyType == typeof(TimeSpan))
            {
                var greaterThanOrEqualExpr = Expression.GreaterThanOrEqual(propertyExpr, convectValueExpr);
                predicate = Expression.Lambda<Func<T, bool>>(greaterThanOrEqualExpr, parameterExpr);
            }

            return predicate != null ? data = data.Where(predicate) : data;
        }

        private object ObjectType(PropertyInfo propertyInfo, object filter)
        {
            if (propertyInfo.PropertyType == typeof(string))
            {
                return filter != null ? filter.ToString() : null;
            }
            else if (propertyInfo.PropertyType == typeof(Nullable<PriorityLevel>))
            {
                return filter != null ? (Nullable<PriorityLevel>)Convert.ToInt32(filter) : (Nullable<PriorityLevel>)null;
            }
            else if (propertyInfo.PropertyType == typeof(Nullable<DateTime>))
            {
                return filter != null ? Convert.ToDateTime(filter) : (Nullable<DateTime>)null;
            }
            else if (propertyInfo.PropertyType == typeof(Nullable<bool>))
            {
                return filter != null ? Convert.ToBoolean(filter) : (Nullable<bool>)null;
            }
            else if (propertyInfo.PropertyType == typeof(TimeSpan))
            {
                return (TimeSpan) filter;
            }
            else if (propertyInfo.PropertyType == typeof(Nullable<TimeSpan>))
            {
                return filter != null ? (Nullable<TimeSpan>) TimeSpan.Parse(filter.ToString()) : (Nullable<TimeSpan>)null;
            }
            return filter;
        }
    }
}
