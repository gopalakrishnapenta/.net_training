using System;

public class Employee
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public decimal Salary { get; private set; }

    public Employee(int id, string name, string email, decimal salary)
    {
        Id = id;
        Name = name;

        // Email validation WITHOUT LINQ
        if (!string.IsNullOrEmpty(email) && email.Contains("@"))
            Email = email;
        else
            Email = "unknown@company.com";

        // Salary validation WITHOUT LINQ
        if (salary > 0)
            Salary = salary;
        else
            Salary = 30000;
    }

    public void PrintDetails()
    {
        Console.WriteLine("Employee Details:");
        Console.WriteLine(
            "Id: " + Id +
            ", Name: " + Name +
            ", Email: " + Email +
            ", Salary: " + Salary);
    }
}
