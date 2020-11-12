using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tasker.Service.DataAccess.Interface;

namespace Tasker.Service.DataAccess
{
    public class FilteringElements : IFilteringElements
    {
        public FilteringElements(string searchProperty, object searchValue,
            int? pageNumber, int numberOfRows, string sortBy, string sortDirection)
        {
            SearchProperty = searchProperty;
            SearchValue = searchValue;
            PageNumber = pageNumber;
            NumberOfRows = numberOfRows;
            SortBy = sortBy;
            SortDirection = sortDirection;
        }
        public FilteringElements(long? id, string searchProperty, object searchValue, 
            int? pageNumber, int numberOfRows, string sortBy, string sortDirection) {
            Id = id;
            SearchProperty = searchProperty;
            SearchValue = searchValue;
            PageNumber = pageNumber;
            NumberOfRows = numberOfRows;
            SortBy = sortBy;
            SortDirection = sortDirection;
        }
        public long? Id { get; }
        public string SearchProperty { get; }
        public object SearchValue { get; }
        public int? PageNumber { get; }
        public int NumberOfRows { get; }
        public string SortBy { get; }
        public string SortDirection { get; }

    }
}