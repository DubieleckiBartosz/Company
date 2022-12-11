using Company.API.Interfaces.Recognizers;
using Company.API.Models.Searches.Queries;

namespace Company.API.Tools;

public static class SortAssigner
{
    public static SortModel CheckOrAssignSortModel(this IFilterModel filterModel, string? name = null, string? type = null)
    {
        var sortType = string.IsNullOrWhiteSpace(filterModel.Sort.Type) ? type ?? "desc" : filterModel.Sort.Type;
        var sortName = string.IsNullOrWhiteSpace(filterModel.Sort.Name) ? name ?? "_id" : filterModel.Sort.Name;
        sortType = sortType.ToLower() == "desc" ? "desc" : "asc";

        return new SortModel(sortName, sortType);
    }
}