namespace Tasker.Service.DataAccess.Interface
{
    public interface IFindParams
    {
        long? Id { get; }
        int NumberOfRows { get; }
        int? PageNumber { get; }
        object SearchValue { get; }
        string SearchProperty { get; }
        string SortBy { get; }
        string SortDirection { get; }
    }
}