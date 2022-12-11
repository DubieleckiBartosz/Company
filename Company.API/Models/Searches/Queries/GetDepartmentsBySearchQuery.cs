using Company.API.Models.Enums;
using Company.API.Models.Searches.Parameters;
using Company.API.Tools;

namespace Company.API.Models.Searches.Queries;

public record GetDepartmentsBySearchQuery(SortModel Sort, BaseSearchQuery SearchQuery, string? DepartmentUniqueCode,
    DepartmentType? DepartmentType, string? Name)
{
    public static GetDepartmentsBySearchQuery Create(GetDepartmentsBySearchParameters parameters)
    {
        parameters ??= new GetDepartmentsBySearchParameters();
        if (parameters is {Sort: null}) parameters.Sort = new SortModelParameters();

        var sortModel = parameters.CheckOrAssignSortModel("DepartmentType");

        var search = new BaseSearchQuery(parameters.PageNumber, parameters.PageSize);
        return new GetDepartmentsBySearchQuery(sortModel, search, parameters.DepartmentUniqueCode,
            parameters.DepartmentType, parameters.Name);
    }
}