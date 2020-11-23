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

        public IQueryable<T> FilterData(FindParams findElements, IQueryable<T> data)
        {
            if (_filterModel != null && !String.IsNullOrEmpty(findElements.SearchProperty))
            {
                foreach (PropertyInfo property in _filterModel.GetType().GetProperties())
                {
                    if (property.Name.Equals(findElements.SearchProperty))
                    {
                        //object l = property.GetValue(_filterModel, null);
                        return FilteringData(findElements, data);
                    }
                }
            }
            else if (String.IsNullOrEmpty(findElements.SearchProperty))
            {
                return FilteringData(findElements, data);
            }
            return Enumerable.Empty<T>().AsQueryable();

        }

        private static IQueryable<T> FilteringData(FindParams findElements, IQueryable<T> data)
        {
            if (String.IsNullOrEmpty(findElements.SearchProperty))
            {
                return data;
            }
            Type searchPropertyType = typeof(T).GetProperty(findElements.SearchProperty).PropertyType;
            if (searchPropertyType == typeof(string))
            {
                data = data.Where(t =>
                t.GetType().GetProperty(findElements.SearchProperty).GetValue(t, null) != null ?
                t.GetType().GetProperty(findElements.SearchProperty).GetValue(t, null).ToString().ToLower()
                    .Contains(findElements.SearchValue.ToString().ToLower()) :
                    "".Contains(findElements.SearchValue.ToString()));
            }
            else if (searchPropertyType.IsEnum)
            {
                Type enumType = typeof(T).GetProperty(findElements.SearchProperty).PropertyType;
                data = data.Where(t => t.GetType().GetProperty(findElements.SearchProperty).GetValue(t, null).ToString()
                .Equals(Enum.GetName(enumType, findElements.SearchValue)));
            }
            else if (searchPropertyType == typeof(Nullable<DateTime>))
            {
                if (findElements.SearchValue != null)
                    data = data.Where(t => DateTime.Compare(Convert.ToDateTime(
                        t.GetType().GetProperty(findElements.SearchProperty).GetValue(t, null)),
                        Convert.ToDateTime(findElements.SearchValue)) >= 0);
                else
                {
                    data = data.Where(t => t.GetType().GetProperty(findElements.SearchProperty).GetValue(t, null) == null);
                }
            }
            else if (searchPropertyType == typeof(bool))
            {
                data = data.Where(t => t.GetType().GetProperty(findElements.SearchProperty).GetValue(t, null)
                .Equals(findElements.SearchValue));
            }
            else if (searchPropertyType == typeof(Nullable<TimeSpan>) || searchPropertyType == typeof(TimeSpan))
            {
                if (findElements.SearchValue != null)
                    data = data.Where(t => t.GetType().GetProperty(findElements.SearchProperty).GetValue(t, null) != null &&
                    TimeSpan.Compare((TimeSpan)t.GetType().GetProperty(findElements.SearchProperty).GetValue(t, null),
                    (TimeSpan)findElements.SearchValue) >= 0);
                else
                {
                    data = data.Where(t => t.GetType().GetProperty(findElements.SearchProperty).GetValue(t, null) == null);
                }
            }
            return data;
        }
    }
}
