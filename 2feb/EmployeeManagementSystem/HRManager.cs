using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagementSystem
{
    public class HRManager
    {
        private readonly List<Employee> employees = new List<Employee>();
        private int idCounter = 1;

        public void AddEmployee(string name, string dept, double salary)
        {
            employees.Add(new Employee
            {
                EmployeeId = $"E{idCounter++.ToString("D3")}",
                Name = name,
                Department = dept,
                Salary = salary,
                JoiningDate = DateTime.Now
            });
        }

        public SortedDictionary<string, List<Employee>> GroupEmployeesByDepartment()
        {
            return new SortedDictionary<string, List<Employee>>(
                employees.GroupBy(e => e.Department)
                         .ToDictionary(g => g.Key, g => g.ToList())
            );
        }

        public double CalculateDepartmentSalary(string department)
        {
            return employees
                .Where(e => e.Department.Equals(department, StringComparison.OrdinalIgnoreCase))
                .Sum(e => e.Salary);
        }

        public List<Employee> GetEmployeesJoinedAfter(DateTime date)
        {
            return employees
                .Where(e => e.JoiningDate > date)
                .ToList();
        }
    }
}
