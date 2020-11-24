namespace Tasker.Service.DataAccess.Interface
{
    public interface IFindParams
    {
        long? Id { get; }
        int NumberOfRows { get; }
        int? PageNumber { get; }
        string SortBy { get; }
        string SortDirection { get; }
    }
}