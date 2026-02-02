using System;

namespace EmployeeManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            HRManager hr = new HRManager();

            hr.AddEmployee("Alice", "HR", 50000);
            hr.AddEmployee("Bob", "IT", 70000);
            hr.AddEmployee("Charlie", "Sales", 60000);
            hr.AddEmployee("Diana", "IT", 75000);

            Console.WriteLine("Employees Grouped by Department:");
            var groupedEmployees = hr.GroupEmployeesByDepartment();
            foreach (var dept in groupedEmployees)
            {
                Console.WriteLine($"\nDepartment: {dept.Key}");
                foreach (var emp in dept.Value)
                {
                    Console.WriteLine($"{emp.EmployeeId} - {emp.Name} - {emp.Salary}");
                }
            }

            Console.WriteLine("\nTotal Salary by Department:");
            foreach (var dept in groupedEmployees.Keys)
            {
                Console.WriteLine($"{dept}: {hr.CalculateDepartmentSalary(dept)}");
            }

            Console.WriteLine("\nEmployees Joined After Yesterday:");
            var recentEmployees = hr.GetEmployeesJoinedAfter(DateTime.Now.AddDays(-1));
            foreach (var emp in recentEmployees)
            {
                Console.WriteLine($"{emp.EmployeeId} - {emp.Name} - {emp.JoiningDate}");
            }
        }
    }
}
