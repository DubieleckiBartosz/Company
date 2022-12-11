using Company.API.Models.Searches.Parameters;

namespace Company.API.Interfaces.Recognizers;

public interface IFilterModel
{
    SortModelParameters Sort { get; set; }
}