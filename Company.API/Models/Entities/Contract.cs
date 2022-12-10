using Company.API.Models.Enums;

namespace Company.API.Models.Entities;

public class Contract : Entity
{
    public Employee Employee { get; set; }
    public decimal  Salary { get; set; }
    public DateTime Start { get; set; }
    public DateTime? End { get; set; }
    public int HoursPerMonth { get; set; }
    public ContractType ContractType { get; set; }
}