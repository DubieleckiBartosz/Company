using Company.API.Common.Exceptions;
using Company.API.Models.Enums;

namespace Company.API.Models.Entities;

public class Contract : Entity
{
    public Employee Employee { get; private set; }
    public decimal Salary { get; }
    public DateTime Start { get; }
    public DateTime? End { get; }
    public int HoursPerMonth { get; }
    public ContractType ContractType { get; }

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

    public void AssignEmployee(Employee employee)
    {
        if (Employee != null)
        {
            throw new CompanyAppBusinessException();
        }

        Employee = employee;
    }
}