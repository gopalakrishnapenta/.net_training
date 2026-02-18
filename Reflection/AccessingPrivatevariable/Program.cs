using System;
using System.Reflection;
public class Employee
{
    private double salary = 50000;

    public void Show()
    {
        Console.WriteLine("Employee object created");
    }
}


class Program
{
    static void Main()
    {
        Employee emp = new Employee();

        Type type = typeof(Employee);
        // Access private field using reflection
        FieldInfo field = type.GetField(
            "salary",
            BindingFlags.NonPublic | BindingFlags.Instance
        );

        
        double value = (double)field.GetValue(emp);
        Console.WriteLine("Private Salary: " + value);

        // Modify value
        field.SetValue(emp, 75000);

        Console.WriteLine("Updated Salary: " + field.GetValue(emp));
    }
}
