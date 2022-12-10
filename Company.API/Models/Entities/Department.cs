﻿using Company.API.Models.Enums;

namespace Company.API.Models.Entities;

public class Department : Entity
{
    public string Name { get; private set; }
    public DepartmentType DepartmentType { get; private set; }
    public List<Employee> Employees { get; private set; }

    public Department()
    {
    }

    private Department(string name, DepartmentType departmentType)
    {
        Name = name;
        DepartmentType = departmentType;
        Employees = new List<Employee>();
    }

    public static Department Create(string name, DepartmentType departmentType)
    {
        return new Department(name, departmentType);
    }

    public void AddNewEmployee(Employee employee)
    {
        var employeeAlreadyExists = Employees.Any(_ => _.Id == employee.Id);

        Employees.Add(employee);
    }
}