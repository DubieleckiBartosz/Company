using Company.API.Interfaces.Recognizers;

namespace Company.API.Models.Searches.Parameters;

public class GetCompaniesBySearchParameters : BaseSearchQueryParameters, IFilterModel
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public SortModelParameters? Sort { get; set; }
}