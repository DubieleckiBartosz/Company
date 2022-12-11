using Company.API.Models.Searches.Parameters;
using Company.API.Tools;

namespace Company.API.Models.Searches.Queries;

public record GetCompaniesBySearchQuery(SortModel Sort, BaseSearchQuery SearchQuery, string? Id, string? Name)
{
    public static GetCompaniesBySearchQuery Create(GetCompaniesBySearchParameters parameters)
    {
        parameters ??= new GetCompaniesBySearchParameters();
        if (parameters is { Sort: null })
        {
            parameters.Sort = new SortModelParameters();
        }
         
        var sortModel = parameters.CheckOrAssignSortModel();
        var search = new BaseSearchQuery(parameters.PageNumber, parameters.PageSize);
        return new GetCompaniesBySearchQuery(sortModel, search, parameters.Id, parameters.Name);
    }
}