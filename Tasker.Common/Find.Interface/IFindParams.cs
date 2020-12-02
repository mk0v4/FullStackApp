namespace Tasker.Common.Find.Interface
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