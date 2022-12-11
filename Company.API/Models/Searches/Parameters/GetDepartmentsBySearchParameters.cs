using Company.API.Interfaces.Recognizers;
using Company.API.Models.Enums;

namespace Company.API.Models.Searches.Parameters;

public class GetDepartmentsBySearchParameters : BaseSearchQueryParameters, IFilterModel
{
    public string? Name { get; set; }
    public string? DepartmentUniqueCode { get; set; }
    public DepartmentType? DepartmentType { get; set; }
    public SortModelParameters? Sort { get; set; }
}