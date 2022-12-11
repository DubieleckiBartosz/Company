using Company.API.Common.Exceptions;
using Company.API.Models.Enums;

namespace Company.API.Models.Documents;

public class Contract : Base
{ 
    public decimal Salary { get; private set; }
    public DateTime Start { get; private set; }
    public DateTime? End { get; private set; }
    public int HoursPerMonth { get; private set; }
    public ContractType ContractType { get; private set; }

    public Contract()
    {
    }
    private Contract(decimal salary, DateTime start, DateTime? end, int hoursPerMonth, ContractType contractType) : base()
    {
        Salary = salary;
        Start = start;
        End = end;
        HoursPerMonth = hoursPerMonth;
        ContractType = contractType;
    }

    public static Contract Create(decimal salary, DateTime start, DateTime? end, int hoursPerMonth, ContractType contractType)
    {
        return new Contract(salary, start, end, hoursPerMonth, contractType);
    } 
}