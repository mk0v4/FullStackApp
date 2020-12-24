using Tasker.Common.Find.Interface;

namespace Tasker.Common.Find
{
    public class FindParams : IFindParams
    {
        public FindParams(long? id, int? pageNumber, string filterBy, string filterCondition,
            int numberOfRows, string sortBy, string sortDirection)
        {
            Id = id;
            PageNumber = pageNumber;
            FilterBy = filterBy;
            FilterCondition = filterCondition;
            NumberOfRows = numberOfRows;
            SortBy = sortBy;
            SortDirection = sortDirection;
        }
        public long? Id { get; }
        public int? PageNumber { get; }
        public string FilterBy { get; }
        public string FilterCondition { get; }
        public int NumberOfRows { get; }
        public string SortBy { get; }
        public string SortDirection { get; }


    }
}