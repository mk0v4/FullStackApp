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

        public IQueryable<T> FilterData(IQueryable<T> data)
        {
            if (_filterModel != null)
            {
                foreach (PropertyInfo property in _filterModel.GetType().GetProperties())
                {
                    if (property.GetValue(_filterModel, null) != null)
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
            Type searchPropertyType = typeof(T).GetProperty(property).PropertyType;
            if (searchPropertyType == typeof(string))
            {
                data = data.Where(t =>
                t.GetType().GetProperty(property).GetValue(t, null) != null ?
                t.GetType().GetProperty(property).GetValue(t, null).ToString().ToLower()
                    .Contains(value.ToString().ToLower()) :
                    "".Contains(value.ToString()));
            }
            else if (searchPropertyType.IsEnum)
            {
                Type enumType = typeof(T).GetProperty(property).PropertyType;
                data = data.Where(t => t.GetType().GetProperty(property).GetValue(t, null).ToString()
                .Equals(Enum.GetName(enumType, value)));
            }
            else if (searchPropertyType == typeof(Nullable<DateTime>))
            {
                if (value != null)
                    data = data.Where(t => DateTime.Compare(Convert.ToDateTime(
                        t.GetType().GetProperty(property).GetValue(t, null)),
                        Convert.ToDateTime(value)) >= 0);
                else
                    data = data.Where(t => t.GetType().GetProperty(property).GetValue(t, null) == null);
            }
            else if (searchPropertyType == typeof(bool))
            {
                data = data.Where(t => t.GetType().GetProperty(property).GetValue(t, null)
                .Equals(value));
            }
            else if (searchPropertyType == typeof(Nullable<TimeSpan>) || searchPropertyType == typeof(TimeSpan))
            {
                if (value != null)
                    data = data.Where(t => t.GetType().GetProperty(property).GetValue(t, null) != null &&
                    TimeSpan.Compare((TimeSpan)t.GetType().GetProperty(property).GetValue(t, null),
                    (TimeSpan) value) >= 0);
                else
                    data = data.Where(t => t.GetType().GetProperty(property).GetValue(t, null) == null);
            }
            return data;
        }
    }
}
