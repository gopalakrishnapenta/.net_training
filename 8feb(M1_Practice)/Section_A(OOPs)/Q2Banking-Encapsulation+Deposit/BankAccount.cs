using System;

public class BankAccount
{
    private double balance;

    public BankAccount(double initialBalance)
    {
        if (initialBalance > 0)
            balance = initialBalance;
        else
            balance = 0;
    }

    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            balance += amount;
        }
        else
        {
            Console.WriteLine("Invalid deposit amount");
        }
    }

    public void Withdraw(double amount)
    {
        if (amount > 0 && amount <= balance)
        {
            balance -= amount;
        }
        else
        {
            Console.WriteLine("Invalid withdraw amount");
        }
    }

    public double GetBalance()
    {
        return balance;
    }
}
