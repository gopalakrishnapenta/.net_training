public class Program
{
    public static void Main()
    {
        Employee emp1 = new Employee(1, "Alice", "alice@gmail.com", 50000);
        Employee emp2 = new Employee(2, "Bob", "bob@gmail.com", -10000);
        Employee emp3 = new Employee(3, "Charlie", null, 0);

        emp1.PrintDetails();
        emp2.PrintDetails();
        emp3.PrintDetails();
    }
}
