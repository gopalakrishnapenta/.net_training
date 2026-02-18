public class Program
{
    public static void Main()
    {
        BankAccount account = new BankAccount(1000); // initial balance
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nCurrent Balance: " + account.GetBalance());
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Exit");

            Console.Write("Enter choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter deposit amount: ");
                    double depositAmount = Convert.ToDouble(Console.ReadLine());
                    account.Deposit(depositAmount);
                    break;

                case 2:
                    Console.Write("Enter withdraw amount: ");
                    double withdrawAmount = Convert.ToDouble(Console.ReadLine());
                    account.Withdraw(withdrawAmount);
                    break;

                case 3:
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }

        Console.WriteLine("\nFinal Balance: " + account.GetBalance());
    }
}
