namespace EasyRent.Application.DTOs.Common;

/// <summary>
/// A single page of results plus the paging metadata the client needs to render
/// pagination controls. Used by apartment search.
/// </summary>
public class PagedResult<T>
{
    public IEnumerable<T> Items { get; set; } = new List<T>();
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }

    /// <summary>Total number of pages, derived from TotalCount and PageSize.</summary>
    public int TotalPages => PageSize > 0 ? (int)Math.Ceiling(TotalCount / (double)PageSize) : 0;
}
