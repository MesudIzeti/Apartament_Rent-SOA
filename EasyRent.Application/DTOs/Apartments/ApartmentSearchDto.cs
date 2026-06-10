namespace EasyRent.Application.DTOs.Apartments;

/// <summary>Query parameters for searching/filtering apartments, with pagination.
/// All filters are optional; defaults give the first page of 10 results.</summary>
public class ApartmentSearchDto
{
    public string? City { get; set; }
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }

    /// <summary>Filter to apartments available across this date range (no overlapping booking).</summary>
    public DateTime? CheckIn { get; set; }
    public DateTime? CheckOut { get; set; }

    public int? Bedrooms { get; set; }

    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
