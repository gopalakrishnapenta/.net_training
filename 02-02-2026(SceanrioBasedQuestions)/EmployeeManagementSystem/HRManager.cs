using System;
using System.Collections.Generic;

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
            Dictionary<string, List<Employee>> grouped = new Dictionary<string, List<Employee>>();
            
            foreach (var employee in employees)
            {
                if (!grouped.ContainsKey(employee.Department))
                {
                    grouped[employee.Department] = new List<Employee>();
                }
                grouped[employee.Department].Add(employee);
            }
            
            return new SortedDictionary<string, List<Employee>>(grouped);
        }

        public double CalculateDepartmentSalary(string department)
        {
            double totalSalary = 0;
            foreach (var employee in employees)
            {
                if (employee.Department.Equals(department, StringComparison.OrdinalIgnoreCase))
                {
                    totalSalary += employee.Salary;
                }
            }
            return totalSalary;
        }

        public List<Employee> GetEmployeesJoinedAfter(DateTime date)
        {
            List<Employee> result = new List<Employee>();
            foreach (var employee in employees)
            {
                if (employee.JoiningDate > date)
                {
                    result.Add(employee);
                }
            }
            return result;
        }
    }
}
