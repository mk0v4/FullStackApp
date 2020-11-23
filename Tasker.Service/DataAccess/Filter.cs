using System;
using System.Linq;
using System.Reflection;
using Tasker.Service.DataAccess.Interface;

namespace Tasker.Service.DataAccess
{
    public class Filter<T> : IFilter<T>
    {
        private readonly object _filterModel;

        public Filter(object filterModel)
        {
            this._filterModel = filterModel;
        }

        public IQueryable<T> FilterData(FindParams findParams, IQueryable<T> data)
        {
            if (_filterModel != null && !String.IsNullOrEmpty(findParams.SearchProperty))
            {
                foreach (PropertyInfo property in _filterModel.GetType().GetProperties())
                {
                    if (property.Name.Equals(findParams.SearchProperty))
                    {
                        //object l = property.GetValue(_filterModel, null);
                        return FilteringData(findParams, data);
                    }
                }
            }
            else if (String.IsNullOrEmpty(findParams.SearchProperty))
            {
                return FilteringData(findParams, data);
            }
            return Enumerable.Empty<T>().AsQueryable();

        }

        private static IQueryable<T> FilteringData(FindParams findParams, IQueryable<T> data)
        {
            if (String.IsNullOrEmpty(findParams.SearchProperty))
            {
                return data;
            }
            Type searchPropertyType = typeof(T).GetProperty(findParams.SearchProperty).PropertyType;
            if (searchPropertyType == typeof(string))
            {
                data = data.Where(t =>
                t.GetType().GetProperty(findParams.SearchProperty).GetValue(t, null) != null ?
                t.GetType().GetProperty(findParams.SearchProperty).GetValue(t, null).ToString().ToLower()
                    .Contains(findParams.SearchValue.ToString().ToLower()) :
                    "".Contains(findParams.SearchValue.ToString()));
            }
            else if (searchPropertyType.IsEnum)
            {
                Type enumType = typeof(T).GetProperty(findParams.SearchProperty).PropertyType;
                data = data.Where(t => t.GetType().GetProperty(findParams.SearchProperty).GetValue(t, null).ToString()
                .Equals(Enum.GetName(enumType, findParams.SearchValue)));
            }
            else if (searchPropertyType == typeof(Nullable<DateTime>))
            {
                if (findParams.SearchValue != null)
                    data = data.Where(t => DateTime.Compare(Convert.ToDateTime(
                        t.GetType().GetProperty(findParams.SearchProperty).GetValue(t, null)),
                        Convert.ToDateTime(findParams.SearchValue)) >= 0);
                else
                {
                    data = data.Where(t => t.GetType().GetProperty(findParams.SearchProperty).GetValue(t, null) == null);
                }
            }
            else if (searchPropertyType == typeof(bool))
            {
                data = data.Where(t => t.GetType().GetProperty(findParams.SearchProperty).GetValue(t, null)
                .Equals(findParams.SearchValue));
            }
            else if (searchPropertyType == typeof(Nullable<TimeSpan>) || searchPropertyType == typeof(TimeSpan))
            {
                if (findParams.SearchValue != null)
                    data = data.Where(t => t.GetType().GetProperty(findParams.SearchProperty).GetValue(t, null) != null &&
                    TimeSpan.Compare((TimeSpan)t.GetType().GetProperty(findParams.SearchProperty).GetValue(t, null),
                    (TimeSpan)findParams.SearchValue) >= 0);
                else
                {
                    data = data.Where(t => t.GetType().GetProperty(findParams.SearchProperty).GetValue(t, null) == null);
                }
            }
            return data;
        }
    }
}
