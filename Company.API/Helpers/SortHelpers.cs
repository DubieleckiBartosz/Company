using System.Linq.Expressions;

namespace Company.API.Helpers;

public class SortHelpers
{
    public static Expression<Func<Models.Documents.Company, object>> CompanySortBy(string sortName)
    {
        var name = sortName.ToLower();

        if (name == "name")
        {
            return company => company.Name;
        }

        return company => company.Id;
    }
}