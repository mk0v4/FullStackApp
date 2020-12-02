using Tasker.Common.Find.Interface;

namespace Tasker.Common.Find
{
    public class FindParams : IFindParams
    {

        public FindParams(int? pageNumber, int numberOfRows, string sortBy, string sortDirection)
        {
            PageNumber = pageNumber;
            NumberOfRows = numberOfRows;
            SortBy = sortBy;
            SortDirection = sortDirection;
        }
        public FindParams(long? id, int? pageNumber, int numberOfRows, string sortBy, string sortDirection)
        {
            Id = id;
            PageNumber = pageNumber;
            NumberOfRows = numberOfRows;
            SortBy = sortBy;
            SortDirection = sortDirection;
        }
        public long? Id { get; }
        public int? PageNumber { get; }
        public int NumberOfRows { get; }
        public string SortBy { get; }
        public string SortDirection { get; }

    }
}